using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WebApp.Model;
using WPFSignalRClient.Common;
using WPFSignalRClient.Services;

namespace WPFSignalRClient.ViewModel
{
    public class MsgPayementViewModel : ViewModelBase
    {

        //public Brush ColorBrush
        //{
        //    get
        //    {
        //        try
        //        {
        //            return new SolidColorBrush(Color.FromRgb(
        //                ColorChatColor.Red,
        //                ColorChatColor.Green,
        //                ColorChatColor.Blue));
        //        }
        //        catch (FormatException)
        //        {
        //            return new SolidColorBrush(Colors.Black);
        //        }
        //    }
        //}
        public float number
        {
            get
            {
                return Payement.Montant;
            }
        }
        public Guid idPayement
        {
            get
            {
                return Payement.IdPayement;
            }
        }
        public DateTime datePayement
        {
            get
            {
                return Payement.DatePayement;
            }
        }

        public Payement Payement { get; set; }
        public MsgPayementViewModel(Payement payement)
        {
            Payement = payement;
        }
    }
}
