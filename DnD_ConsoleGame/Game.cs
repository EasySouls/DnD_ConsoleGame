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
    List<Character> characters;
    private string fileName;

    // Enemies 
    Enemy[] enemies; //TODO make this a dinamic array

    public Game()
    {
        choice = 0;
        canRest = false;
        isPlaying = true;
        activeCharacter = 0;
        fileName = "characters.txt";
        characters = new List<Character>();
        enemies = new Enemy[100];
    }

    // Functions
    public void InitGame()
    {
        CreateNewCharacter();
    }

    public void MainMenu()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();

        Character c = characters[activeCharacter];
        if (c.IsAlive())
        {
            Console.WriteLine("= MAIN MENU =\n");
            Console.WriteLine("Active character: {0} (lvl {1}) HP: {2} / {3}", c.GetName(), c.GetLevel(), c.GetHP(), c.GetHPMax());

            if (c.GetExp() >= c.GetExpNext())
            {
                Console.WriteLine("Level up available!");
            }
            Console.WriteLine("\n[0] Quit");
            Console.WriteLine("[1] Travel");
            Console.WriteLine("[2] Shop");
            Console.WriteLine("[3] Level up");
            Console.WriteLine("[4] Rest");
            Console.WriteLine("[5] Character sheet");
            Console.WriteLine("[6] Create new character");
            Console.WriteLine("[7] Save characters");
            Console.WriteLine("[8] Load characters");
            Console.WriteLine("[9] Select character");

            Console.Write("Choice: ");
            int.TryParse(Console.ReadLine(), out choice);
            while (choice < 0 || choice > 9)
            {
                Console.Write("Wrong input! Choice: ");
                int.TryParse(Console.ReadLine(), out choice);
            }

            switch (choice)
            {
                case 0: //QUIT
                    isPlaying = false;
                    break;

                case 1: //TRAVEL
                    Travel();
                    break;

                case 2: //SHOP
                    break;

                case 3: //LEVEL UP
                    LevelUpCharacter();
                    break;

                case 4: //REST
                    Rest();
                    break;

                case 5: //CHARACTER SHEET
                    c.PrintStats();
                    break;

                case 6: //CREATE NEW CHARACTER
                    CreateNewCharacter();
                    SaveCharacters();
                    break;

                case 7: //SAVE CHARACTER
                    SaveCharacters();
                    break;

                case 8: //LOAD CHARACTERS
                    LoadCharacters();
                    break;

                case 9: //SELECT CHARACTER
                    SelectCharacter();
                    break;

                default:
                    break;
            }
        }
        else
        {
            Console.WriteLine("YOU ARE DEAD!");
            Console.WriteLine("Press [1] to load a previous character or press [0] to quit.");
            int.TryParse(Console.ReadLine(), out choice);
            while (choice < 0 || choice > 1)
            {
                Console.Write("Wrong input! Choice: ");
                int.TryParse(Console.ReadLine(), out choice);
            }

            if (choice == 1)
            {
                LoadCharacters();
                SelectCharacter();
            }
            else
            {
                Console.WriteLine("You have failed to live up to the expectations, adventurer.");
                isPlaying = false;
            }
        }
    }

    public void CreateNewCharacter()
    {
        string? name;
        Console.Write("Enter the name of your character: ");
        name = Console.ReadLine();

        if (name != null || name != "")
        {
            for (int i = 0; i < characters.Count; i++)
            {
                while (name == characters[i].GetName())
                {
                    Console.WriteLine("Error! A character with the same name already exists!");
                    Console.Write("Enter the name of your character: ");
                    name = Console.ReadLine();
                }
            }

            characters.Add(new Character());
            activeCharacter = characters.Count - 1;
            characters[activeCharacter].Initialize(name);
        }
    }

    public void LevelUpCharacter()
    {
        characters[activeCharacter].LevelUp();
        int unspentStatPoints = characters[activeCharacter].GetStatPoints();
        int unspentSkillPoints = characters[activeCharacter].GetSkillPoints();
        Character c = characters[activeCharacter];

        if (unspentSkillPoints > 0)
        {
            Console.WriteLine("YOu have {0} unspent stat points.", unspentStatPoints);
            Console.WriteLine("Stat to upgrade: ");
            Console.WriteLine("[1] Strength ({0})", c.GetStrength());
            Console.WriteLine("[2] Dexterity ({0})", c.GetDexterity());
            Console.WriteLine("[3] Constitution ({0})", c.GetConstitution());
            Console.WriteLine("[4] Intelligence ({0})", c.GetIntelligence());
            Console.WriteLine("[5] Wisdom ({0})", c.GetWisdom());
            Console.WriteLine("[6] Charisma ({0})", c.GetCharisma());

            Console.Write("Your choice: ");
            int.TryParse(Console.ReadLine(), out choice);
            while (choice < 0 || choice > 6)
            {
                Console.Write("Wrong input! Choice: ");
                int.TryParse(Console.ReadLine(), out choice);
            }

            switch (choice)
            {
                case 1:
                    c.UpgradeStrenght();
                    c.AddToStatPoints(-1);
                    Console.WriteLine("Strength upgraded.");
                    break;

                case 2:
                    c.UpgradeDexterity();
                    c.AddToStatPoints(-1);
                    Console.WriteLine("Dexterity upgraded.");
                    break;

                case 3:
                    c.UpgradeConstitution();
                    c.AddToStatPoints(-1);
                    Console.WriteLine("Constitution upgraded.");
                    break;

                case 4:
                    c.UpgradeIntelligence();
                    c.AddToStatPoints(-1);
                    Console.WriteLine("Intelligence upgraded.");
                    break;

                case 5:
                    c.UpgradeWisdom();
                    c.AddToStatPoints(-1);
                    Console.WriteLine("Wisdom upgraded.");
                    break;

                case 6:
                    c.UpgradeCharisma();
                    c.AddToStatPoints(-1);
                    Console.WriteLine("Charisma upgraded.");
                    break;

                default:
                    Console.WriteLine("Error! Press level up again to upgrade your stats!");
                    break;
            }

            c.UpdateStats();
        }
        else
        {
            Console.WriteLine("\nYou have no unspent stat points.");
        }
    }

    public void SaveCharacters()
    {
        StreamWriter file = new StreamWriter(fileName);

        for (int i = 0; i < characters.Count; i++)
        {
            file.WriteLine(characters[i].GetAsString());
        }
        file.Close();

        Console.WriteLine("\n{0} is saved!", characters[activeCharacter].GetName());
    }

    public void LoadCharacters()
    {
        StreamReader file = new StreamReader(fileName);
        // TODO
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
    public bool GetPlaying() { return this.isPlaying; }
}

