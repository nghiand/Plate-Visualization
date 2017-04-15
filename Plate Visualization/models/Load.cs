namespace Plate_Visualization
{
    class Load
    {
        public float Weight
        {
            get; set;
        }
        public PlateObject Position
        {
            get; set;
        }

        public Load()
        {
            Weight = 0;
        }

        public Load(float weight, PlateObject position)
        {
            Weight = weight;
            Position = position;
        }
    }
}
