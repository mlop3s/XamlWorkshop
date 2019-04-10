
using System;
using System.ComponentModel;
using System.Windows;
using MediCommonControls.Interface;
using XamlWorkshop.ViewModel;

namespace XamlWorkshop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainView
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = new MainViewModel(this);
            }
            else
            {
                DataContext = new Design.MainViewDesignData();
            }
        }

    }
}
