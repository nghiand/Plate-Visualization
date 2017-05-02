using System.Collections.Generic;

namespace Plate_Visualization
{
    class Scheme
    {
        public string Name
        {
            get; set;
        }

        public bool IsModified
        {
            get; set;
        }

        public bool WasSavedToFile
        {
            get; set;
        }

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
