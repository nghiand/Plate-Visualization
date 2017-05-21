using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plate_Visualization
{
    /// <summary>
    /// Stiffness
    /// </summary>
    public class Stiffness
    {
        /// <summary>
        /// E
        /// </summary>
        public float E
        {
            get; set;
        }
        /// <summary>
        /// V
        /// </summary>
        public float V
        {
            get; set;
        }
        /// <summary>
        /// H
        /// </summary>
        public float H
        {
            get; set;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Stiffness()
        {
            E = 0;
            V = 0;
            H = 0;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_e">E</param>
        /// <param name="_v">V</param>
        /// <param name="_h">H</param>
        public Stiffness(float _e, float _v, float _h)
        {
            E = _e;
            V = _v;
            H = _h;
        }
    }
}
