using System.ComponentModel;

namespace FastHorse
{
    public class SqlFileInfo : INotifyPropertyChanged
    {
        private string fileName;
        private string filePath;
        private string executionStatus;

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

        public string FilePath
        {
            get { return filePath; }
            set
            {
                if (filePath != value)
                {
                    filePath = value;
                    OnPropertyChanged(nameof(FilePath));
                }
            }
        }

        public string ExecutionStatus
        {
            get { return executionStatus; }
            set
            {
                if (executionStatus != value)
                {
                    executionStatus = value;
                    OnPropertyChanged(nameof(ExecutionStatus));
                    OnPropertyChanged(nameof(DisplayName));
                }
            }
        }

        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(ExecutionStatus))
                    return FileName;

                switch (ExecutionStatus)
                {
                    case "成功":
                        return $"✓ {FileName}";
                    case "失败":
                        return $"✗ {FileName}";
                    case "执行中":
                        return $"⏳ {FileName}";
                    default:
                        return FileName;
                }
            }
        }

        public SqlFileInfo()
        {
        }

        public SqlFileInfo(string filePath)
        {
            this.FilePath = filePath;
            this.FileName = System.IO.Path.GetFileName(filePath);
            this.ExecutionStatus = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

