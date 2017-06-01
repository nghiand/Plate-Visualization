namespace Plate_Visualization
{
    /// <summary>
    /// Class describes load
    /// </summary>
    public class Load
    {
        /// <summary>
        /// 
        /// </summary>
        public float Weight
        {
            get; set;
        }
        /// <summary>
        /// Position
        /// </summary>
        public PlateObject Position
        {
            get; set;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public Load()
        {
            Weight = 0;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="weight">Weight</param>
        /// <param name="position">Position</param>
        public Load(float weight, PlateObject position)
        {
            Weight = weight;
            Position = position;
        }

        /// <summary>
        /// Clone load
        /// </summary>
        /// <returns>Cloned load</returns>
        public Load Clone()
        {
            Load ret = new Load();
            ret.Weight = Weight;
            return ret;
        }
    }
}
