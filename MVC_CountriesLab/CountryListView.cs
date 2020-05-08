using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_CountriesLab
{
    class CountryListView
    {
        public List<Country> Countries { get; set; } = new List<Country>();
        public CountryListView(List<Country> countries)
        {
            Countries = countries;
        }

        public void Display()
        {
            int counter = 0;
            foreach (Country country in Countries)
            {
                counter++;
                Console.WriteLine($"{counter}. {country.Name}");
            }

            /*string tst = string.Join(" ", )*/
        }
    }
}
