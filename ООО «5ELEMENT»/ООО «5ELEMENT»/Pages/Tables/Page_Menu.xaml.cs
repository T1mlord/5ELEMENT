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
using System.Data.SqlClient;
using System.Data;
using ООО__5ELEMENT_.Classes;
using ООО__5ELEMENT_.Resources.SystemResources;

namespace ООО__5ELEMENT_.Pages.Tables
{
    /// <summary>
    /// Логика взаимодействия для Page_Menu.xaml
    /// </summary>
    public partial class Page_Menu : Page
    {
        DataTable Types = new DataTable();

        public Page_Menu()
        {
            InitializeComponent();

            DataTable Table = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM Dishes", Class_Constant_Data.Connection);
            Adapter.Fill(Table);

            string MenuQuery = "SELECT DishID, DishName, DishTypeTitle, DishCost, DishDescription FROM Dishes JOIN DishType ON Dishes.DishType = DishTypeID WHERE DishID LIKE '%%' ";
            for (int i = 0; i < Table.Rows.Count; i++)
            {
                DataTable Count = new DataTable();
                SqlDataAdapter MenuAdapter = new SqlDataAdapter("SELECT Dishes.DishID, Ingridients.IngridientQuantity, DishTablePart.IngridientQuantity FROM DishTablePart JOIN Dishes ON Dishes.DishID = DishTablePart.DishID JOIN Ingridients ON Ingridients.IngridientID = DishTablePart.IngridientID WHERE DishTablePart.DishID = " + Table.Rows[i][0], Class_Constant_Data.Connection);
                MenuAdapter.Fill(Count);
                if (Count.Rows.Count != 0)

                    for (int j = 0; j < Count.Rows.Count; j++)
                {
                    if ((Convert.ToInt32(Count.Rows[j][1]) - Convert.ToInt32(Count.Rows[j][2])) < 0)
                    {
                        MenuQuery += " AND DishID != " + Count.Rows[j][0] + " ";
                    }
                }
            }

            DataTable Menu = new DataTable();
            SqlDataAdapter AdapterMenu = new SqlDataAdapter(MenuQuery, Class_Constant_Data.Connection);
            AdapterMenu.Fill(Menu);
            for (int i = 0; i < Menu.Rows.Count; i++)
            {
                StackPanel_Menu.Children.Add(new DishTemplate(Menu.Rows[i][0].ToString()));
            }

            SqlDataAdapter TypeAdapter = new SqlDataAdapter("SELECT [DishTypeID], [DishTypeTitle] FROM DishType", Class_Constant_Data.Connection);
            TypeAdapter.Fill(Types);

            ComboBoxItem Item = new ComboBoxItem();
            Item.Content = CreateTextBlock("Все типы");
            ComboBox_Filtration.Items.Add(Item);

            for (int i = 0; i < Types.Rows.Count; i++)
            {
                ComboBoxItem Type = new ComboBoxItem();
                Type.Content = CreateTextBlock(Types.Rows[i][1].ToString());
                ComboBox_Filtration.Items.Add(Type);
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

        private void ComboBox_Filtration_DropDownClosed(object sender, EventArgs e)
        {
            if (ComboBox_Filtration.Text.Length != 0)
            {
                StackPanel_Menu.Children.Clear();

                DataTable Table = new DataTable();
                SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM Dishes", Class_Constant_Data.Connection);
                Adapter.Fill(Table);

                string MenuQuery = "SELECT DishID, DishName, DishTypeTitle, DishCost, DishDescription FROM Dishes JOIN DishType ON Dishes.DishType = DishTypeID WHERE DishID LIKE '%%' ";

                for (int i = 0; i < Table.Rows.Count; i++)
                {
                    DataTable Count = new DataTable();
                    SqlDataAdapter MenuAdapter = new SqlDataAdapter("SELECT Dishes.DishID, Ingridients.IngridientQuantity, DishTablePart.IngridientQuantity FROM DishTablePart JOIN Dishes ON Dishes.DishID = DishTablePart.DishID JOIN Ingridients ON Ingridients.IngridientID = DishTablePart.IngridientID WHERE DishTablePart.DishID = " + Table.Rows[i][0], Class_Constant_Data.Connection);
                    MenuAdapter.Fill(Count);

                    for (int j = 0; j < Count.Rows.Count; j++)
                    {
                        if ((Convert.ToInt32(Count.Rows[j][1]) - Convert.ToInt32(Count.Rows[j][2])) < 0)
                        {
                            MenuQuery += " AND DishID != " + Count.Rows[i][0] + " ";
                        }
                    }
                }

                DataTable Menu = new DataTable();
                MenuQuery += " AND DishTypeID LIKE '%" + TypeDetection() + "%'";
                SqlDataAdapter AdapterMenu = new SqlDataAdapter(MenuQuery, Class_Constant_Data.Connection);
                AdapterMenu.Fill(Menu);
                for (int i = 0; i < Menu.Rows.Count; i++)
                {
                    StackPanel_Menu.Children.Add(new DishTemplate(Menu.Rows[i][0].ToString()));
                }
            }
            
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

    }
}
