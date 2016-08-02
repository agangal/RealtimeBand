using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RealtimeBand.Model;
using Microsoft.Band.Sensors;
using Microsoft.Band;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RealtimeBand
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer timer;
        BandModel bandModel = new BandModel();
        SensorReading sensorReading = new SensorReading();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void getData_Click(object sender, RoutedEventArgs e)
        {
            
            //await bandhelper.connectToBand();
            await BandModel.initAsync();
            if (BandModel.BandClient.SensorManager.HeartRate.GetCurrentUserConsent() != UserConsent.Granted)
            {
                await BandModel.BandClient.SensorManager.HeartRate.RequestUserConsentAsync();
            }
            BandModel.BandClient.SensorManager.HeartRate.ReadingChanged += HeartRate_ReadingChanged;
            try
            {
                if (BandModel.BandClient.SensorManager.HeartRate.GetCurrentUserConsent() == UserConsent.Granted)
                {
                    SensorReading.IsHeartRateReadingAllowed = true;
                    await BandModel.BandClient.SensorManager.HeartRate.StartReadingsAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            StartTimer();
        }

        private void StartTimer()
        {
            try
            {
                timer = new DispatcherTimer();
                timer.Tick += Timer_Tick;
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();
                Timer_Tick(null, null);
            }
            catch (Exception ex)
            {

            }
        }

        private void Timer_Tick(object sender, object e)
        {
            //throw new NotImplementedException();
            HeartRateTextBlock.Text = (SensorReading.HeartRateReading).ToString();
            HeartRateReadingQualityTextBlock.Text = (SensorReading.HeartRateReadingQuality);
        }

        private void HeartRate_ReadingChanged(object sender, BandSensorReadingEventArgs<IBandHeartRateReading> e)
        {
            //throw new NotImplementedException();
            int val = e.SensorReading.HeartRate;
            SensorReading.HeartRateReading = e.SensorReading.HeartRate;
            HeartRateQuality hrq = e.SensorReading.Quality;
            SensorReading.HeartRateReadingQuality = (e.SensorReading.Quality).ToString();
            //HeartRateTextBlock.Text = (SensorReading.HeartRateReading).ToString();
            DateTimeOffset dto = e.SensorReading.Timestamp;
        }
    }
}
