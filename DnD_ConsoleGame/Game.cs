using DnD_ConsoleGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class Game
{
    private int choice;
    private bool isPlaying;
    private bool canRest;

    // Character related
    private int activeCharacter;
    private List<Character> characters = new List<Character>();
    private string fileName;

    // Enemies
    // dArray<Enemy> enemies;

    public Game() 
    {
        choice = 0;
        canRest = false;
        isPlaying = true;
        activeCharacter = 0;
        fileName = "characters.txt";
    }

    // Functions
    public void InitGame()
    {
        CreateNewCharacter();
    }

    public void MainMenu()
    {

    }

    public void CreateNewCharacter()
    {
        Console.Write("Enter the name of your character: ");
        string? name = Console.ReadLine();

        for (int i = 0; i < characters.Count; i++)
        {
            while (name == characters[i].GetName())
            {
                Console.WriteLine("Error! Character with the same name already exists!");
                Console.Write("Enter the name of your character: ");
                name = Console.ReadLine();
            }
        }

        characters.Add(Character());
        activeCharacter = characters.Count - 1;
        if (name != null) 
        {
            characters[activeCharacter].Initialize(name);
        }
    }

    public void LevelUpCharacter()
    { 

    }

    public void SaveCharacters()
    {

    }

    public void LoadCharacters()
    {

    }

    public void SelectCharacter()
    {

    }

    public void Travel()
    { 

    }

    public void Rest()
    {

    }

        // Accessors
    public bool GetPlaying()
    {
        return isPlaying;
    }
}

