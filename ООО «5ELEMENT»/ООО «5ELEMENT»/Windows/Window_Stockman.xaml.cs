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
using System.Windows.Shapes;

namespace ООО__5ELEMENT_.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window_Stockman.xaml
    /// </summary>
    public partial class Window_Stockman : Window
    {
        public Window_Stockman()
        {
            InitializeComponent();

            this.Title = Classes.Class_Current_User.FIO + " / " + Classes.Class_Current_User.Role;

            Frame_Frames.Navigate(new Pages.Employees.Stockman.MainMenu.Page_MainMenu());

            Classes.Class_Constant_Data.ButtonBack = this.Button_Back;
            Button_Back.Visibility = Visibility.Hidden;

            Classes.Class_Frame_Manager.Admin_MainMenu_Frame = this.Frame_Frames;

            Frame_Frames.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            Classes.Class_Current_User.CurrentPage = "Меню";

            Classes.Class_DishIngridient.Quantities.Columns.Add();
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            Frame_Frames.Navigate(new Pages.Employees.Stockman.MainMenu.Page_MainMenu());

            Classes.Class_Current_User.CurrentPage = "Меню";
        }

        private void Frame_Frames_ContentRendered(object sender, EventArgs e)
        {
            TextBlock_CurrentPage.Text = Classes.Class_Current_User.CurrentPage;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Classes.Class_Frame_Manager.Auth.Show();
        }
    }
}
