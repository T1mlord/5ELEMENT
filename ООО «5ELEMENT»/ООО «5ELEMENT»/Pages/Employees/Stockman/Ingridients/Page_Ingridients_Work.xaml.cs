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

namespace ООО__5ELEMENT_.Pages.Employees.Stockman.Ingridients
{
    /// <summary>
    /// Логика взаимодействия для Page_Ingridients_Work.xaml
    /// </summary>
    public partial class Page_Ingridients_Work : Page
    {
        string ID = "";
        public Page_Ingridients_Work(string ID)
        {
            InitializeComponent();

            DataTable Table = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM Ingridients WHERE IngridientID LIKE '" + ID + "'", Classes.Class_Constant_Data.Connection);
            Adapter.Fill(Table);
            if (Table.Rows.Count > 0)
            {
                TextBox_Name.Text = "" + Table.Rows[0][1];
                TextBox_Quantity.Text = "" + Table.Rows[0][2];
            }

            this.ID = ID;
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

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ID.Length != 0)
                {
                    Classes.Class_Constant_Data.Connection.Open();

                    SqlCommand CommandDelete = new SqlCommand("DELETE FROM Ingridients WHERE IngridientID = " + ID, Classes.Class_Constant_Data.Connection);
                    CommandDelete.ExecuteNonQuery();

                    MessageBox.Show("Ингридлиент удалён!");

                    Classes.Class_Constant_Data.Connection.Close();

                    Classes.Class_Frame_Manager.Admin_Template_View.Navigate(new Page_Ingridients_View());
                }
                else
                    MessageBox.Show("Выберите ингридиент!");
            }
            catch
            {
                MessageBox.Show("Невозможно удалить ингридлиент!");
            }
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ID.Length != 0)
            {
                if (TextBox_Name.Text.Length > 0 && TextBox_Quantity.Text.Length > 0)
                {
                    if (MessageBox.Show("Вы уверены, что хотите обновить данные ингридиента?", "Подтвержение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Classes.Class_Constant_Data.Connection.Open();

                        SqlCommand CommandUpdate = new SqlCommand("UPDATE Ingridients SET IngridientName = '" + TextBox_Name.Text + "', IngridientQuantity = " + TextBox_Quantity.Text + " WHERE IngridientID = " + ID, Classes.Class_Constant_Data.Connection);
                        CommandUpdate.ExecuteNonQuery();

                        MessageBox.Show("Данные обновлены!");

                        Classes.Class_Constant_Data.Connection.Close();

                        Classes.Class_Frame_Manager.Admin_Template_View.Navigate(new Page_Ingridients_View());
                    }
                }
                else
                    MessageBox.Show("Все поля должны быть заполнены!");
            }
            else
                MessageBox.Show("Выберите ингридиент!");
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Name.Text.Length > 0 && TextBox_Quantity.Text.Length > 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите добавить ингридиент?", "Подтвержение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Classes.Class_Constant_Data.Connection.Open();

                    SqlCommand CommandInsert = new SqlCommand("INsERT INTO Ingridients (IngridientName, IngridientQuantity) VALUES ('" + TextBox_Name.Text + "', " + TextBox_Quantity.Text + ")", Classes.Class_Constant_Data.Connection);
                    CommandInsert.ExecuteNonQuery();

                    MessageBox.Show("Ингридиент добавлен!");

                    Classes.Class_Constant_Data.Connection.Close();

                    Classes.Class_Frame_Manager.Admin_Template_View.Navigate(new Page_Ingridients_View());
                }
            }
            else
                MessageBox.Show("Все поля должны быть заполнены!");
        }

    }
}
