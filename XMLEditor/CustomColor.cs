using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLEditor
{
    [Serializable]
    public class CustomColor
    {
        public Color HC_NODE;
        public Color HC_STRING;
        public Color HC_ATTRIBUTE;
        public Color HC_COMMENT;
        public Color HC_INNERTEXT;

        public CustomColor(Color HC_NODE, Color HC_STRING, Color HC_ATTRIBUTE, Color HC_COMMENT, Color HC_INNERTEXT)
        {
            this.HC_NODE = HC_NODE;
            this.HC_STRING = HC_STRING;
            this.HC_ATTRIBUTE = HC_ATTRIBUTE;
            this.HC_COMMENT = HC_COMMENT;
            this.HC_INNERTEXT = HC_INNERTEXT;
        }

    }
}
