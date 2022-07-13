using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ООО__5ELEMENT_.Classes
{
    class Class_Cart
    {
        public static string CartQuery = "SELECT DishID AS [№ блюда], [DishName] AS [Название], DishCost AS [Стоимость (Руб.)] FROM DishesView WHERE [DishID] LIKE '' ";
        public static int OrderTotalCost = 0;

        public static DataTable Quantities = new DataTable();

    }
}
