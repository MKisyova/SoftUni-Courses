using System;

namespace ClassBoxData
{
    class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            set
            {
                ValidateNumber(nameof(Length), value);

                length = value;
            }
        }

        public double Width
        {
            get => width;
            set
            {
                ValidateNumber(nameof(Width), value);

                width = value;
            }
        }

        public double Height
        {
            get => height;
            set
            {
                ValidateNumber(nameof(Height), value);

                height = value;
            }
        }
        public double SurfaceArea()
        {
            double surfaceArea = 2 * Length * Height + 2 * Length * Width + 2 * Width * Height;
            return surfaceArea;
        }

        public double LateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * Length * Height + 2 * Width * Height;
            return lateralSurfaceArea;
        }

        public double Volume()
        {
            double volume = Length * Width * Height;
            return volume;
        }

        private void ValidateNumber(string propertyName, double value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{propertyName} cannot be zero or negative.");
            }
        }
    }
}
