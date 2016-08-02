using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band;

namespace RealtimeBand.Model
{
    public class BandModel : ViewModel
    {
        private static IBandInfo _selectedBand;
        public static IBandInfo SelectedBand
        {
            get { return BandModel._selectedBand; }
            set { BandModel._selectedBand = value; }
        }

        private static IBandClient _bandClient;
        public static IBandClient BandClient
        {
            get { return _bandClient; }
            set { _bandClient = value; }
        }

        public static bool IsConnected
        {
            get
            {
                return (BandClient != null);
            }
        }

        public static async Task FindDevicesAsync()
        {
            var bands = await BandClientManager.Instance.GetBandsAsync();
            if (bands != null && bands.Length > 0)
            {
                SelectedBand = bands[0];
            }
        }

        public static async Task initAsync()
        {
            try
            {
                if (IsConnected)
                    return;

                await FindDevicesAsync();
                if (SelectedBand != null)
                {
                    BandClient = await BandClientManager.Instance.ConnectAsync(SelectedBand);
                    await BandModel.BandClient.NotificationManager.VibrateAsync(Microsoft.Band.Notifications.VibrationType.RampUp);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
