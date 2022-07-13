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
using System.Data.SqlClient;
using ООО__5ELEMENT_.Classes;
using ООО__5ELEMENT_.Pages.Tables;

namespace ООО__5ELEMENT_.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window_Table.xaml
    /// </summary>
    public partial class Window_Table : Window
    {
        public Window_Table()
        {
            InitializeComponent();

            this.Title = "Стол " + Class_Current_Table.ID;

            Frame_Menu.Navigate(new Page_Menu());

            Class_Frame_Manager.Cart_Frame = this.Frame_Order_Work;

            Frame_Order_Work.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            Frame_Order_Work.Navigate(new Page_Order_Work());
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Class_Constant_Data.Connection.Open();

            SqlCommand TableStatusChanger = new SqlCommand("UPDATE Tables SET TableStatus = 2 WHERE TableID = " + Class_Current_Table.ID, Class_Constant_Data.Connection);
            TableStatusChanger.ExecuteNonQuery();

            Class_Constant_Data.Connection.Close();
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
