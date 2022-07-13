
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ООО__5ELEMENT_.Pages.Employees.Admin.BackUp
{
    /// <summary>
    /// Логика взаимодействия для Page_BackUp.xaml
    /// </summary>
    public partial class Page_BackUp : Page
    {
        public Page_BackUp()
        {
            InitializeComponent();

            TextBox_BackUpPath.Text = Classes.Class_Constant_Data.Exe_Directory + "\\Resources";
        }
        private void Button_SelectRecoveryPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog SelectedFile = new OpenFileDialog();
            SelectedFile.Filter = "SQL SERVER database backup files|*.bak";
            SelectedFile.InitialDirectory = Classes.Class_Constant_Data.Exe_Directory + @"\Resources";
            SelectedFile.Title = "Выберите копию";

            if (SelectedFile.ShowDialog() == DialogResult.OK)
            {
                TextBox_RecoveryPath.Text = SelectedFile.FileName;
                Button_BeginRecovery.IsEnabled = true;
            }
        }

        private void Button_BeginRecovery_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_RecoveryPath.Text.Length != 0)
            {
                Classes.Class_Constant_Data.Connection.Open();
                if (TextBox_RecoveryPath.Text.Length != 0)
                {
                    SqlCommand RecoveryCommand = new SqlCommand("ALTER DATABASE [ООО 5ELEMENT] SET SINGLE_USER WITH ROLLBACK IMMEDIATE USE MASTER RESTORE DATABASE [ООО 5ELEMENT] FROM DISK='" + TextBox_RecoveryPath.Text + "' WITH REPLACE ALTER DATABASE [ООО 5ELEMENT] SET MULTI_USER", Classes.Class_Constant_Data.Connection);
                    RecoveryCommand.ExecuteNonQuery();
                    System.Windows.MessageBox.Show("Восстановление выполнено!");
                }
                else
                {
                    System.Windows.MessageBox.Show("Данные не введены или введены не верно!");
                }
                TextBox_RecoveryPath.Clear();
                Button_BeginRecovery.IsEnabled = false;

                Classes.Class_Constant_Data.Connection.Close();
            }
            else
                System.Windows.MessageBox.Show("Выберите путь для восстановления!");

        }

        private void Button_BeginBackUp_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_BackUpPath.Text.Length != 0)
            {
                Classes.Class_Constant_Data.Connection.Open();
                if (TextBox_BackUpPath.Text.Length != 0)
                {
                    SqlCommand BackUpCommand = new SqlCommand("BACKUP DATABASE [ООО 5ELEMENT] TO DISK = '" + TextBox_BackUpPath.Text + "\\" + "5ELEMENT" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'", Classes.Class_Constant_Data.Connection);
                    BackUpCommand.ExecuteNonQuery();
                    System.Windows.MessageBox.Show("Резервное копирование выполнено!");
                }
                else
                {
                    System.Windows.MessageBox.Show("Данные не введены или введены не верно!");
                }
                Button_BeginBackUp.IsEnabled = false;

                Classes.Class_Constant_Data.Connection.Close();
            }
            else
                System.Windows.MessageBox.Show("Выберите путь для копирования!");

        }
    }
}
