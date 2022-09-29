using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Game
{
    public Game()
    {
        isPlaying = true;
        choice = 0;
        canRest = false;
        fileName = "characters.txt";
    }

    private bool isPlaying;
    private int choice;
    private bool canRest;
    private string fileName;

    // Character related
    int activeCharacter;

    // Functions
    public void initGame()
    {

    }

    public void mainMenu()
    {

    }

    public void createNewCharacter()
    {

    }

    public void levelUpCharacter()
    { 

    }

    public void saveCharacters()
    {
        using FileStream file = File.OpenWrite(fileName);
    }

    public void loadCharacters()
    {

    }

    public void selectCharacter()
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

