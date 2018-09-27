using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Timers;
namespace Stopwatch
{
    public partial class MainPage : ContentPage
    {
        //TimeSpan updateInterval = TimeSpan.FromMilliseconds(10);

        public bool isTiming = false;
        double min, sec, milli;
        Timer timer;
        

        public MainPage()
        {
            InitializeComponent();
            //btnStartTimer.Clicked += delegate
            //{
            //    timer = new Timer();
            //    timer.Interval = 1;
            //    timer.Elapsed += Timer_Elapsed;
            //    timer.Start();
            //};

            //btnStopTimer.Clicked += delegate
            //{
            //    timer.Stop();
            //    timer = null; //removre instance of timer so we can start new one 
            //};
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isTiming)
            {
                //throw new NotImplementedException();
                milli++;
                //if logic structure
                if (milli >= 1000)
                {
                    //add one second and reset milliseconds
                    sec++;
                    milli = 0;
                }
                if (sec == 59)//about to add a minute
                {
                    min++;
                    sec = 0;
                }
                Device.BeginInvokeOnMainThread(() =>
                {
                    TimerLabel.Text = string.Format("{0}:{1:00}:{2:000}", min, sec, milli);

                });
                if (isTiming == false)
                {
                    TimerLabel.Text = string.Format("{0}:{1:00}:{2:000}", min, sec, milli);
                    timer.Stop();
                    timer.Close();
                }
            }
        }

        private void btnStartTimer_Clicked(object sender, EventArgs e)
        {
            
            timer = new Timer();
            timer.Interval = 1;
            isTiming = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            
        }

        private void btnStopTimer_Clicked(object sender, EventArgs e)
        {
            isTiming = false;
            timer.Stop();
        }

    }
}
