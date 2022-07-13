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

namespace ООО__5ELEMENT_.Resources.SystemResources
{
    /// <summary>
    /// Логика взаимодействия для IngridientTemplate.xaml
    /// </summary>
    public partial class IngridientTemplate : UserControl
    {
        string ID;
        public IngridientTemplate(string ID)
        {
            InitializeComponent();

            DataTable DishTable = new DataTable();
            SqlDataAdapter DishAdapter = new SqlDataAdapter("SELECT * FROM Ingridients WHERE IngridientID = " + ID, Classes.Class_Constant_Data.Connection);
            DishAdapter.Fill(DishTable);

            TextBlock_Name.Text = DishTable.Rows[0][1].ToString() + "\n";
            TextBlock_Name.Text += "Количество: " + DishTable.Rows[0][2] + " (Шт.)";

            this.ID = ID;

        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TextBox_Quantity.Text.Length != 0)
            {
                Classes.Class_DishIngridient.IngridientsQuery += " OR [IngridientID] = " + ID + " ";
                Classes.Class_DishIngridient.Quantities.Rows.Add(TextBox_Quantity.Text);

                Classes.Class_Frame_Manager.Admin_MainMenu_Frame.Navigate(new Pages.Employees.Admin.Dishes.Page_Dish_Ingridients());
            }
            else
                MessageBox.Show("Введите количество продукта в поле над его названием!");
        }

        bool IsGoodNumbers(char c)
        {
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

    }
}
