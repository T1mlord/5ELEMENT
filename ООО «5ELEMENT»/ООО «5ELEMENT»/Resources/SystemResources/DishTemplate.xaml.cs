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
    /// Логика взаимодействия для DishTemplate.xaml
    /// </summary>
    public partial class DishTemplate : UserControl
    {
        string ID = "";
        int Cost = 0;
        public DishTemplate(string ID)
        {
            InitializeComponent();

            DataTable DishTable = new DataTable();
            SqlDataAdapter DishAdapter = new SqlDataAdapter("SELECT DishName, DishCost, DishImage FROM Dishes JOIN DishType ON Dishes.DishType = DishType.DishTypeID WHERE DishID = " + ID, Classes.Class_Constant_Data.Connection);
            DishAdapter.Fill(DishTable);

            TextBlock_Name.Text = DishTable.Rows[0][0].ToString() + "\n";
            TextBlock_Name.Text += "Стоимость: " + DishTable.Rows[0][1] + " (Руб.)";

            byte[] Image = (byte[])DishTable.Rows[0][2];
            Image_Dish.Source = BitmapFrame.Create(new MemoryStream(Image), BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

            this.ID = ID;
            Cost = Convert.ToInt32(DishTable.Rows[0][1]);
        }


        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (TextBox_Quantity.Text.Length != 0)
            {
                Classes.Class_Cart.CartQuery += " OR [DishID] = " + ID + " ";
                Classes.Class_Cart.OrderTotalCost += Cost * Convert.ToInt32(TextBox_Quantity.Text);
                Classes.Class_Frame_Manager.Cart_Frame.Navigate(new Pages.Tables.Page_Order_Work());
                Classes.Class_Cart.Quantities.Rows.Add(TextBox_Quantity.Text);
            }
            else
                MessageBox.Show("Вы должны выбрать количество!");
        }
        bool IsGoodNumbers(char c)
        {
            if (c >= 'a' && c <= 'z')
                return true;
            if (c >= 'A' && c <= 'Z')
                return true;
            if (c >= 'а' && c <= 'я')
                return true;
            if (c >= 'А' && c <= 'Я')
                return true;

            return false;
        }

        private void TextBox_PreviewTextInput_VerificationNumbers(object sender, TextCompositionEventArgs e)
        {
            e.Handled = e.Text.All(IsGoodNumbers);
        }
    }
}
