/*
 * 
 *      EN: Logic Programming Exercise: User Sign-up and User Sign-in.
 *      PT-BR: Exercício de Lógica de Programação: Cadastro e Login de usuário.
 *      
 *      Created by / Feito por: Gianluca Nunes
 *
 */

// Creating the Users list, where the program will store the usernames
List<string> users = new List<string>();
// Creating the Passwords list, where the program will store the passwords
List<string> passwords = new List<string>();

Console.WriteLine("---==--- USER SIGN-UP AND USER SIGN-IN ---==---");

// Asking the user if he wants to sign-up or sign-in
_beggining:
Console.WriteLine("\nHello! Do you want to sign-up [U] or sign-in [I]?");
string optBeg = Console.ReadLine();

// Validating the user choosen option
if (optBeg != "u" && optBeg != "U" && optBeg != "i" && optBeg != "I") 
{
    Console.WriteLine("\nIncorrect option. Please, try it again.\n");
    goto _beggining;
}

// Registering a new user in the system
else if (optBeg == "u" || optBeg == "U")
{
    Console.WriteLine("\n-=- SIGN-UP -=-\n");

_signUp:
    // Asking the user for the information
    Console.Write("Please, fill up the form bellow.\nUsername: ");
    string user = Console.ReadLine();
    Console.Write("Password: ");
    string password = Console.ReadLine();
    Console.Write("Confirm your password: ");
    string confPass = Console.ReadLine();

    // Validating if the password and the confirm password matches
    if (password != confPass)
    {
        Console.WriteLine("\nThe passwords does not match. Please, try it again.\n");
        goto _signUp;
    }

    // Validating if the username already exists inside the list
    foreach (string item in users)
    {
        if (item == user)
        {
            Console.WriteLine("\nThe username you typed already exists. Please, try it again.\n");
            goto _signUp;
        }
    }

    // Validating if the user left any blank field
    if (user == "" || password == "")
    {
        Console.WriteLine("\nYou cannot leave any option in blank. Please, try it again.\n");
        goto _signUp;
    }

    // If everything is okay, adds the username and its password to the lists
    users.Add(user);
    passwords.Add(password);

    Console.WriteLine("\nUser registered successfully.");
    goto _beggining;
}

// Sign-in user
else if ((optBeg == "i" || optBeg == "I") && users.Count >= 1)
{
    Console.WriteLine("\n-=- SIGN-IN -=-\n");

_signIn:
    // Creating 2 strings to store the given username and password in order to compare them later
    string givenUsername = "";
    string givenPassword = "";

    // Asking the user to fill the form
    Console.Write("In order to sign-in, fill the form bellow.\nUsername: ");
    givenUsername = Console.ReadLine();
    Console.Write("Password: ");
    givenPassword = Console.ReadLine();

    // Creating an int variable to find the position of the username inside the list
    int userPos = users.IndexOf($"{givenUsername}");
    int passwordPos = userPos;

    // If the given username does not exists inside the list, the method IndexOf will return -1. 
    // We can use this value to validate the username
    if (userPos == -1)
    {
        Console.WriteLine("\nIncorrect information. Please, try it again.\n");
        goto _signIn;
    }

    // If the given username exists inside the list, the program will try to compare the given password with the username's password inside the list.
    // If they are different, that means the user has filled the form incorrectly.
    else if (givenPassword != passwords[passwordPos])
    {
        Console.WriteLine("\nIncorrect information. Please, try it again.\n");
        goto _signIn;
    }

    // If the given username and password matches with the username and password stored inside the list, gives access to the System 
    else if (givenUsername == users[userPos] && givenPassword == passwords[passwordPos])
    {
        Console.WriteLine("\n\n-=- WELCOME TO THE SYSTEM! -=-\n");
        Console.WriteLine($"\nHello! You are logged on as {givenUsername}.\nTo disconnect, just press any key on your keyboard.");

        Console.ReadKey();

        goto _beggining;
    }
}

// Validating if there is at least 1 registered user inside the list
else if (users.Count == 0)
{
    Console.WriteLine("\nThere are 0 registered users. You need to sign-up at least 1 user before trying to sign-in.\n");
    goto _beggining;
}