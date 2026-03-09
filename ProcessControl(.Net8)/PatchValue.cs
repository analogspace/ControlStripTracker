using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessControl
{
    public class PatchValue(float red, float green, float blue)
    {
        public float Red { get; set; } = red;
        public float Green{ get; set; } = green;
        public float Blue{ get; set; } = blue;
    }
}
