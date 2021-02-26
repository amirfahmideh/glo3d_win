using glo3d_win.DTO;
using glo3d_win.Firebase.Database;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace glo3d_win
{
    /// <summary>
    /// Interaction logic for SampleData.xaml
    /// </summary>
    public partial class SampleData : Page
    {
        public SampleData()
        {
            InitializeComponent();
            GetAllData();
        }
        private async void GetAllData()
        {
            try
            {
                QueryHelper qHelper = new QueryHelper("cars");
                var allItems = await qHelper.Items<CarDTO>();

                List<CarDTO> listOfCars = new List<CarDTO>();
                foreach (var item in allItems)
                {
                    listOfCars.Add(item.Object);
                }

                CarsDataGrid.AutoGenerateColumns = true;
                CarsDataGrid.ItemsSource = listOfCars;
            }
            catch (Exception e) {
                Console.Write(e.Message);
            }
        }
    }
  
}
