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
            List<string> peopleList = new List<string>();
            var people = (from p in ctx.People select p).ToList();
            foreach (Person p in people)
            {
                peopleList.Add(p.ToString());
            }
            lbPeople.ItemsSource = peopleList;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            int age = int.Parse(tbAge.Text);
            double height = slHeight.Value;

            Person p = new Person() { Name = name, Age = age, Height = height };
            using (ctx)
            {
                ctx.People.Add(p);
                ctx.SaveChanges();
            }

            RefreshPeopleList();
        }
    }
}
