using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_CountriesLab
{
    class CountryView
    {
        public Country DisplayCountry { get; set; } = new Country();

        /*public Country DisplayCountry;*/
        public CountryView(Country country)
        {
            DisplayCountry = country;
        }

        public void Display()
        {
            StringBuilder colorString = new StringBuilder();
            foreach (string color in DisplayCountry.Colors)
            {
                colorString.Append(color).Append(" ");
            }

            Console.WriteLine($"\tName: {DisplayCountry.Name}\n\tContinent: {DisplayCountry.Continent}\n\tColor(s): {colorString.ToString()}\n");

            /*string tst = string.Join(" ", )*/

        }

    }
}
