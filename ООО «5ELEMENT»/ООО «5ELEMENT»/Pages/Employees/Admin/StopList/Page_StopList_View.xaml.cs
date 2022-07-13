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

namespace ООО__5ELEMENT_.Pages.Employees.Admin.StopList
{
    /// <summary>
    /// Логика взаимодействия для Page_StopList_View.xaml
    /// </summary>
    public partial class Page_StopList_View : Page
    {
        DataTable StopList = new DataTable();

        public Page_StopList_View()
        {
            InitializeComponent();

            DataTable Table = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM Dishes", Class_Constant_Data.Connection);
            Adapter.Fill(Table);

            string StopListQuery = "SELECT [DishID] AS [№ блюда], [DishName] AS [Наименивание блюда] FROM DishesView WHERE [DishID] LIKE '' ";

            for (int i = 0; i < Table.Rows.Count; i++)
            {
                DataTable Count = new DataTable();
                SqlDataAdapter MenuAdapter = new SqlDataAdapter("SELECT Dishes.DishID, Ingridients.IngridientQuantity, DishTablePart.IngridientQuantity FROM DishTablePart JOIN Dishes ON Dishes.DishID = DishTablePart.DishID JOIN Ingridients ON Ingridients.IngridientID = DishTablePart.IngridientID WHERE DishTablePart.DishID = " + Table.Rows[i][0], Class_Constant_Data.Connection);
                MenuAdapter.Fill(Count);

                for (int j = 0; j < Count.Rows.Count; j++)
                {
                    if ((Convert.ToInt32(Count.Rows[j][1]) - Convert.ToInt32(Count.Rows[j][2])) < 0)
                    {
                        StopListQuery += " OR [DishID] = " + Table.Rows[i][0] + " ";
                    }
                }
            }

            SqlDataAdapter AdapterMenu = new SqlDataAdapter(StopListQuery, Class_Constant_Data.Connection);
            AdapterMenu.Fill(StopList);
            DataGrid_StopList.ItemsSource = StopList.DefaultView;
        }

        private void Button_Print_Click(object sender, RoutedEventArgs e)
        {
            if (StopList.Rows.Count != 0)
            {
                var Excel = new Microsoft.Office.Interop.Excel.Application();
                var xlWB = Excel.Workbooks.Open(Class_Constant_Data.Exe_Directory + @"\Стоплист.xlsx");
                var xlSht = xlWB.Worksheets[1];
                xlSht.Cells[6, 2] = "Стоп-лист от ";
                xlSht.Cells[6, 3] = DateTime.Now.ToShortDateString();
                xlSht.Cells[8, 2] = "Номер";
                xlSht.Cells[8, 3] = "Наименование";
                xlSht.Columns[2].ColumnWidth = 17.45;
                xlSht.Columns[3].ColumnWidth = 25.45;

                for (int i = 0; i < StopList.Rows.Count; i++)
                {
                    xlSht.Cells[i + 9, 2] = StopList.Rows[i][0];
                    xlSht.Cells[i + 9, 2].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                    xlSht.Cells[i + 9, 3] = StopList.Rows[i][1];
                    xlSht.Cells[i + 9, 3].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                }

                xlSht.Cells[StopList.Rows.Count + 11, 2] = "Составил:";
                xlSht.Cells[StopList.Rows.Count + 11, 3] = Class_Current_User.FIO;
                xlSht.Cells[StopList.Rows.Count + 13, 2] = "Подпись:";

                Excel.Visible = true;
            }
            else
                MessageBox.Show("Все позиции вне стоп-листа!");
        }

        private void Button_BackUp_Click(object sender, RoutedEventArgs e)
        {
            Class_Frame_Manager.Admin_MainMenu_Frame.Navigate(new BackUp.Page_BackUp());

            Class_Current_User.CurrentPage = "Резервное копирование базы";
        }
    }
}
