using System;
using System.ComponentModel;

namespace FastHorse
{
    public class SqlFileInfo : INotifyPropertyChanged
    {
        private string fileName;
        private string filePath;

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

        public SqlFileInfo()
        {
        }

        public SqlFileInfo(string filePath)
        {
            this.FilePath = filePath;
            this.FileName = System.IO.Path.GetFileName(filePath);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

