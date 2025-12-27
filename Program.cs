using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FastHorse
{
    internal static class Program
    {
        // DPI感知相关API
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [DllImport("shcore.dll")]
        private static extern int SetProcessDpiAwareness(ProcessDPIAwareness value);

        private enum ProcessDPIAwareness
        {
            ProcessDPIUnaware = 0,
            ProcessSystemDPIAware = 1,
            ProcessPerMonitorDPIAware = 2
        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 设置DPI感知
            try
            {
                // Windows 8.1+ 使用新的API
                SetProcessDpiAwareness(ProcessDPIAwareness.ProcessPerMonitorDPIAware);
            }
            catch
            {
                // Windows 7/8 使用旧的API
                try
                {
                    SetProcessDPIAware();
                }
                catch
                {
                    // 如果都失败，继续运行（可能不支持）
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 显示授权验证窗口
            using (AuthorizationForm authForm = new AuthorizationForm())
            {
                if (authForm.ShowDialog() == DialogResult.OK)
                {
                    // 验证成功，启动主程序
                    Application.Run(new Form1());
                }
                else
                {
                    // 验证失败或取消，退出程序
                    Application.Exit();
                }
            }
        }
    }
}
