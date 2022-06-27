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

namespace OOO_StroiMateriali
{
    /// <summary>
    /// Логика взаимодействия для Manager_Client.xaml
    /// </summary>
    public partial class Manager_Client : Window
    {
        private User user = Store.user;
        public Manager_Client()
        {
            InitializeComponent();

            fioElem.Content = $"{user.UserSurname} {user.UserName} {user.UserPatronymic}";

            productListElem.ItemsSource = Healpers.connection.Product.ToList();

            List<string> manufacturer = new List<string>();

            manufacturer.Add("Все производители");
            manufacturer.AddRange(Healpers.connection.Product.Select(x => x.ProductManufacturer).Distinct().ToList());

            filtrElem.ItemsSource = manufacturer;

        }

        //Выйти
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        //Поиск
        private void findElem_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Product> products = Healpers.connection.Product.Where(x => x.ProductName.Contains(findElem.Text)).ToList();

            productListElem.ItemsSource = products;
        }

        //Фильтрация
        private void filtrElem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string manufacturer = filtrElem.SelectedItem.ToString();

            List<Product> products = new List<Product>();

            if(manufacturer=="Все производители")
            {
                products = Healpers.connection.Product.ToList();
            }

            else
            {
                products = Healpers.connection.Product.Where(x => x.ProductManufacturer == manufacturer).ToList();
            }

            productListElem.ItemsSource = products;
        }
    }
}
