using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOO_StroiMateriali
{
    public class Healpers
    {
        public static Connection connection = new Connection();

        //Авторизация
        public static User Auth(string login, string password)
        {
            User user = connection.User.FirstOrDefault(x => x.UserLogin == login);

            if (user == null)
            {
                MessageBox.Show("Пользователь не найден");
                return null;
            }

            if (user.UserPassword != password)
            {
                MessageBox.Show("Пароли не совпадают");
                return null;
            }

            return user;
        }

        //Добавление товара
        public static bool AddProducts(string articul, string naimenovanie, string opisanie, string categoria, string proizvoditel, int cena, int skidka, int ostatoc)
        {
            Product currentProduct = connection.Product.FirstOrDefault(x => x.ProductArticleNumber == articul);

            if (currentProduct != null)
            {
                MessageBox.Show("Товар с таким артикулом уже существует");
                return false;
            }

            Product product = new Product();
            product.ProductArticleNumber = articul;
            product.ProductName = naimenovanie;
            product.ProductDescription = opisanie;
            product.ProductCategory = categoria;
            product.ProductManufacturer = proizvoditel;
            product.ProductCost = cena;
            product.ProductDiscountAmount = skidka;
            product.ProductQuantityInStock = ostatoc;

            connection.Product.Add(product);
            connection.SaveChanges();

            return true;
        }
        //Редактирование товара
        public static bool EditProducts(string articul, string naimenovanie, string opisanie, string categoria, string proizvoditel, int cena, int skidka, int ostatoc)
        {
            Product product = connection.Product.FirstOrDefault(x => x.ProductArticleNumber == articul);


            product.ProductArticleNumber = articul;
            product.ProductName = naimenovanie;
            product.ProductDescription = opisanie;
            product.ProductCategory = categoria;
            product.ProductManufacturer = proizvoditel;
            product.ProductCost = cena;
            product.ProductDiscountAmount = skidka;
            product.ProductQuantityInStock = ostatoc;

            connection.SaveChanges();

            return true;
        }
    }
}
