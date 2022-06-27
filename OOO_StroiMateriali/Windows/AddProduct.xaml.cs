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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        Connection connection = new Connection();
        public AddProduct()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ComboBoxItem categoriaItem = (ComboBoxItem)categoryElem.SelectedItem;
            string categoria = categoriaItem.Content.ToString();
            int cena = int.Parse(costElem.Text);
            int skidka = int.Parse(discountElem.Text);
            int ostatoc = int.Parse(quantityElem.Text);

            bool result = Healpers.AddProducts(articleElem.Text, nameElem.Text, descriptionElem.Text, categoria, manufacturerElem.Text, cena, skidka, ostatoc);

            if (result == true)
            {
                new Admin().Show();
                Close();
            }

        }
    }
}
