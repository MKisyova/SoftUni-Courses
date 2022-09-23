namespace RawData
{
    class Tire
    {
        public Tire(int age, float pressure)
        {
            Age = age;
            Pressure = pressure;
        }
        public int Age { get; set; }
        public float Pressure { get; set; }
    }
}
