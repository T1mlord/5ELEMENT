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

namespace ООО__5ELEMENT_.Pages.Employees.Stockman.Ingridients
{
    /// <summary>
    /// Логика взаимодействия для Page_Ingridients_View.xaml
    /// </summary>
    public partial class Page_Ingridients_View : Page
    {
        public Page_Ingridients_View()
        {
            InitializeComponent();

            DataTable Table = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM Ingridients", Class_Constant_Data.Connection);
            Adapter.Fill(Table);

            for (int i = 0; i < Table.Rows.Count; i++)
            {
                StackPanel_Ingridients.Children.Add(new Resources.SystemResources.IngridientViewTemplate(Table.Rows[i][0].ToString()));
            }

        }
        string AscDesc = " ORDER BY IngridientID ";
        string Filtration = " ";
        private void LoadData()
        {
            StackPanel_Ingridients.Children.Clear();

            DataTable Table = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM Ingridients WHERE IngridientName LIKE '%" + TextBox_Search.Text + "%' " + Filtration + AscDesc, Class_Constant_Data.Connection);
            Adapter.Fill(Table);

            for (int i = 0; i < Table.Rows.Count; i++)
            {
                StackPanel_Ingridients.Children.Add(new Resources.SystemResources.IngridientViewTemplate(Table.Rows[i][0].ToString()));
            }
        }
        private void RadioButtonAsc_Checked(object sender, RoutedEventArgs e)
        {
            AscDesc = " ORDER BY IngridientQuantity ASC ";
            LoadData();
        }

        private void RadioButtonDesc_Checked(object sender, RoutedEventArgs e)
        {
            AscDesc = " ORDER BY IngridientQuantity DESC ";
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

        private void ComboBox_Item_All_Selected(object sender, RoutedEventArgs e)
        {
            Filtration = " ";
            LoadData();
        }

        private void ComboBox_Item_InStock_Selected(object sender, RoutedEventArgs e)
        {
            Filtration = " AND IngridientQuantity > 0 ";
            LoadData();
        }

        private void ComboBox_Item_NotInStock_Selected(object sender, RoutedEventArgs e)
        {
            Filtration = " AND IngridientQuantity = 0 ";
            LoadData();

        }
    }
}
