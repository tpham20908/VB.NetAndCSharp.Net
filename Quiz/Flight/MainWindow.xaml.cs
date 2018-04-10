using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace Flight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
            try
            {
                Global.ctx = new FlightDbContext();
                refreshFlight();
            }
            catch (System.IO.InvalidDataException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void refreshFlight()
        {
            List<Flightt> flightList = new List<Flightt>();
            var flights = (from f in Global.ctx.Flights select f).ToList();
            foreach (Flightt f in flights)
            {
                flightList.Add(f);
            }
            lbFlights.ItemsSource = flightList;
            lblInfo.Content = string.Format("Total Flights: {0}", Global.ctx.Flights.Count());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DlgAddEdit dlg = new DlgAddEdit(null);
            if (dlg.ShowDialog() == true)
            {
                refreshFlight();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void miDelete_Click(object sender, RoutedEventArgs e)
        {
            Flightt f = (Flightt)lbFlights.SelectedItem;
            if (f == null)
            {
                return;
            }
            Global.ctx.Flights.Remove(f);
            Global.ctx.SaveChanges();
            refreshFlight();
        }

        private void miUpdate_Click(object sender, RoutedEventArgs e)
        {
            Flightt f = (Flightt)lbFlights.SelectedItem;
            if (f == null)
            {
                return;
            }
            DlgAddEdit dlg = new DlgAddEdit(f);
            if (dlg.ShowDialog() == true)
            {
                refreshFlight();
            }
        }

        private void miSave_Click(object sender, RoutedEventArgs e)
        {
            Flightt f = (Flightt)lbFlights.SelectedItem;
            if (f == null)
            {
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string content = string.Format("{0}", f);
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, content);
        }
    }
}
