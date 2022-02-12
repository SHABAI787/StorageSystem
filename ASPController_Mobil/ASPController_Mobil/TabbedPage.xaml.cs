using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ASPController_Mobil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : Xamarin.Forms.TabbedPage
    {
        public List<Product> ProductsSourse { get; set; }
        private List<Product> productBase { get; set; }
        private ListView listView { get; set; }


        public TabbedPage1()
        {
            InitializeComponent();
            Load();
        }

        private async void Load()
        {
            productBase = await Product.GetProducts();
            SetItems(productBase);
        }

        private void SetItems(List<Product> products)
        {
            ProductsSourse = new List<Product>(products);
            if(listView != null)
                this.StackL.Children.Remove(listView);

            listView = new ListView
            {
                HasUnevenRows = true,
                // Определяем источник данных
                ItemsSource = ProductsSourse,
                Margin = new Thickness(10, 0),
                // Определяем формат отображения данных
                ItemTemplate = new DataTemplate(() =>
                {
                    // привязка к свойству Name
                    Label titleLabel = new Label { FontSize = 18 };
                    titleLabel.SetBinding(Label.TextProperty, "Name");

                    // привязка к свойству State
                    Label companyLabel = new Label();
                    companyLabel.SetBinding(Label.TextProperty, "State");

                    // привязка к свойству Price
                    Label priceLabel = new Label();
                    priceLabel.SetBinding(Label.TextProperty, "Price");

                    // создаем объект ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Vertical,
                            Children = { titleLabel, companyLabel, priceLabel }
                        }
                    };
                })
            };
            listView.ItemTapped += ListView_ItemTapped;
            this.StackL.Children.Add(listView);
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Product product = e.Item as Product;
            if (product == null)
                return;

            if (product.State.Id == 2)// В наличии
            {
                if(await DisplayAlert("Подтвердить действие", "Забронировать данный товар?", "Да", "Нет"))
                    await DisplayAlert("Уведомление", "Делаем бронь", "OK");
            }

            if (product.State.Id == 1)
            {
                if (await DisplayAlert("Подтвердить действие", "Товара нет в наличии, оформить заказ?", "Да", "Нет"))
                    await DisplayAlert("Уведомление", "Оформляем заказ", "OK");
            }
            
        }

        private void SearchB_SearchButtonPressed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SearchB.Text))
                SetItems(productBase);
            else
                SetItems(productBase.FindAll(i => i.Name.ToUpper().Contains(SearchB.Text.ToUpper())));
        }

        private void SearchB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(SearchB.Text))
                SetItems(productBase);
            else
                SetItems(productBase.FindAll(i => i.Name.ToUpper().Contains(SearchB.Text.ToUpper())));
        }
    }

    /// <summary>
    /// Товар
    /// </summary>
    [Serializable]
    public class Product
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Стоимость")]
        public decimal Price { get; set; }

        [DisplayName("Состояние")]
        [ReadOnly(true)]
        public virtual ProductState State { get; set; }

        [DisplayName("Склад")]
        [ReadOnly(true)]
        public virtual Store Store { get; set; }

        [DisplayName("Поставщик")]
        [ReadOnly(true)]
        public virtual Provider Provider { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        /// <summary>
        /// Получить товар с сервера
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Product>> GetProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                string JSONData = await Task.Run(() => JsonConvert.SerializeObject("testData"));
                WebRequest request = WebRequest.Create($"{Authorization.URL}/Home/GetProducts");
                request.Method = "POST";
                string query = $"data={JSONData}";
                byte[] byteMsg = Encoding.UTF8.GetBytes(query);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteMsg.Length;

                using (Stream stream = await request.GetRequestStreamAsync())
                {
                    await stream.WriteAsync(byteMsg, 0, byteMsg.Length);
                }

                WebResponse response = await request.GetResponseAsync();

                string answer = null;

                using (Stream s = response.GetResponseStream())
                {
                    using (StreamReader sR = new StreamReader(s))
                    {
                        answer = await sR.ReadToEndAsync();
                    }
                }

                response.Close();
                var result = await Task.Run(() => JsonConvert.DeserializeObject<(List<Product> Products, string Error)>(answer));

                if (string.IsNullOrEmpty(result.Error))
                {
                    products = result.Products;
                }

            }
            catch (Exception ex)
            {

            }

            return products;
        }
    }

    [Serializable]
    public class ProductState
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    [Serializable]
    public class Store
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }
    }

    [Serializable]
    public class Provider
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Ответственный")]
        public virtual Person Responsible { get; set; }
    }

    [Serializable]
    public class Person
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [DisplayName("Имя")]
        public string Name { get; set; }

        [DisplayName("Отчество")]
        public string MiddleName { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime? DataBirth { get; set; }

        [DisplayName("Электронная почта")]
        public string Email { get; set; }

        [DisplayName("Номер телефона")]
        public string PhoneNumber { get; set; }

        [DisplayName("Должность")]
        [ReadOnly(true)]
        public virtual Post Post { get; set; }
    }

    public class Post
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }
    }
}