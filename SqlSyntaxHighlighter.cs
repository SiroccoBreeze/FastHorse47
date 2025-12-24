using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FastHorse
{
    public class SqlSyntaxHighlighter
    {
        // SQL 关键字
        private static readonly HashSet<string> Keywords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "SELECT", "FROM", "WHERE", "INSERT", "UPDATE", "DELETE", "CREATE", "ALTER", "DROP",
            "TABLE", "VIEW", "INDEX", "DATABASE", "PROCEDURE", "FUNCTION", "TRIGGER",
            "JOIN", "INNER", "LEFT", "RIGHT", "OUTER", "FULL", "CROSS",
            "ON", "AS", "AND", "OR", "NOT", "IN", "EXISTS", "BETWEEN", "LIKE",
            "ORDER", "BY", "GROUP", "HAVING", "DISTINCT", "TOP", "LIMIT", "OFFSET",
            "SET", "VALUES", "INTO", "BEGIN", "END", "IF", "ELSE", "WHILE", "CASE", "WHEN", "THEN",
            "DECLARE", "EXEC", "EXECUTE", "RETURN", "GO", "USE", "WITH",
            "PRIMARY", "KEY", "FOREIGN", "REFERENCES", "UNIQUE", "CHECK", "DEFAULT",
            "NULL", "IS", "ASC", "DESC", "UNION", "ALL", "ANY", "SOME",
            "GRANT", "REVOKE", "COMMIT", "ROLLBACK", "TRANSACTION", "SAVEPOINT",
            "CONSTRAINT", "CASCADE", "IDENTITY", "CLUSTERED", "NONCLUSTERED"
        };

        // SQL 数据类型
        private static readonly HashSet<string> DataTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "INT", "INTEGER", "BIGINT", "SMALLINT", "TINYINT", "BIT",
            "DECIMAL", "NUMERIC", "MONEY", "SMALLMONEY", "FLOAT", "REAL",
            "DATE", "TIME", "DATETIME", "DATETIME2", "SMALLDATETIME", "DATETIMEOFFSET", "TIMESTAMP",
            "CHAR", "VARCHAR", "TEXT", "NCHAR", "NVARCHAR", "NTEXT",
            "BINARY", "VARBINARY", "IMAGE",
            "UNIQUEIDENTIFIER", "XML", "JSON",
            "CURSOR", "TABLE", "SQL_VARIANT"
        };

        // SQL 函数
        private static readonly HashSet<string> Functions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "COUNT", "SUM", "AVG", "MIN", "MAX", "CAST", "CONVERT",
            "ISNULL", "COALESCE", "NULLIF", "LEN", "SUBSTRING", "CHARINDEX",
            "UPPER", "LOWER", "LTRIM", "RTRIM", "REPLACE", "CONCAT",
            "GETDATE", "DATEADD", "DATEDIFF", "YEAR", "MONTH", "DAY",
            "NEWID", "ROW_NUMBER", "RANK", "DENSE_RANK", "PARTITION"
        };

        // 颜色定义
        private static readonly Color KeywordColor = Color.FromArgb(0, 0, 255);        // 蓝色
        private static readonly Color DataTypeColor = Color.FromArgb(43, 145, 175);    // 青色
        private static readonly Color FunctionColor = Color.FromArgb(255, 0, 255);     // 紫红色
        private static readonly Color StringColor = Color.FromArgb(163, 21, 21);       // 红色
        private static readonly Color CommentColor = Color.FromArgb(0, 128, 0);        // 绿色
        private static readonly Color NumberColor = Color.FromArgb(9, 134, 88);        // 深绿色
        private static readonly Color OperatorColor = Color.FromArgb(128, 128, 128);   // 灰色
        private static readonly Color DefaultColor = Color.Black;                       // 黑色

        public static void ApplySyntaxHighlight(RichTextBox textBox, string sqlText)
        {
            if (textBox == null || string.IsNullOrEmpty(sqlText))
                return;

            // 保存当前选择位置
            int selectionStart = textBox.SelectionStart;
            int selectionLength = textBox.SelectionLength;

            // 禁用重绘以提高性能
            textBox.SuspendLayout();

            try
            {
                // 设置文本
                textBox.Text = sqlText;

                // 重置所有文本为默认颜色
                textBox.SelectAll();
                textBox.SelectionColor = DefaultColor;
                textBox.SelectionFont = new Font("Consolas", 9.75F);

                // 高亮注释（单行注释 --）
                HighlightPattern(textBox, @"--[^\r\n]*", CommentColor);

                // 高亮注释（多行注释 /* */）
                HighlightPattern(textBox, @"/\*[\s\S]*?\*/", CommentColor);

                // 高亮字符串（单引号）
                HighlightPattern(textBox, @"'([^']|'')*'", StringColor);

                // 高亮数字
                HighlightPattern(textBox, @"\b\d+\.?\d*\b", NumberColor);

                // 高亮关键字
                HighlightKeywords(textBox, Keywords, KeywordColor, FontStyle.Bold);

                // 高亮数据类型
                HighlightKeywords(textBox, DataTypes, DataTypeColor, FontStyle.Regular);

                // 高亮函数
                HighlightKeywords(textBox, Functions, FunctionColor, FontStyle.Regular);

                // 高亮运算符
                HighlightPattern(textBox, @"[+\-*/<>=!]+", OperatorColor);
            }
            finally
            {
                // 恢复选择位置
                textBox.SelectionStart = Math.Min(selectionStart, textBox.Text.Length);
                textBox.SelectionLength = 0;

                // 恢复重绘
                textBox.ResumeLayout();
            }
        }

        private static void HighlightPattern(RichTextBox textBox, string pattern, Color color)
        {
            try
            {
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                foreach (Match match in regex.Matches(textBox.Text))
                {
                    textBox.Select(match.Index, match.Length);
                    textBox.SelectionColor = color;
                }
            }
            catch
            {
                // 忽略正则表达式错误
            }
        }

        private static void HighlightKeywords(RichTextBox textBox, HashSet<string> keywords, Color color, FontStyle fontStyle)
        {
            foreach (string keyword in keywords)
            {
                // 使用单词边界确保完整匹配
                string pattern = @"\b" + Regex.Escape(keyword) + @"\b";
                try
                {
                    Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                    foreach (Match match in regex.Matches(textBox.Text))
                    {
                        textBox.Select(match.Index, match.Length);
                        textBox.SelectionColor = color;
                        textBox.SelectionFont = new Font(textBox.Font, fontStyle);
                    }
                }
                catch
                {
                    // 忽略错误
                }
            }
        }

        // 快速高亮（用于大文件，只高亮关键元素）
        public static void ApplyFastSyntaxHighlight(RichTextBox textBox, string sqlText)
        {
            if (textBox == null || string.IsNullOrEmpty(sqlText))
                return;

            int selectionStart = textBox.SelectionStart;
            textBox.SuspendLayout();

            try
            {
                textBox.Text = sqlText;
                textBox.SelectAll();
                textBox.SelectionColor = DefaultColor;
                textBox.SelectionFont = new Font("Consolas", 9.75F);

                // 只高亮注释和字符串
                HighlightPattern(textBox, @"--[^\r\n]*", CommentColor);
                HighlightPattern(textBox, @"/\*[\s\S]*?\*/", CommentColor);
                HighlightPattern(textBox, @"'([^']|'')*'", StringColor);

                // 只高亮主要关键字
                var mainKeywords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    "SELECT", "FROM", "WHERE", "INSERT", "UPDATE", "DELETE", "CREATE", "ALTER", "DROP",
                    "JOIN", "INNER", "LEFT", "RIGHT", "ON", "AND", "OR"
                };
                HighlightKeywords(textBox, mainKeywords, KeywordColor, FontStyle.Bold);
            }
            finally
            {
                textBox.SelectionStart = Math.Min(selectionStart, textBox.Text.Length);
                textBox.SelectionLength = 0;
                textBox.ResumeLayout();
            }
        }
    }
}

