using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace XamlWorkshop.ViewModel
{
    public class CuriousClass
    {
        private IMessageService _service;
        private IObserved _observed;

        public CuriousClass(IMessageService service, IObserved observed )
        {
            _service = service;
            _observed = observed;

            WeakEventManager<IObserved, AncientEventArgs>.AddHandler(observed, nameof(IObserved.AncientOne), this.ThereIsAnAncientOne);
        }

        public void ThereIsAnAncientOne(object sender, AncientEventArgs e)
        {
            _service.ShowWhatever("We have a dino");
        }
    }
}
