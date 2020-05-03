using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
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
            Terminal.WriteLine("Sprobuj jeszcze raz");
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "tosia")
        {
            ShowMainMenu("Czesc Tosiu");
        }
        else if (input == "1")
        {
            level = 1;
            password = "worek";
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = "toyota";
            StartGame();
        }
        else
        {
            Terminal.WriteLine("To nie jest prawidlowy wybor");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;

        Terminal.WriteLine("Wybrałeś poziom " + level);
    }

    // Update is called once per frame
    void Update()
    {
    
        
    }
}
