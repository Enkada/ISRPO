using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ISRPO_Lab8_C
{
    public class Calculator
    {
        public static double Calculate(string query)
        {
            try
            {
                return Convert.ToDouble(new DataTable().Compute(query.Replace(',', '.'), null));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
        }
    }
}
