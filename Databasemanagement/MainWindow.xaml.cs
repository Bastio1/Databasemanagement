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

namespace Databasemanagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var db = new AdventureWorksEntities();

            var query = from p in db.Products
                        select p;

            var results = query.ToList();

            dg.ItemsSource = results;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var db = new AdventureWorksEntities();
            var query = from c in db.ProductCategories
                        select c;

            var results = query.ToList();

            dg.ItemsSource = results;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var db = new AdventureWorksEntities();
            var query = from p in db.Products
                        orderby p.ListPrice descending
                        select p;

            var results = query.ToList();

            dg.ItemsSource = results;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var db = new AdventureWorksEntities();
            var query = from p in db.Products
                     //   where p.Color.Contains("R")
                        select new
                        {
                            p.ProductID,
                            p.Name,
                            p.Color,
                            p.ListPrice
                        };
          //  MessageBox.Show(query.ToString());
            var results = query.ToList();

            dg.ItemsSource = results;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var db = new AdventureWorksEntities();

            var nieuwe = new ProductCategory();
            nieuwe.Name = "This is where the fun begins";
            nieuwe.ModifiedDate = new DateTime(1889,4,20);
            nieuwe.rowguid = Guid.NewGuid();

            db.ProductCategories.Add(nieuwe);

            db.SaveChanges();
        }
    }
}
