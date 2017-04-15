using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plate_Visualization
{
    public class Stiffness
    {
        private float e;
        public float E
        {
            get
            {
                return e;
            }
            set
            {
                e = value;
            }
        }
        private float v;
        public float V
        {
            get
            {
                return v;
            }
            set
            {
                v = value;
            }
        }
        private float h;
        public float H
        {
            get
            {
                return h;
            }
            set
            {
                h = value;
            }
        }

        public Stiffness()
        {
            e = 0;
            v = 0;
            h = 0;
        }

        public Stiffness(float _e, float _v, float _h)
        {
            e = _e;
            v = _v;
            h = _h;
        }
    }
}
