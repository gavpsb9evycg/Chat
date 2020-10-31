using System.ComponentModel;

namespace WpfChat
{
    public class MessageItem : INotifyPropertyChanged
    {
        private string message;
        private string time;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Message
        {
            get => this.message;
            set
            {
                if (this.message != value)
                {
                    this.message = value;
                    this.OnPropertyChanged("Message");
                }
            }
        }

        public string Time
        {
            get => this.time;
            set
            {
                if (this.time != value)
                {
                    this.time = value;
                    this.OnPropertyChanged("Time");
                }
            }
        }
    }
}
