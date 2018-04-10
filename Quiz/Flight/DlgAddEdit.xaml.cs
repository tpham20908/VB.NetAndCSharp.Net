using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Flight
{
    /// <summary>
    /// Interaction logic for DlgAddEdit.xaml
    /// </summary>
    public partial class DlgAddEdit : Window
    {
        private Flightt currentFlight;
        public DlgAddEdit(Flightt f)
        {
            currentFlight = f;
            InitializeComponent();
            if (currentFlight == null)
            {
                btnSave.Content = "Add new";
            }
            else
            {
                lblId.Content = f.Id;
                dtpkOnDay.SelectedDate = f.OnDay;
                tbFromCode.Text = f.FromCode;
                tbToCode.Text = f.ToCode;
                cbbxType.SelectedItem = f.Type;
                slPassengers.Value = f.Passengers;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbFromCode.Text.Equals("") && tbToCode.Equals("") && dtpkOnDay.SelectedDate.Equals(""))
            {
                MessageBox.Show("Please enter infomation to add");
                return;
            }
            else
            {
                Flightt f = currentFlight == null ? new Flightt() : currentFlight;
                DateTime onDay = (DateTime)dtpkOnDay.SelectedDate;
                string fromCode = tbFromCode.Text;
                string toCode = tbToCode.Text;
                //FlyingType type = (FlyingType) cbbxType.SelectedItem;
                string type = cbbxType.Text;
                int passengers = (int)slPassengers.Value;
                try
                {
                    f.OnDay = onDay;
                    f.FromCode = fromCode;
                    f.ToCode = toCode;
                    f.Type = type;
                    f.Passengers = passengers;
                    if (btnSave.Content.Equals("Add new"))
                    {
                        Global.ctx.Flights.Add(f);
                    }

                    Global.ctx.SaveChanges();
                }
                catch (System.IO.InvalidDataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                DialogResult = true;
            }
        }

        private void slPassengers_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slPassengers.Value = (int)Math.Round(slPassengers.Value);
        }
    }
}
