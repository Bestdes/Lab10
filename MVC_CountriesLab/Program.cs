using System;

namespace MVC_CountriesLab
{
    class Program
    {
        static void Main(string[] args)
        {
            CountryController countryController = new CountryController();
            countryController.WelcomeAction();
        }
    }
}
