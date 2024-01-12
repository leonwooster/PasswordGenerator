using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Random Password Generator");

        bool generateAnother = true;

        while (generateAnother)
        {
            GenerateAndDisplayPassword();

            // Ask if the user wants to generate another password
            Console.Write("Generate another password? (y/n): ");
            generateAnother = Console.ReadLine().ToLower() == "y";
        }
    }

    static void GenerateAndDisplayPassword()
    {
        // Set default values
        int defaultLength = 12;
        bool defaultIncludeAlphanumeric = true;
        bool defaultIncludeCapitalLetters = true;
        bool defaultIncludeSpecialCharacters = true;

        // Ask if the user wants to use default values for all features
        Console.Write("Use default values for all features? (y/n): ");
        bool useDefaults = Console.ReadLine().ToLower() == "y";

        // Get user input for password length
        int length = useDefaults ? defaultLength : GetInput("Enter password length: ", defaultLength);

        // Get user input for including alphanumeric characters
        bool includeAlphanumeric = useDefaults ? defaultIncludeAlphanumeric : GetYesNoInput("Include alphanumeric characters? (y/n): ", defaultIncludeAlphanumeric);

        // Get user input for including capital letters
        bool includeCapitalLetters = useDefaults ? defaultIncludeCapitalLetters : GetYesNoInput("Include capital letters? (y/n): ", defaultIncludeCapitalLetters);

        // Get user input for including special characters
        bool includeSpecialCharacters = useDefaults ? defaultIncludeSpecialCharacters : GetYesNoInput("Include special characters? (y/n): ", defaultIncludeSpecialCharacters);

        // Generate and display the password
        string password = GeneratePassword(length, includeAlphanumeric, includeCapitalLetters, includeSpecialCharacters);
        Console.WriteLine($"Generated Password: {password}");
    }

    static int GetInput(string prompt, int defaultValue)
    {
        while (true)
        {
            Console.Write($"{prompt} (default: {defaultValue}): ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                return defaultValue;
            }

            if (int.TryParse(input, out int result) && result > 0)
            {
                return result;
            }

            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
    }

    static bool GetYesNoInput(string prompt, bool defaultValue)
    {
        Console.Write($"{prompt} (default: {(defaultValue ? "y" : "n")}): ");
        string input = Console.ReadLine().ToLower();

        if (string.IsNullOrWhiteSpace(input))
        {
            return defaultValue;
        }

        return input == "y";
    }

    static string GeneratePassword(int length, bool includeAlphanumeric, bool includeCapitalLetters, bool includeSpecialCharacters)
    {
        string lowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
        string uppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string numbers = "0123456789";
        string specialCharacters = "!@#$%^&*()-_=+";

        StringBuilder passwordBuilder = new StringBuilder();
        Random random = new Random();

        // Determine the set of characters to use
        string validCharacters = lowercaseLetters;
        if (includeAlphanumeric)
            validCharacters += numbers;
        if (includeCapitalLetters)
            validCharacters += uppercaseLetters;
        if (includeSpecialCharacters)
            validCharacters += specialCharacters;

        // Generate the password
        for (int i = 0; i < length; i++)
        {
            char randomChar = validCharacters[random.Next(validCharacters.Length)];
            passwordBuilder.Append(randomChar);
        }

        return passwordBuilder.ToString();
    }
}
