namespace Loggers.Layouts
{
    public class SimpleLayout : ILayout
    {
        public SimpleLayout()
        {
            string.Format(Format, "1", "2", "3");
        }
        public string Format => "{0} - {1} - {2}";

    }
}
