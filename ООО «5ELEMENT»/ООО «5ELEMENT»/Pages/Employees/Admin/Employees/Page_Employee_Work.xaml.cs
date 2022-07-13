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

namespace ООО__5ELEMENT_.Pages.Employees.Admin.Employees
{
    /// <summary>
    /// Логика взаимодействия для Page_Employee_Work.xaml
    /// </summary>
    public partial class Page_Employee_Work : Page
    {
        string ID;
        DataTable Roles = new DataTable();
        
        public Page_Employee_Work(string ID)
        {
            InitializeComponent();

            SqlDataAdapter RoleAdapter = new SqlDataAdapter("SELECT [RoleID], [RoleName] FROM Roles", Classes.Class_Constant_Data.Connection);
            RoleAdapter.Fill(Roles);
            for (int i = 0; i < Roles.Rows.Count; i++)
            {
                ComboBoxItem Item = new ComboBoxItem();
                Item.Content = CreateTextBlock(Roles.Rows[i][1].ToString());
                ComboBox_Role.Items.Add(Item);
            }

            DatePicker_BirthDate.DisplayDateEnd = DateTime.Now.AddYears(-18);

            DataTable Table = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM UsersView WHERE UserID LIKE '" + ID + "'", Classes.Class_Constant_Data.Connection);
            Adapter.Fill(Table);
            if (Table.Rows.Count > 0)
            {
                TextBox_FIO.Text = "" + Table.Rows[0][1];
                DatePicker_BirthDate.Text = "" + Table.Rows[0][2];
                TextBox_Phone.Text = "" + Table.Rows[0][3];
                TextBox_Passport.Text = "" + Table.Rows[0][4];
                ComboBox_Role.SelectedItem = ComboBox_Role.Items[0];
            }

            this.ID = ID;
        }
        private TextBlock CreateTextBlock(string Text)
        {
            TextBlock TextBlock_Role_Item = new TextBlock();
            TextBlock_Role_Item.TextWrapping = TextWrapping.Wrap;
            TextBlock_Role_Item.Width = 170;
            TextBlock_Role_Item.FontFamily = new FontFamily("Comic Sans MS");
            TextBlock_Role_Item.FontSize = 20;
            TextBlock_Role_Item.Text = Text;

            return TextBlock_Role_Item;
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ID.Length != 0)
                {
                    if (ID != Classes.Class_Current_User.ID)
                    {
                        Classes.Class_Constant_Data.Connection.Open();

                        SqlCommand CommandDelete = new SqlCommand("DELETE FROM Users WHERE UserID = " + ID, Classes.Class_Constant_Data.Connection);
                        CommandDelete.ExecuteNonQuery();

                        MessageBox.Show("Пользователь удалён!");

                        Classes.Class_Constant_Data.Connection.Close();

                        Classes.Class_Frame_Manager.Admin_Template_View.Navigate(new Page_Employee_View());
                    }
                    else
                        MessageBox.Show("Вы не можете удалить себя!");

                }
                else
                    MessageBox.Show("Выберите пользователя!");
            }
            catch
            {
                MessageBox.Show("Невозможно удалить пользователя!");
            }
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ID.Length != 0)
                {
                    if (TextBox_FIO.Text.Length > 0 && TextBox_Passport.Text.Length > 0 && TextBox_Phone.Text.Length > 0)
                    {
                        if (MessageBox.Show("Вы уверены, что хотите обновить данные пользователя?", "Подтвержение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            Classes.Class_Constant_Data.Connection.Open();

                            SqlCommand CommandUpdate = new SqlCommand("UPDATE Users SET UserFIO = '" + TextBox_FIO.Text + "', UserBirthDate = '" + DatePicker_BirthDate.DisplayDate + "', UserPhone = '" + TextBox_Phone.Text + "', UserPassport = '" + TextBox_Passport.Text + "', UserRole = '" + RoleDetection() + "' WHERE UserID = " + ID, Classes.Class_Constant_Data.Connection);
                            CommandUpdate.ExecuteNonQuery();

                            MessageBox.Show("Данные обновлены!");

                            Classes.Class_Constant_Data.Connection.Close();

                            Classes.Class_Frame_Manager.Admin_Template_View.Navigate(new Page_Employee_View());

                        }
                    }
                    else
                        MessageBox.Show("Все поля должны быть заполнены!");
                }
                else
                    MessageBox.Show("Выберите пользователя!");
            }
            catch
            {
                MessageBox.Show("Невозможно обновить данные о пользователе!");
            }
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_FIO.Text.Length > 0 && TextBox_Passport.Text.Length > 0 && TextBox_Phone.Text.Length > 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите добавить пользователя?", "Подтвержение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Classes.Class_Constant_Data.Connection.Open();

                    SqlCommand CommandInsert = new SqlCommand("INSERT INTO Users (UserFIO, UserBirthDate, UserPhone, UserPassport, UserRole, UserLogin, UserPassword) VALUES ('" + TextBox_FIO.Text + "', '" + DatePicker_BirthDate.DisplayDate + "', '" + TextBox_Phone.Text + "', '" + TextBox_Passport.Text + "', '" + RoleDetection() + "', '" + Microsoft.VisualBasic.Interaction.InputBox("Введите логин для нового пользовтеля:") + "', '" + Microsoft.VisualBasic.Interaction.InputBox("Введите пароль для нового пользовтеля:") + "')", Classes.Class_Constant_Data.Connection);
                    CommandInsert.ExecuteNonQuery();

                    MessageBox.Show("Пользователь добавлен!");

                    Classes.Class_Constant_Data.Connection.Close();

                    Classes.Class_Frame_Manager.Admin_Template_View.Navigate(new Page_Employee_View());

                }
            }
            else
                MessageBox.Show("Все поля должны быть заполнены!");
        }
        bool IsGoodNumbers(char c)
        {
            if (!(c >= '0' && c <= '9' || c == '+'))
                return true;

            return false;
        }
        bool IsGoodLetters(char c)
        {
            if (c >= '0' && c <= '9')
                return true;

            if (c >= 'a' && c <= 'z')
                return true;
            if (c >= 'A' && c <= 'Z')
                return true;
            return false;
        }

        private void TextBox_PreviewTextInput_VerificationNumbers(object sender, TextCompositionEventArgs e)
        {
            e.Handled = e.Text.All(IsGoodNumbers);
        }
        private void TextBox_PreviewTextInput_VerificationLetters(object sender, TextCompositionEventArgs e)
        {
            e.Handled = e.Text.All(IsGoodLetters);
        }

        private string RoleDetection()
        {
            for (int i = 0; i < Roles.Rows.Count; i++)
            {
                if (ComboBox_Role.Text == Roles.Rows[i][1].ToString())
                    return Roles.Rows[i][0].ToString();
            }
            return "";
        }

    }
}
