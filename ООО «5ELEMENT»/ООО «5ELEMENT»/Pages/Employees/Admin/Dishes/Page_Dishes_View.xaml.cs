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
using ООО__5ELEMENT_.Classes;

namespace ООО__5ELEMENT_.Pages.Employees.Admin.Dishes
{
    /// <summary>
    /// Логика взаимодействия для Page_Dishes_View.xaml
    /// </summary>
    public partial class Page_Dishes_View : Page
    {

        public Page_Dishes_View()
        {
            InitializeComponent();

            DataTable Table = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM Dishes", Class_Constant_Data.Connection);
            Adapter.Fill(Table);

            for (int i = 0; i < Table.Rows.Count; i++)
            {
                StackPanel_Dishes.Children.Add(new Resources.SystemResources.DishViewTemplate(Table.Rows[i][0].ToString()));
            }

            SqlDataAdapter TypeAdapter = new SqlDataAdapter("SELECT [DishTypeID], [DishTypeTitle] FROM DishType", Class_Constant_Data.Connection);
            TypeAdapter.Fill(Types);

            ComboBoxItem Item = new ComboBoxItem();
            Item.Content = CreateTextBlock("Всё меню");
            ComboBox_Filtration.Items.Add(Item);

            for (int i = 0; i < Types.Rows.Count; i++)
            {
                ComboBoxItem Type = new ComboBoxItem();
                Type.Content = CreateTextBlock(Types.Rows[i][1].ToString());
                ComboBox_Filtration.Items.Add(Type);
            }
        }

        DataTable Types = new DataTable();

        string AscDesc = " ORDER BY DishCost ";

        private void LoadData()
        {
            StackPanel_Dishes.Children.Clear();

            DataTable Table = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM Dishes WHERE DishName LIKE '%" + TextBox_Search.Text + "%' AND DishType LIKE '%" + TypeDetection() + "%'" + AscDesc, Class_Constant_Data.Connection);
            Adapter.Fill(Table);

            for (int i = 0; i < Table.Rows.Count; i++)
            {
                StackPanel_Dishes.Children.Add(new Resources.SystemResources.DishViewTemplate(Table.Rows[i][0].ToString()));
            }
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
        private string TypeDetection()
        {
            for (int i = 0; i < Types.Rows.Count; i++)
            {
                if (ComboBox_Filtration.Text == Types.Rows[i][1].ToString())
                    return Types.Rows[i][0].ToString();
            }
            return "";
        }

        private void RadioButtonAsc_Checked(object sender, RoutedEventArgs e)
        {
            AscDesc = " ORDER BY DishCost ASC ";
            LoadData();
        }

        private void RadioButtonDesc_Checked(object sender, RoutedEventArgs e)
        {
            AscDesc = " ORDER BY DishCost DESC ";
            LoadData();
        }

        private void TextBox_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        private void ComboBox_Filtration_DropDownClosed(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
