using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace ООО__5ELEMENT_.Classes
{
    class Class_Constant_Data
    {
        public static SqlConnection Connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ООО 5ELEMENT;Integrated Security=True");
        private static string Dir = System.IO.Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
        public static string Exe_Directory = Dir.Substring(0, Dir.IndexOf(@"\bin"));

        public static Button ButtonBack;
    }
}
