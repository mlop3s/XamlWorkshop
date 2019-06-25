using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace XamlWorkshop.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : MediCommonControls.ViewModel.NotifyErrorViewModelBase, IObserved
    {
        private int _age;
        private RelayCommand _command;
        private WeakReference<IMainView> _view = new WeakReference<IMainView>(null);
        private string _welcomeTitle = "Hello";

        public ObservableCollection<Person> People
        {
            get;
        } = new ObservableCollection<Person>();


        public MainViewModel(IMainView view)
        {
            _view.SetTarget(view);
            OkCommand = new RelayCommand(OnOkCommand, CanOk);
            CancelCommand = new RelayCommand(OnCancelCommand);
            Curious = new CuriousClass(Service, this);
            _goCommand = new RelayCommand(DoGo);

            People.Add(new Person
            {
                Name = "John Doe",
                Age = 43,
                Job = "Getting cans",
                Color = Colors.Purple,
                Birth = new DateTime(1976, 12, 12)
            });

            People.Add(new Person
            {
                Name = "Jane Doe",
                Age = 33,
                Job = "Helping people",
                Color = Colors.Red,
                Birth = new DateTime(1986, 11, 11)
            });
        }

        private void DoGo()
        {
            MessageBox.Show("Go called");
        }

        /// <summary>
        /// Fires if age > 50
        /// </summary>
        public event EventHandler<AncientEventArgs> AncientOne;

        private void FireAncientOneEvent(int value)
        {
            AncientOne?.Invoke(this, new AncientEventArgs
            {
                Age = value,
                Name = "Fritzle"
            });
        }

        private RelayCommand _goCommand;

        public RelayCommand Go
        {
            get
            {
                return _goCommand;
            }

            set
            {
                Set(ref _goCommand, value);
            }
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
                    if (value > 50)
                    {
                        FireAncientOneEvent(value);
                    }
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

        public CuriousClass Curious { get; set; }


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
