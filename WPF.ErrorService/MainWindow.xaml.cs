using App.Lib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.ErrorService.Models;

namespace WPF.ErrorService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<CarModel> _cars { get; set; } = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task AddCar(CarModel model) 
        {
            await Task.Run(() => { 
                try
            {
                WebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:5001/api/cars/add");

                request.Method = "POST";
                request.ContentType = "application/json";
                using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                {
                    sw.Write(JsonConvert.SerializeObject(model));
                }


                WebResponse response = (HttpWebResponse)request.GetResponse();
                
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    string json = sr.ReadToEnd();
                    string result = Encoding.UTF8.GetString(JsonConvert.DeserializeObject<byte[]>(json));
                    MessageBox.Show(result);

                    Dispatcher.Invoke(() => {
                            this.txtMark.Text = "";
                            this.txtModel.Text = "";
                            this.txtImage.Text = "";
                            this.txtCapacity.Text = "";
                            this.txtYear.Text = "";
                        });

                    model.IsNew = false;
                }
            }
            catch (WebException web)
            {
                WebResponse response = (HttpWebResponse)web.Response;

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    string json = sr.ReadToEnd();
                    var errors = JsonConvert.DeserializeObject<ErrorModel>(json);
                        Dispatcher.Invoke(() => { 
                            ErrorWindow window = new ErrorWindow(errors);
                            window.ShowDialog(); 
                        });
                }

            }
            });
        }

        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => {
                Dispatcher.Invoke(async () => { 
                    float res;
                    int intRes;
                    CarModel model = new CarModel
                    {
                        Mark = string.IsNullOrEmpty(this.txtMark.Text) ? string.Empty : this.txtMark.Text,
                        Model = string.IsNullOrEmpty(this.txtModel.Text) ? string.Empty : this.txtModel.Text,
                        Capacity = !float.TryParse(this.txtCapacity.Text, out res) ? -1: float.Parse(this.txtCapacity.Text),
                        Year = !int.TryParse(this.txtYear.Text, out intRes) ? -1 : int.Parse(this.txtYear.Text),
                        Image = string.IsNullOrEmpty(this.txtImage.Text) ? string.Empty : this.txtImage.Text,
                        IsNew = true
                        };

                        await this.AddCar(model);

                    Dispatcher.Invoke(() => {
                        WebClient client = new WebClient();
                        string json = client.DownloadString("https://localhost:5001/api/cars/get");
                        _cars = JsonConvert.DeserializeObject<List<CarModel>>(json);
                        this.dgCars.ItemsSource = _cars;
                    });
                });

                
            });

        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            if (_cars == null) 
            {
                this.dgCars.CanUserAddRows = true;
                WebClient client = new WebClient();
                string json = client.DownloadString("https://localhost:5001/api/cars/get");
                _cars = JsonConvert.DeserializeObject<List<CarModel>>(json);
                this.dgCars.ItemsSource = _cars;
                
                this.dgCars.CellEditEnding += DgCars_CellEditEnding;
                this.dgCars.RowEditEnding += DgCars_RowEditEnding;
                this.dgCars.AddingNewItem += DgCars_AddingNewItem;
            }
        }

        private void DgCars_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            e.NewItem = new CarModel();
            (e.NewItem as CarModel).IsNew = true;
            (e.NewItem as CarModel).Year = -1;
            (e.NewItem as CarModel).Capacity = -1;
        }

        private async void DgCars_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            CarModel car = e.Row.Item as CarModel;
            if(car.IsNew)
            await AddCar(car);
        }

        private void DgCars_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CarModel model = e.EditingElement.DataContext as CarModel;
            if (e.Column.DisplayIndex == 0) 
            {
                RefWindow window = new RefWindow();
                window.ShowDialog();

                if(!string.IsNullOrEmpty(window._model.link))
                    model.Image = window._model.link;
            }

            
        }

    }
}
