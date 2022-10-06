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

    private bool isPlaying = false;

    // Functions
    void initGame()
    {
        CreateNewCharacter();
    }

    public void MainMenu()
    {

    }

    void mainMenu()
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

    void createNewCharacter()
    {

    }

    void levelUpCharacter()
    { 

    }

    void saveCharacters()
    {
        using FileStream file = File.OpenWrite(fileName);
    }

    void loadCharacters()
    {
        Console.WriteLine("Select character: ");

        for (int i = 0; i < characters.Count; i++)
        {
            Console.WriteLine("[{0}] {1} (lvl {2})", i, characters[i].GetName(), characters[i].GetLevel());
        }

    void selectCharacter()
    {

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

    void Rest()
    {

    }

        // Accessors
    public bool GetPlaying()
    {
        return isPlaying;
    }
}

