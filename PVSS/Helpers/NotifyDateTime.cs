using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace PVSS.Helpers
{
    public class NotifyingDateTime : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime _now;
        private string _date;
        private string _time;

        public NotifyingDateTime()
        {
            _now = DateTime.Now;
            _date = _now.ToShortDateString();
            _time = _now.ToString("HH:mm:ss zzz");

            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(100)
            };
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        public DateTime Now
        {
            get { return _now; }
            private set
            {
                _now = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Now"));
            }
        }

        public string Date
        {
            get { return _date; }
            private set
            {
                _date = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Date"));
            }
        }

        public string Time
        {
            get { return _time; }
            private set
            {
                _time = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Time"));

            }

        }

        void timer_Tick(object sender, EventArgs e)
        {

            Now = DateTime.Now;
            Date = Now.ToShortDateString();
            Time = Now.ToString("HH:mm:ss zzz");
        }
    }
}
