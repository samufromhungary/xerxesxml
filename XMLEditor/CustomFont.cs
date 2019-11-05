using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace XMLEditor
{
    [Serializable]
    public class CustomFont
    {
        public System.Drawing.FontFamily TYPE;
        public float SIZE;

        public CustomFont(System.Drawing.FontFamily TYPE,float SIZE)
        {
            this.TYPE = TYPE;
            this.SIZE = SIZE;
        }
    }
}
