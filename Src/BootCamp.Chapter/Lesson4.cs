using System;
using System.Globalization;

namespace BootCamp.Chapter
{
    class Lesson4
    {
  
        const string NameMessage = "Enter your name: ";
        const string AgeMessage = "Enter your age: ";
        const string WeightMessage = "Enter your weight (in kg): ";
        const string HeightMessage = "Enter your height (in cm): ";
        
        public static void Demo()
        {
            float weight = 70;
            float height = 1.75f;
            //PromptStats();
            //PromptStats();
            Console.Write("CalculateBmi: {0}", CalculateBmi(weight, height));
        }

        public static void PromptStats()
        {
            string name = PromptString(NameMessage);
            int age = PromptInt(AgeMessage);
            float weight = PromptFloat(WeightMessage);
            float height = PromptFloat(HeightMessage);
            float bmi = CalculateBmi(weight, height);

            const string response = "{name} is {age} years old, he has a BMI of {bmi} with a weight of {weight} kg and a height of {height} meters.";
            if (bmi > 0) { Console.WriteLine(response, name, age, bmi, weight, height); }
        }

        public static float PromptFloat(string message)
        {
            string input = PromptInput(message);

            bool isFloat = float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out float result);
            if (isFloat) { return result; }

            PrintIsInvalidNumber(input);
            return (string.IsNullOrEmpty(input)) ? 0 : -1;
        }

        public static int PromptInt(string message)
        {
            string input = PromptInput(message);

            bool isInteger = int.TryParse(input, out int number);
            if (isInteger) { return number; }

            PrintIsInvalidNumber(input);
            return (string.IsNullOrEmpty(input)) ? 0 : -1;
        }

        public static void PrintIsInvalidNumber(string input)
        {
            Console.WriteLine("\"" + input + "\"" + " is not a valid number.");
        } 

        public static string PromptString(string message)
        {
            string input = PromptInput(message);

            if (!string.IsNullOrEmpty(input)) { return input; }
            
            Console.WriteLine("Name cannot be empty.");
            return "-";
        }        

        public static float CalculateBmi(float weight, float height)
        {
            if (height <= 0 || weight <= 0)
            {
                Console.WriteLine("Failed calculating BMI. Reason:");
                if (height <= 0) { Console.WriteLine("Height cannot be less than zero, but was {0}.", height); }
                if (weight <= 0) { Console.WriteLine("Weight cannot be equal or less than zero, but was {0}.", weight); }
                return -1;
            }
            return weight / height / height;
        }

        public static string PromptInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine().Trim();
        }
    }
}
