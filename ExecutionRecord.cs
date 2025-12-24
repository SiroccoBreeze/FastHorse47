using System;
using System.ComponentModel;

namespace FastHorse
{
    public class ExecutionRecord : INotifyPropertyChanged
    {
        private string fileName;
        private string durationText;
        private string status;
        private string errorMessage;

        public string FileName
        {
            get { return fileName; }
            set
            {
                if (fileName != value)
                {
                    fileName = value;
                    OnPropertyChanged(nameof(FileName));
                }
            }
        }

        /// <summary>
        /// 记录脚本执行开始时间（不参与数据绑定）。
        /// </summary>
        public DateTime StartTime { get; set; }

        public string DurationText
        {
            get { return durationText; }
            set
            {
                if (durationText != value)
                {
                    durationText = value;
                    OnPropertyChanged(nameof(DurationText));
                }
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }

        public ExecutionRecord()
        {
            StartTime = DateTime.Now;
            DurationText = "等待执行";
            Status = "等待执行";
            ErrorMessage = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

