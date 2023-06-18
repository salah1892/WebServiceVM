using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WebApp.Model;
using WPFSignalRClient.Common;
using WPFSignalRClient.HubSevice;
using WPFSignalRClient.Services;
using WPFSignalRClient.SignalRService;

namespace WPFSignalRClient.ViewModel
{
    public class PayementViewModel : ViewModelBase
    {
        public readonly ISignalRPayementService _signalRPayementService;
        public readonly HubConnection hubConnection;
        //public readonly HubCon hubCon;
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }
        private Guid idpayement;

        public Guid IdPayement
        {
            get { return idpayement; }
            set { idpayement = value; OnPropertyChanged(); }
        }
        private DateTime datePayement;

        public DateTime DatePayement
        {
            get { return datePayement; }
            set { datePayement = value; OnPropertyChanged(); }
        }
        private float montant;

        public float Montant
        {
            get { return montant; }
            set { montant = value; OnPropertyChanged(); }
        }
        public ObservableCollection<MsgPayementViewModel> Messages { get; }
        public RelayCommand SendToServeur { get; set; }
        public RelayCommand SendToOther { get; set; }
        public PayementViewModel(INavigationService navigationService, ISignalRPayementService signalRPayementService)
        {
            Messages = new ObservableCollection<MsgPayementViewModel>();
            //hubConnection = hub;
            // _signalRPayementService =  new SignalRPayementService(hub);
            _navigation = navigationService;
            SendToServeur = new RelayCommand(async o =>
            {
                //signalRPayementService = new SignalRPayementService(hub);
                //await new SignalRPayementService()
                await signalRPayementService
                 .SendPayementMsg(
                     new Payement(IdPayement, DatePayement, Montant));
            }, o => true);
            //SendToOther = new RelayCommand(o => { Navigation.NavigateTo<OtherViewModel>(); }, o => true);
            //SendToOther = new RelayCommand(o => { var hub=newPa }, o => true);
            signalRPayementService.PayementMsgReceived += SignalRPayementService_PayementMsgReceived;
        }
        ISignalRPayementService signalRPayementService { get; }
        private void SignalRPayementService_PayementMsgReceived(Payement payement)
        {

            var dispatcher = Application.Current.Dispatcher;
            dispatcher.Invoke(() =>
            {
                Messages.Add(new MsgPayementViewModel(payement));
            });

        }

    }
}
