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

namespace ООО__5ELEMENT_.Pages.Employees.Admin.Employees
{
    /// <summary>
    /// Логика взаимодействия для Page_Employee_View.xaml
    /// </summary>
    public partial class Page_Employee_View : Page
    {
        DataTable Roles = new DataTable();

        public Page_Employee_View()
        {
            InitializeComponent();

            DataTable Table = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM Users", Class_Constant_Data.Connection);
            Adapter.Fill(Table);

            for (int i = 0; i < Table.Rows.Count; i++)
            {
                StackPanel_Employees.Children.Add(new Resources.SystemResources.EmployeeTemplate(Table.Rows[i][0].ToString()));
            }

            SqlDataAdapter RoleAdapter = new SqlDataAdapter("SELECT [RoleID], [RoleName] FROM Roles", Class_Constant_Data.Connection);
            RoleAdapter.Fill(Roles);

            ComboBoxItem Item = new ComboBoxItem();
            Item.Content = CreateTextBlock("Все роли");
            ComboBox_Filtration.Items.Add(Item);

            for (int i = 0; i < Roles.Rows.Count; i++)
            {
                Item = new ComboBoxItem();
                Item.Content = CreateTextBlock(Roles.Rows[i][1].ToString());
                ComboBox_Filtration.Items.Add(Item);
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
        private string RoleDetection()
        {
            for (int i = 0; i < Roles.Rows.Count; i++)
            {
                if (ComboBox_Filtration.Text == Roles.Rows[i][1].ToString())
                    return Roles.Rows[i][0].ToString();
            }
            return "";
        }
        string AscDesc = " ORDER BY UserID ";

        private void LoadData()
        {
            StackPanel_Employees.Children.Clear();

            DataTable Table = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM Users WHERE UserFIO LIKE '%" + TextBox_Search.Text + "%' AND UserRole LIKE '%" + RoleDetection() + "%'" + AscDesc, Class_Constant_Data.Connection);
            Adapter.Fill(Table);

            for (int i = 0; i < Table.Rows.Count; i++)
            {
                StackPanel_Employees.Children.Add(new Resources.SystemResources.EmployeeTemplate(Table.Rows[i][0].ToString()));
            }
        }
        private void RadioButtonAsc_Checked(object sender, RoutedEventArgs e)
        {
            AscDesc = " ORDER BY UserBirthDate ASC ";
            LoadData();
        }

        private void RadioButtonDesc_Checked(object sender, RoutedEventArgs e)
        {
            AscDesc = " ORDER BY UserBirthDate DESC ";
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
