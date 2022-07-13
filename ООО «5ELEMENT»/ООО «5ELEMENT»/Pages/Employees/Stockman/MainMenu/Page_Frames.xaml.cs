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
    /// Логика взаимодействия для Page_Frames.xaml
    /// </summary>
    public partial class Page_Frames : Page
    {
        public Page_Frames()
        {
            InitializeComponent();

            Frame_View.Navigate(new Ingridients.Page_Ingridients_View());
            Frame_Work.Navigate(new Ingridients.Page_Ingridients_Work(""));

            Classes.Class_Frame_Manager.Admin_Template_Work = this.Frame_Work;
            Classes.Class_Frame_Manager.Admin_Template_View = this.Frame_View;
        }
    }
}
