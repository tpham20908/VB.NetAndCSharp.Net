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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EFPeopleAgain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PeopleDbContext ctx = new PeopleDbContext();
        public MainWindow()
        {
            InitializeComponent();
            RefreshPeopleList();
        }

        private void RefreshPeopleList()
        {
            List<Person> peopleList = new List<Person>();
            var people = (from p in ctx.People select p).ToList();
            foreach (Person p in people)
            {
                peopleList.Add(p);
            }
            lbPeople.ItemsSource = peopleList;
        }

        private void resetFields()
        {
            lblId.Content = "...";
            tbName.Text = "";
            tbAge.Text = "";
            slHeight.Value = 70;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            int age = int.Parse(tbAge.Text);
            double height = slHeight.Value;

            Person p = new Person() { Name = name, Age = age, Height = height };
            ctx.People.Add(p);
            ctx.SaveChanges();

            RefreshPeopleList();
            resetFields();
        }

        private void lbPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person p = (Person) lbPeople.SelectedItem;
            if (p == null)
            {
                return;
            }
            lblId.Content = p.Id;
            tbName.Text = p.Name;
            tbAge.Text = p.Age + "";
            slHeight.Value = p.Height;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Person p = (Person)lbPeople.SelectedItem;
            if (p == null)
            {
                return;
            }
            p.Name = tbName.Text;
            p.Age = int.Parse(tbAge.Text);
            p.Height = slHeight.Value;

            ctx.SaveChanges();
            RefreshPeopleList();
            resetFields();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Person p = (Person)lbPeople.SelectedItem;
            if (p == null)
            {
                return;
            }
            ctx.People.Remove(p);
            ctx.SaveChanges();
            RefreshPeopleList();
            resetFields();
        }

        private void slHeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slHeight.Value = Math.Round(slHeight.Value);
        }
    }
}
