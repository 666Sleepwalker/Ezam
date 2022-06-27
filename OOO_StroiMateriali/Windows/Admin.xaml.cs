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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private User user = Store.user;
        public Admin()
        {
            InitializeComponent();

            fioElem.Content = $"{user.UserSurname} {user.UserName} {user.UserPatronymic}";

            productListElem.ItemsSource = Healpers.connection.Product.ToList();
        }

        //Удалить
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = (Product)productListElem.SelectedItem;

            if (product == null)
            {
                MessageBox.Show("Вы не выбрали товар, который хотите удалить");
                return;
            }

            Healpers.connection.Product.Remove(product);
            Healpers.connection.SaveChanges();

            productListElem.ItemsSource = Healpers.connection.Product.ToList();
        }

        //Добавить
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new AddProduct().Show();
            Close();
        }

        //Редактировать
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Product product = (Product)productListElem.SelectedItem;

            if (product == null)
            {
                MessageBox.Show("Вы не выбрали продукт, который хотите редактировать");
                return;
            }

            new EditProduct(product).Show();
            Close();
        }

        //Выйти
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
