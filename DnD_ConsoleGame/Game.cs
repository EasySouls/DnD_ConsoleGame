using DnD_ConsoleGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Game
{
    private int choice;
    private bool isPlaying;
    private bool canRest;

    // Character related
    private int activeCharacter;
    private List<Character> characters = new List<Character>();
    private string fileName;

    // Enemies TODO make this a dinamic array
    Enemy[] enemies;

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

        characters.Add(new Character());
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
        // TODO write to file
    }

    public void LoadCharacters()
    {

    }

    public void SelectCharacter()
    {
        Console.WriteLine("Select character: ");

        for (int i = 0; i < characters.Count; i++)
        {
            Console.WriteLine("[{0}] {1} (lvl {2})", i, characters[i].GetName(), characters[i].GetLevel());
        }

        Console.Write("Choice: ");
        int.TryParse(Console.ReadLine(), out choice);
        while (choice >= characters.Count || choice < 0)
        {
            Console.Write("Wrong input! Choice: ");
            int.TryParse(Console.ReadLine(), out choice);
        }

        activeCharacter = choice;
        Console.WriteLine("{0} is selected.", characters[activeCharacter].GetName());
    }

    public void Travel()
    {
        characters[activeCharacter].Travel();

        Event ev = new Event();
        ev.GenerateEvent(characters[activeCharacter], enemies);
        canRest = true;
    }

    public void Rest()
    {
        if (canRest)
        {
            if (characters[activeCharacter].GetHPMax() == characters[activeCharacter].GetHP())
            {
                Console.WriteLine("You are already at max hp ({0})!", characters[activeCharacter].GetHP());
            }
            else
            {
                Console.WriteLine("You take a rest.");
                int level = characters[activeCharacter].GetLevel();
                int healAmount = level * 10;
                characters[activeCharacter].Heal(healAmount);
                canRest = false;
                Console.WriteLine("You regained {0} hp!", healAmount);
            }
        }
        else
        {
            Console.WriteLine("You have already taken a rest this day. You can only rest after traveling!");
        }
    }

        // Accessors
    public bool GetPlaying()
    {
        return isPlaying;
    }
}

