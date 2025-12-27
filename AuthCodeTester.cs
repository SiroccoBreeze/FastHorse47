using System;

namespace FastHorse
{
    /// <summary>
    /// 授权码生成测试工具
    /// 用于测试和验证每日授权码的生成逻辑
    /// </summary>
    public class AuthCodeTester
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("FastHorse 授权码生成器");
            Console.WriteLine("======================");
            Console.WriteLine();

            // 生成今日授权码
            string todayCode = GenerateTodayCode();
            Console.WriteLine($"今日日期: {DateTime.Now:yyyy-MM-dd}");
            Console.WriteLine($"今日授权码: {todayCode}");
            Console.WriteLine();

            // 测试未来几天的授权码
            Console.WriteLine("未来7天的授权码预览:");
            Console.WriteLine("-------------------");
            for (int i = 0; i < 7; i++)
            {
                DateTime date = DateTime.Now.Date.AddDays(i);
                string code = GenerateCodeForDate(date);
                Console.WriteLine($"{date:yyyy-MM-dd}: {code}");
            }

            Console.WriteLine();
            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }

        private static string GenerateTodayCode()
        {
            return GenerateCodeForDate(DateTime.Now.Date);
        }

        private static string GenerateCodeForDate(DateTime date)
        {
            // 使用日期生成种子
            int seed = date.Year * 10001 + date.Month * 100 + date.Day;
            seed = (seed * 31) % 1000000; // 确保是6位数

            // 使用固定密钥进行混淆
            int secretKey = 6835;
            seed = (seed ^ secretKey) % 1000000;

            // 确保生成6位数字
            return seed.ToString("D6");
        }
    }
}

