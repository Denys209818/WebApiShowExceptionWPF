using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.ErrorService.Models;

namespace WPF.ErrorService
{
    /// <summary>
    /// Interaction logic for RefWindow.xaml
    /// </summary>
    public partial class RefWindow : Window
    {
        public RefWindowModel _model { get; set; }
        public RefWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _model = new RefWindowModel();
            this.DataContext = _model;
        }
    }
}
