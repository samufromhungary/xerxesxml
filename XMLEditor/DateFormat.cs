using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLEditor
{
    public class DateFormat
    {
        public DateFormat()
        {

        }

        public String CurrentDate()
        {
            DateTime localDate = DateTime.Now;
            return localDate.ToString();
        }

        public String AppendMessage(String msg)
        {
            return "\n" + CurrentDate() + ": " + msg;
        }
    }
}
