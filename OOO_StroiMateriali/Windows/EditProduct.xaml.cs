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
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        public Connection connection = new Connection();
        public Product product = null;
        public EditProduct(Product _product)
        {
            InitializeComponent();

            product = _product;

            articleElem.Text = _product.ProductArticleNumber;
            nameElem.Text = _product.ProductName;
            descriptionElem.Text = _product.ProductDescription;
            categoryElem.SelectedItem = _product.ProductCategory;
            manufacturerElem.Text = _product.ProductManufacturer;
            costElem.Text = _product.ProductCost.ToString();
            discountElem.Text = _product.ProductDiscountAmount.ToString();
            quantityElem.Text = _product.ProductQuantityInStock.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem categoriaItem = (ComboBoxItem)categoryElem.SelectedItem;
            string categoria = categoriaItem.Content.ToString();
            int cena = int.Parse(costElem.Text);
            int skidka = int.Parse(discountElem.Text);
            int ostatoc = int.Parse(quantityElem.Text);

            bool result = Healpers.EditProducts(articleElem.Text, nameElem.Text, descriptionElem.Text, categoria, manufacturerElem.Text, cena, skidka, ostatoc);

            if (result == true)
            {
                new Admin().Show();
                Close();
            }
        }
    }
}
