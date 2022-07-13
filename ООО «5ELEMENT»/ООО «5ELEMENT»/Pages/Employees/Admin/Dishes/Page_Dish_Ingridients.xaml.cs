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
using ООО__5ELEMENT_.Classes;
using System.Data;
using System.Data.SqlClient;

namespace ООО__5ELEMENT_.Pages.Employees.Admin.Dishes
{
    /// <summary>
    /// Логика взаимодействия для Page_Dish_Ingridients.xaml
    /// </summary>
    public partial class Page_Dish_Ingridients : Page
    {
        DataTable Table = new DataTable();
        public Page_Dish_Ingridients()
        {
            InitializeComponent();

            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM Ingridients", Class_Constant_Data.Connection);
            Adapter.Fill(Table);

            for (int i = 0; i < Table.Rows.Count; i++)
            {
                StackPanel_Ingridients.Children.Add(new Resources.SystemResources.IngridientTemplate(Table.Rows[i][0].ToString()));
            }

            Table = new DataTable();
            Adapter = new SqlDataAdapter(Class_DishIngridient.IngridientsQuery, Class_Constant_Data.Connection);
            Adapter.Fill(Table);
            DataGrid_TablePart.ItemsSource = Table.DefaultView;
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            Class_Frame_Manager.Admin_MainMenu_Frame.Navigate(new Page_Dish_Ingridients());
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            Class_DishIngridient.IngridientsQuery = "SELECT IngridientID AS [№ блюда], IngridientName AS [Название] FROM Ingridients WHERE [IngridientID] LIKE '' ";
            Class_DishIngridient.Quantities.Rows.Clear();

            Class_Frame_Manager.Admin_MainMenu_Frame.Navigate(new Page_Dish_Ingridients());
        }

        private void Button_Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите задать состав?", "Подтверждение состава", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Class_Constant_Data.Connection.Open();
                SqlCommand Drop = new SqlCommand("DELETE FROM DishTablePart WHERE DishID = " + Class_Current_Dish.ID, Class_Constant_Data.Connection);
                Drop.ExecuteNonQuery();

                for (int i = 0; i < Table.Rows.Count; i++)
                {
                    SqlCommand AddDishToOrder = new SqlCommand("INSERT INTO DishTablePart (DishID, IngridientID, IngridientQuantity) VALUES (" + Class_Current_Dish.ID + ", " + Table.Rows[i][0] + ", " + Class_DishIngridient.Quantities.Rows[i][0] + ")", Class_Constant_Data.Connection);
                    AddDishToOrder.ExecuteNonQuery();
                }

                Class_Constant_Data.Connection.Close();

                MessageBox.Show("Состав успешно задан!");
            }

            Class_DishIngridient.IngridientsQuery = "SELECT IngridientID AS [№ блюда], IngridientName AS [Название] FROM Ingridients WHERE [IngridientID] LIKE '' ";
            Class_DishIngridient.Quantities.Rows.Clear();
            Classes.Class_Current_User.CurrentPage = "Меню";
            Class_Frame_Manager.Admin_MainMenu_Frame.Navigate(new MainMenu.Page_MainMenu());
        }
    }
}
