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
        public String TYPE;
        public float SIZE;

        public CustomFont(String TYPE,float SIZE)
        {
            this.TYPE = TYPE;
            this.SIZE = SIZE;
        }
    }
}
