using System;
using System.Collections;
using System.Collections.Generic;
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
            Terminal.WriteLine("Wygrales poziom " + level);
            currentScreen = Screen.Win;
        }
        else
        {
            Terminal.WriteLine("Nieprawidlowe haslo");
            Terminal.WriteLine("Sprobuj jeszcze raz lub wpisz menu");
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidNumber = (input=="1" || input =="2");
        if (isValidNumber)
        {
            level = int.Parse(input);
            StartGame();
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

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = level1Password[2]; // TODO randomize
                break;
            case 2:
                password = level2Password[3]; // TODO randomize
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }

        Terminal.WriteLine("Podaj haslo");
    }

    // Update is called once per frame
    void Update()
    {
    
        
    }
}
