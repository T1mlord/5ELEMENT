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
using ООО__5ELEMENT_.Pages;
using ООО__5ELEMENT_.Windows;
using System.Data.SqlClient;
using System.Data;

namespace ООО__5ELEMENT_.Pages.Authorization
{
    /// <summary>
    /// Логика взаимодействия для Page_Authorization_Table.xaml
    /// </summary>
    public partial class Page_Authorization_Table : Page
    {
        public Page_Authorization_Table()
        {
            InitializeComponent();
        }

        private void Button_ChangePage_Click(object sender, RoutedEventArgs e)
        {
            Class_Frame_Manager.Authorization_Frame.Navigate(new Page_Authorization_User());
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Login.Text.Length != 0)
            {
                DataTable Table = new DataTable();
                SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM TablesView WHERE TableID = " + TextBox_Login.Text, Class_Constant_Data.Connection);
                Adapter.Fill(Table);

                if (Table.Rows.Count != 0)
                {
                    if (Table.Rows[0][1].ToString() == "Деавторизован")
                    {
                        Class_Constant_Data.Connection.Open();

                        SqlCommand TableStatusChanger = new SqlCommand("UPDATE Tables SET TableStatus = 1 WHERE TableID = " + TextBox_Login.Text, Class_Constant_Data.Connection);
                        TableStatusChanger.ExecuteNonQuery();

                        Class_Constant_Data.Connection.Close();

                        Class_Current_Table.ID = TextBox_Login.Text;

                        Window_Table Window = new Window_Table();
                        Window.Show();
                    }
                    else if (Table.Rows[0][1].ToString() == "Авторизован")
                        MessageBox.Show("Стол с таким номером уже авторизирован!");
                    else
                        MessageBox.Show("Проблема с данным столом! Пожалуйста, свяжитесь с Вашим работодателем для решения проблемы с Базой Данных! Ошибка: Invalid table status.");
                }
                else
                    MessageBox.Show("Стол с таким номером не найден!");
            }
            else
                MessageBox.Show("Введите номер стола!");
        }
    }
}
