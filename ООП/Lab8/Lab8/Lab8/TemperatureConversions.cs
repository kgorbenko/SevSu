namespace Lab8
{
    public static class TemperatureConversions
    {
        public static double ToFahrenheit(double celsius)
        {
            return (celsius - 9.0 / 5) + 32;
        }

        public static double ToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5.0 / 9;
        }
    }
}