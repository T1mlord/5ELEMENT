using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ООО__5ELEMENT_.Classes
{
    class Class_DishIngridient
    {
        public static string IngridientsQuery = "SELECT IngridientID AS [№ блюда], IngridientName AS [Название] FROM Ingridients WHERE [IngridientID] LIKE '' ";
        public static DataTable Quantities = new DataTable();
    }
}
