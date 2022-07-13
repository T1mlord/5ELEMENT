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

namespace ООО__5ELEMENT_.Pages.Employees.Stockman.MainMenu
{
    /// <summary>
    /// Логика взаимодействия для Page_MainMenu.xaml
    /// </summary>
    public partial class Page_MainMenu : Page
    {
        public Page_MainMenu()
        {
            InitializeComponent();
            if (Classes.Class_Constant_Data.ButtonBack != null)
                Classes.Class_Constant_Data.ButtonBack.Visibility = Visibility.Hidden;
        }

        private void Button_Ingridients_Click(object sender, RoutedEventArgs e)
        {
            Classes.Class_Frame_Manager.Admin_MainMenu_Frame.Navigate(new Page_Frames());
            Classes.Class_Frame_Manager.Admin_Template_View.Navigate(new Ingridients.Page_Ingridients_View());
            Classes.Class_Frame_Manager.Admin_Template_Work.Navigate(new Ingridients.Page_Ingridients_Work(""));

            Classes.Class_Constant_Data.ButtonBack.Visibility = Visibility.Visible;

            Classes.Class_Current_User.CurrentPage = "Ингридиенты";

        }

        private void Button_PeriodReport_Click(object sender, RoutedEventArgs e)
        {
            Classes.Class_Frame_Manager.Admin_MainMenu_Frame.Navigate(new Page_PeriodReport());

            Classes.Class_Constant_Data.ButtonBack.Visibility = Visibility.Visible;

            Classes.Class_Current_User.CurrentPage = "Отчёт за период";
        }

    }
}
