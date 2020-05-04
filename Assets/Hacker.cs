using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Password = { "worek", "klocki", "kredka", "szatnia", "kapcie", "zabawa" };
    string[] level2Password = {"toyota", "wetrynarz","zwierzak", "lekarstwo", "przedstawiciel"};

    // Game state
    int level;
    string password;
    enum Screen { MainMenu, Password,Win }
    Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Czesc");
        currentScreen = Screen.MainMenu;
    }

    void ShowMainMenu(string greetings)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greetings);
        Terminal.WriteLine("Gdzie dzis sie wlamiemy?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Do przedszkola Tosi - nacisnij 1");
        Terminal.WriteLine("Do pracy Mamy - nacisnij 2");
        Terminal.WriteLine("Do pracy Dziadka - naciśnij 3");
        Terminal.WriteLine("");
        Terminal.WriteLine("Wpisz swoj wybor:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("Czesc");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            WinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void WinScreen()
    {
        Terminal.WriteLine("Wygrales poziom " + level);
        currentScreen = Screen.Win;
    }

    void RunMainMenu(string input)
    {
        bool isValidNumber = (input=="1" || input =="2");
        if (isValidNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }

        else if (input == "tosia") // Easter egg
        {
            ShowMainMenu("Czesc Tosiu");
        }
        else
        {
            Terminal.WriteLine("To nie jest prawidlowy wybor");
        }
    }

    void AskForPassword()
    {

        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Podaj haslo, podpowiedz: " + password.Anagram());
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Password[Random.Range(0, level1Password.Length)];
                break;
            case 2:
                password = level2Password[Random.Range(0, level2Password.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

}
