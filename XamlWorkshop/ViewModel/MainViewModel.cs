using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace XamlWorkshop.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : MediCommonControls.ViewModel.NotifyErrorViewModelBase
    {
        private int _age;
        private RelayCommand _command;
        private WeakReference<IMainView> _view = new WeakReference<IMainView>(null);
        private string _welcomeTitle = "Hello";
        public MainViewModel(IMainView view)
        {
            _view.SetTarget(view);
            OkCommand = new RelayCommand(OnOkCommand, CanOk);
            CancelCommand = new RelayCommand(OnCancelCommand);
        }

        [Range(1, 100, ErrorMessage = "Attribute")]
        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                if (SetAndValidate(ref _age, value))
                {
                    OkCommand.RaiseCanExecuteChanged();
                    RaisePropertyChanged(nameof(HasAge));
                }
            }
        }

        public RelayCommand CancelCommand { get; set; }

        public bool HasAge
        {
            get
            {
                return Age <= 18;
            }
        }

        public RelayCommand OkCommand
        {
            get
            {
                return _command;
            }

            set
            {
                if (Set(ref _command, value))
                {
                }
            }
        }

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public string WelcomeTitle
        {
            get => _welcomeTitle;
            set { if (Set(ref _welcomeTitle, value)) { } }
        }
        private IMainView View
        {
            get
            {
                IMainView view;
                _view.TryGetTarget(out view);
                return view;
            }
        }

        private bool CanOk()
        {
            return !HasErrors;
        }

        private IMessageService _service;

        public IMessageService Service
        {
            get { return _service ?? (_service = new MessageBoxService()); }
            set { _service = value; }
        }


        private void OnCancelCommand()
        {
            if (Age > 10)
            {
                if (Service.ShowWhatever("Are you sure") == MessageBoxResult.Yes)
                {
                    View.Close();
                }
            }
            else
            {
                View.Close();
            }
        }

        private void OnOkCommand()
        {
            View.Close();
        }
        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}
