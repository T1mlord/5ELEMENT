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
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ООО__5ELEMENT_.Classes;

namespace ООО__5ELEMENT_.Resources.SystemResources
{
    /// <summary>
    /// Логика взаимодействия для DishViewTemplate.xaml
    /// </summary>
    public partial class DishViewTemplate : UserControl
    {
        string ID;
        public DishViewTemplate(string ID)
        {
            InitializeComponent();

            DataTable Dish = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM DishesView WHERE DishID = " + ID, Class_Constant_Data.Connection);
            Adapter.Fill(Dish);

            TextBlock_Type.Text = "" + Dish.Rows[0][1];
            TextBlock_Name.Text = "" + Dish.Rows[0][2];
            TextBlock_Cost.Text = "Стоимость: " + Dish.Rows[0][3] + " (Руб.)";
            TextBlock_Quantity.Text = "Количество: " + Dish.Rows[0][4] + " (Шт.)";
            TextBlock_Description.Text = "Описание блюда:\n" + Dish.Rows[0][5];

            byte[] Image = (byte[])Dish.Rows[0][6];
            Image_Dish.Source = BitmapFrame.Create(new MemoryStream(Image), BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

            this.ID = ID;
        }
        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Class_Frame_Manager.Admin_Template_Work.Navigate(new Pages.Employees.Admin.Dishes.Page_Dish_Work(ID));
        }

        private void Button_Ingridients_Click(object sender, RoutedEventArgs e)
        {
            Class_Current_User.CurrentPage = "Состав блюда " + TextBlock_Name.Text;

            Class_Current_Dish.ID = ID;

            Class_Frame_Manager.Admin_MainMenu_Frame.Navigate(new Pages.Employees.Admin.Dishes.Page_Dish_Ingridients());
        }
    }
}
