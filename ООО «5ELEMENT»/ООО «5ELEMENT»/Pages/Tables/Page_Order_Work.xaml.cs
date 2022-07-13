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
namespace ООО__5ELEMENT_.Pages.Tables
{
    /// <summary>
    /// Логика взаимодействия для Page_Order_Work.xaml
    /// </summary>
    public partial class Page_Order_Work : Page
    {
        public Page_Order_Work()
        {
            InitializeComponent();
            CartUpdate();

            TextBlock_Button_Confirm_Text.Text = "Подтвердить заказ\nСтоимость заказа: " + Class_Cart.OrderTotalCost + " (Руб.)";
        }
        DataTable Cart = new DataTable();
        public void CartUpdate()
        {
            SqlDataAdapter Adapter = new SqlDataAdapter(Class_Cart.CartQuery, Class_Constant_Data.Connection);
            Adapter.Fill(Cart);
            DataGrid_Cart.ItemsSource = Cart.DefaultView;

            TextBlock_Button_Confirm_Text.Text = "Подтвердить заказ\nСтоимость заказа: " + Class_Cart.OrderTotalCost + " (Руб.)";
        }
        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            Class_Cart.CartQuery = "SELECT DishID AS [№ блюда], [DishName] AS [Название], DishCost AS [Стоимость (Руб.)] FROM DishesView WHERE [DishID] LIKE '' ";
            Class_Cart.OrderTotalCost = 0;
            Cart.Rows.Clear();
            CartUpdate();
        }

        private void Button_Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите подтвердить заказ?", "Подтверждение заказа", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Class_Constant_Data.Connection.Open();

                SqlCommand OrderCreate = new SqlCommand("INSERT INTO Orders (OrderTable, OrderDate) VALUES (" + Class_Current_Table.ID + ", '" + DateTime.Now.ToShortDateString() + "')", Class_Constant_Data.Connection);
                OrderCreate.ExecuteNonQuery();

                DataTable OrderID = new DataTable();
                SqlDataAdapter Adapter = new SqlDataAdapter("SELECT OrderID FROM Orders", Class_Constant_Data.Connection);
                Adapter.Fill(OrderID);


                for (int i = 0; i < Cart.Rows.Count; i++)
                {
                    SqlCommand AddDishToOrder = new SqlCommand("INSERT INTO OrderTablePart (DishID, OrderID, DishQuantity) VALUES (" + Cart.Rows[i][0] + ", " + OrderID.Rows[OrderID.Rows.Count - 1][0] + ", " + Class_Cart.Quantities.Rows[i][0] + ")", Class_Constant_Data.Connection);
                    AddDishToOrder.ExecuteNonQuery();
                    DataTable Ingridients = new DataTable();
                    SqlDataAdapter AdapterI = new SqlDataAdapter("SELECT IngridientID, IngridientQuantity FROM DishTablePart WHERE DishID = " + Cart.Rows[i][0], Class_Constant_Data.Connection);
                    AdapterI.Fill(Ingridients);

                    for (int j = 0; j < Ingridients.Rows.Count; j++)
                    {
                        try
                        {
                            SqlCommand UpdateIngridients = new SqlCommand("UPDATE Ingridients SET IngridientQuantity -= " + Convert.ToInt32(Ingridients.Rows[j][1]) * Convert.ToInt32(Class_Cart.Quantities.Rows[i][0]) + " WHERE IngridientID = " + Ingridients.Rows[i][0], Class_Constant_Data.Connection);
                            UpdateIngridients.ExecuteNonQuery();
                        }
                        catch { }
                    }
                }

                Class_Constant_Data.Connection.Close();

                MessageBox.Show("Заказ успешно совершён!");
            }
            Class_Cart.OrderTotalCost = 0;
            Class_Cart.CartQuery = "SELECT DishID AS [№ блюда], [DishName] AS [Название], DishCost AS [Стоимость (Руб.)] FROM DishesView WHERE [DishID] LIKE '' ";
            Cart.Rows.Clear();
            CartUpdate();
        }
    }
}
