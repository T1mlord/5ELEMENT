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

namespace ООО__5ELEMENT_.Pages.Employees.Stockman
{
    /// <summary>
    /// Логика взаимодействия для Page_PeriodReport.xaml
    /// </summary>
    public partial class Page_PeriodReport : Page
    {
        DataTable Table = new DataTable();
        public Page_PeriodReport()
        {
            InitializeComponent();

            DatePicker_Begin.DisplayDateEnd = DateTime.Now;
            DatePicker_End.DisplayDateEnd = DateTime.Now;

            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM OrderTablePartView", Class_Constant_Data.Connection);
            Adapter.Fill(Table);
            DataGrid_PeriodReport.ItemsSource = Table.DefaultView;
        }

        private void Button_Print_Click(object sender, RoutedEventArgs e)
        {
            if (DatePicker_Begin.Text.Length != 0 && DatePicker_End.Text.Length != 0)
            {
                int TotalCost = 0;
                int NullSpace = 0;
                int Totals = 0;

                var Excel = new Microsoft.Office.Interop.Excel.Application();
                var xlWB = Excel.Workbooks.Open(Class_Constant_Data.Exe_Directory + @"\Отчёт.xlsx");
                var xlSht = xlWB.Worksheets[1];
                xlSht.Cells[2, 2] = "Отчёт c ";
                xlSht.Cells[2, 3] = DatePicker_Begin.Text + " по " + DatePicker_End.Text;
                xlSht.Cells[5, 2] = "Номер";
                xlSht.Cells[5, 3] = "Наименование";
                xlSht.Cells[5, 4] = "Стоимость (Руб.)";

                xlSht.Columns[2].ColumnWidth = 17.45;
                xlSht.Columns[3].ColumnWidth = 20.45;

                DataTable Table = new DataTable();
                int SkippedOrders = 0;
                    int TotalOrderCost = 0;

                    SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM OrderTablePartView WHERE [Дата заказа] BETWEEN '" + DatePicker_Begin.Text + "' AND '" + DatePicker_End.Text + "'", Class_Constant_Data.Connection);
                    Adapter.Fill(Table);

                    if (Table.Rows.Count != 0)
                    {

                        for (int j = 0; j < Table.Rows.Count; j++)
                        {
                            xlSht.Cells[6 + j + SkippedOrders, 2] = Table.Rows[j][0];
                            xlSht.Cells[6 + j + SkippedOrders, 2].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlSht.Cells[6 + j + SkippedOrders, 3] = Table.Rows[j][1];
                            xlSht.Cells[6 + j + SkippedOrders, 3].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlSht.Cells[6 + j + SkippedOrders, 4] = Table.Rows[j][2];
                            xlSht.Cells[6 + j + SkippedOrders, 4].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            xlSht.Cells[6 + j + SkippedOrders, 5] = Table.Rows[j][3];
                            xlSht.Cells[6 + j + SkippedOrders, 5].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;        

                            TotalOrderCost += Convert.ToInt32(Table.Rows[j][2]) * Convert.ToInt32(Table.Rows[j][4]);
                        }

                        TotalCost += TotalOrderCost;
                        SkippedOrders = Table.Rows.Count;
                        TotalOrderCost = 0;
                    }
                    else
                        SkippedOrders++;

                    NullSpace += Table.Rows.Count;

                xlSht.Cells[8 + Table.Rows.Count, 4] = "Итог:";
                xlSht.Cells[8 + Table.Rows.Count, 5] = TotalCost + " (Руб.)";

                xlSht.Cells[10 + Table.Rows.Count, 2] = "Составил:";
                xlSht.Cells[10 + Table.Rows.Count, 3] = Class_Current_User.FIO;
                xlSht.Cells[11 + Table.Rows.Count, 2] = "Подпись:";

                Excel.Visible = true;

            }
            else
                MessageBox.Show("Вы должны выбрать диапазон!");
        }

        private void DatePicker_End_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Table.Rows.Clear();

            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM OrderTablePartView WHERE [Дата заказа] BETWEEN '" + DatePicker_Begin.Text + "' AND '" + DatePicker_End.Text + "'", Class_Constant_Data.Connection);
            Adapter.Fill(Table);
            DataGrid_PeriodReport.ItemsSource = Table.DefaultView;
        }
    }
}
