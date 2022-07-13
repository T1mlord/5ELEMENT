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
    /// Логика взаимодействия для Page_Authorization_User.xaml
    /// </summary>
    public partial class Page_Authorization_User : Page
    {
        public Page_Authorization_User()
        {
            InitializeComponent();
        }

        private void Button_ChangePage_Click(object sender, RoutedEventArgs e)
        {
            Class_Frame_Manager.Authorization_Frame.Navigate(new Page_Authorization_Table());
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Login.Text.Length != 0)
            {
                if (TextBox_Password.Text.Length != 0)
                {
                    if (TextBox_Login.Text.Length != 0 && TextBox_Password.Text.Length != 0)
                    {
                        DataTable Table = new DataTable();
                        SqlDataAdapter Adapter = new SqlDataAdapter("SELECT UserID, UserFIO, [AccessLevel], Role FROM UsersView WHERE UserLogin = '" + TextBox_Login.Text + "' AND UserPassword = '" + TextBox_Password.Text + "'", Class_Constant_Data.Connection);
                        Adapter.Fill(Table);

                        if (Table.Rows.Count != 0)
                        {
                            Class_Current_User.ID = Table.Rows[0][0].ToString();
                            Class_Current_User.FIO = Table.Rows[0][1].ToString();
                            Class_Current_User.Role = Table.Rows[0][3].ToString();

                            if (Table.Rows[0][2].ToString() == "1")
                            {
                                Window_Stockman Window = new Window_Stockman();
                                Window.Show();
                                Class_Frame_Manager.Auth.Hide();
                            }
                            else if (Table.Rows[0][2].ToString() == "0")
                            {
                                Window_Admin Window = new Window_Admin();
                                Window.Show();
                                Class_Frame_Manager.Auth.Hide();
                            }
                            else
                                MessageBox.Show("Произошла ошибка! Свяжитесь с Вашим работодателем для решения проблемы. Ошибка: Неверная роль пользователя.");
                        }
                        else
                            MessageBox.Show("Пользователь с такими логином и паролем не найден!");
                    }
                    else
                        MessageBox.Show("Заполните поля!");
                }
                else
                    MessageBox.Show("Введите пароль!");
            }
            else
                MessageBox.Show("Введите логин!");
        }
    }
}
