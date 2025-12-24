using System;
using System.IO;
using System.Text;
using Ude;

namespace FastHorse
{
    public static class FileEncodingHelper
    {
        /// <summary>
        /// 检测文件编码并读取文件内容
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件内容</returns>
        public static string ReadFileWithEncodingDetection(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"文件不存在: {filePath}");
            }

            // 读取文件字节
            byte[] buffer = new byte[4096];
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                int bytesRead = fs.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0)
                {
                    return string.Empty;
                }

                // 使用Ude检测编码
                CharsetDetector detector = new CharsetDetector();
                detector.Feed(buffer, 0, bytesRead);
                detector.DataEnd();

                Encoding detectedEncoding = Encoding.UTF8; // 默认使用UTF-8

                if (detector.Charset != null)
                {
                    try
                    {
                        string charsetName = detector.Charset.ToUpperInvariant();
                        
                        // 映射常见的编码名称
                        switch (charsetName)
                        {
                            case "UTF-8":
                                detectedEncoding = Encoding.UTF8;
                                break;
                            case "UTF-16LE":
                            case "UTF-16":
                                detectedEncoding = Encoding.Unicode;
                                break;
                            case "UTF-16BE":
                                detectedEncoding = Encoding.BigEndianUnicode;
                                break;
                            case "GB18030":
                            case "GB2312":
                            case "GBK":
                                detectedEncoding = Encoding.GetEncoding("GB2312");
                                break;
                            case "BIG5":
                                detectedEncoding = Encoding.GetEncoding("Big5");
                                break;
                            case "WINDOWS-1252":
                            case "ISO-8859-1":
                                detectedEncoding = Encoding.GetEncoding("Windows-1252");
                                break;
                            case "SHIFT_JIS":
                                detectedEncoding = Encoding.GetEncoding("Shift_JIS");
                                break;
                            case "EUC-JP":
                                detectedEncoding = Encoding.GetEncoding("EUC-JP");
                                break;
                            default:
                                // 尝试直接获取编码
                                try
                                {
                                    detectedEncoding = Encoding.GetEncoding(charsetName);
                                }
                                catch
                                {
                                    // 如果无法识别，使用UTF-8
                                    detectedEncoding = Encoding.UTF8;
                                }
                                break;
                        }
                    }
                    catch
                    {
                        // 如果检测失败，使用UTF-8
                        detectedEncoding = Encoding.UTF8;
                    }
                }

                // 使用检测到的编码读取整个文件
                return File.ReadAllText(filePath, detectedEncoding);
            }
        }
    }
}

