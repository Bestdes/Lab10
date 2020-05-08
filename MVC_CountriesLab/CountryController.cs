using System;
using System.Collections.Generic;
using System.Globalization;

namespace MVC_CountriesLab
{
    class CountryController
    {
        public List<Country> CountryDb { get; set; } = new List<Country>();
        public string ProgramName { get; set; } = "The Grand Circus Country Database Manager";

        public CountryController()
        {
            Country usa = new Country();
            usa.Name = "United States of America";
            usa.Continent = "North America";
            usa.Colors = new List<string> { "red", "white", "blue" };
            CountryDb.Add(usa);

            Country jamaica = new Country();
            jamaica.Name = "Jamaica";
            jamaica.Continent = "North America";
            jamaica.Colors = new List<string> { "green", "gold", "black"};
            CountryDb.Add(jamaica);

            Country spain = new Country();
            spain.Name = "Spain";
            spain.Continent = "Europe";
            spain.Colors = new List<string> { "red", "gold"};
            CountryDb.Add(spain);

            Country rwanda = new Country();
            rwanda.Name = "Rwanda";
            rwanda.Continent = "Africa";
            rwanda.Colors = new List<string> { "blue", "yellow"};
            CountryDb.Add(rwanda);

            Country germany = new Country();
            germany.Name = "Germany";
            germany.Continent = "Europe";
            germany.Colors = new List<string> { "black", "red", "gold" };
            CountryDb.Add(germany);

        }

        public void CountryAction(Country country)
        {
            CountryView onlyForCountryInfo = new CountryView(country);
            onlyForCountryInfo.Display();
        }

        public void WelcomeAction()
        {
            CountryListView countryListHolder = new CountryListView(CountryDb);

            string input;
            int countryNumSelection;
            int countryIndex = 0;
            bool runBehaviour = true;

            while (runBehaviour)
            {
                Console.WriteLine($"Hello, welcome to {ProgramName} app. Please select a country from the following list:\n");
                countryListHolder.Display();
                input = ReadAndReturnInput();

                try
                {
                    countryNumSelection = int.Parse(input);
                    if(countryNumSelection <= ReturnNumberInList(CountryDb))
                    {

                        foreach (Country country in CountryDb)
                        {
                            countryIndex++;
                            if(countryNumSelection == countryIndex)
                            {
                                CountryAction(country);
                                ChangeConsoleColor(country);
                                if (!CheckIfProgramShouldReRun(ProgramName))
                                {
                                    runBehaviour = false;
                                }
                            }
                        }
                        countryIndex = 0;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The number you entered is greater than the amount of countries our database." +
                            $"\nPlease enter a number less than {ReturnNumberInList(CountryDb)}\n");
                    }
                }
                catch(FormatException notANum)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input! Please enter a number.\n");
                }
                catch (OverflowException tooBig)
                {
                    Console.Clear();
                    Console.WriteLine($"The number you entered was out of range. Please enter a number from 1 to {ReturnNumberInList(CountryDb)}\n");
                }

                int counter = 0;
                foreach(Country country in countryListHolder.Countries)
                {
                    counter++;
                }
            }

        }

        private static string ReadAndReturnInput()
        {
            return Console.ReadLine();
        }

        private static Boolean CheckIfProgramShouldReRun(string programName)
        {
            Boolean askRerun = true;

            while (askRerun)
            {
                Console.WriteLine($"Do you want to run the {programName} Again? (y/n)");
                string reRunInput = Console.ReadLine();

                if (reRunInput == "y")
                {
                    askRerun = false;
                    Console.Clear();
                }
                else if (reRunInput == "n")
                {
                    Console.Clear();
                    Console.WriteLine($"Thank you for using the {programName}. Have nice day!");
                    askRerun = false;
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please input y for yes or n for no.");
                }
            }
            return true;
        }

        private static int ReturnNumberInList(List<Country> countries)
        {
            int numOfCountries = 0;
            foreach (Country country in countries)
            {
                numOfCountries++;
            }
            return numOfCountries;
        }

        private static void ChangeConsoleColor(Country country)
        {
            ConsoleColor foreColor;
            if (Enum.TryParse(ToTitleCase(country.Colors[1].ToString().Trim()), out foreColor))
            {
                Console.ForegroundColor = foreColor;
            }
            ConsoleColor backColor;
            if (Enum.TryParse(ToTitleCase(country.Colors[0].ToString().Trim()), out backColor))
            {
                Console.BackgroundColor = backColor;
            }
        }
        private static string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}
