using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for ErrorWindow.xaml
    /// </summary>
    public partial class ErrorWindow : Window
    {
        private ErrorModel _errors { get; set; }
        public ErrorWindow(ErrorModel model)
        {
            InitializeComponent();

            this.DataContext = model;
            _errors = model;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<ErrorWindowModel> models = new List<ErrorWindowModel>();

            models = _errors.Errors.GetAll().Select(x => new ErrorWindowModel { 
                Error = x
            }).ToList();
            
            this.dgError.ItemsSource = models;
        }
    }
}
