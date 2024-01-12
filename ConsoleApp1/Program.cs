using System.Reflection.Emit;
using System.Text;

class Program
{
    static void Main()
    {
        int length = 8;
        bool includeCapitalLetters = true;
        bool includeAlphanumeric = true;
        bool includeSpecialCharacters = true;        

        Console.WriteLine("Random Password Generator");

Start:

        // Get user input
        Console.Write("Use Default values? (y/n)");
        bool useDefault = Console.ReadLine().ToLower() == "y";

        if (!useDefault)
        {
            Console.Write("Enter password length: ");
            length = int.Parse(Console.ReadLine());

            Console.Write("Include alphanumeric characters? (y/n): ");
            includeAlphanumeric = Console.ReadLine().ToLower() == "y";

            Console.Write("Include capital letters? (y/n): ");
            includeCapitalLetters = Console.ReadLine().ToLower() == "y";

            Console.Write("Include special characters? (y/n): ");
            includeSpecialCharacters = Console.ReadLine().ToLower() == "y";
        }

        // Generate random password
        string password = GeneratePassword(length, includeAlphanumeric, includeCapitalLetters, includeSpecialCharacters);

        // Display the generated password
        Console.WriteLine($"Generated Password: {password}");

        Console.Write("Another one? (y/n)");
        bool anotherOne = Console.ReadLine().ToLower() == "y";

        if(anotherOne)
        {
            goto Start;
        }
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
