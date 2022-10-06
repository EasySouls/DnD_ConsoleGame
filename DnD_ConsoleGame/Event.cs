using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_ConsoleGame
{
    internal class Event
    {
        private int nrOfEvents = 2;
        Random random;

        public Event()
        {
            random = new Random();
        }
        // TODO make this a dinamic array
        public void GenerateEvent(Character character, Enemy[] enemies)
        {
            int i = random.Next() % nrOfEvents;

            switch (i)
            {
                case 0:
                    // Enemy encounter
                    EnemyEncounter(character, enemies);
                    break;

                case 1:
                    // Puzzle
                    PuzzleEncounter(character);
                    break;
                default:
                    break;
            }
        }

        public void EnemyEncounter(Character character, Enemy[] enemies)
        {

        }

        public void PuzzleEncounter(Character character)
        {

        }
    }
}
