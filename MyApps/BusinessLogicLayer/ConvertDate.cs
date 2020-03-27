using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class ConvertDate
    {
        public static DateTime? ConvertToDate(string date)
        {
            try
            {
                if (date == "")
                    return DateTime.MinValue;
                return Convert.ToDateTime(date);
            }
            catch
            {
                throw new Exception("Cannot convert string date to date time");
            }
        }
    }
}
