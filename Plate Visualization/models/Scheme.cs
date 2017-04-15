using System.Collections.Generic;

namespace Plate_Visualization
{
    class Scheme
    {
        public Plate Plate {
            get; set;
        }
        public List<Load> Loads {
            get; set;
        }

        public Scheme()
        {
            Plate = null;
            Loads = null;
        }
    }
}
