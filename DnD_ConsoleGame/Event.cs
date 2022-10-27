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
        public void GenerateEvent(Character character, List<Enemy> enemies)
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

        public void EnemyEncounter(Character character, List<Enemy> enemies)
        {
            bool playerTurn = false;
            int choice = 0;

            // Coin toss for turn
            int coinToss = random.Next() % 2 + 1;
            if (coinToss == 0) playerTurn = false;
            else playerTurn = true;

            // Ending conditions
            bool escaped = false;
            bool playerDefeated = false;
            bool enemiesDefeated = false;

            // Enemies
            int nrOfEnemies = random.Next() % 5 + 1;

            for (int i = 0; i < nrOfEnemies; i++)
            {
                if (character.GetLevel() < 3)
                {
                    enemies.Add(new Enemy(character.GetLevel() + random.Next() % 2));
                }
                else
                {
                    enemies.Add(new Enemy(character.GetLevel() + random.Next() % 3));
                }
            }

            // Combat variables
            int attackRollPlayer = 0;
            int attackRollEnemy = 0;
            int battleChoice = 0;
            int damage = 0;
            int expGained = 0;
            int playerTotal = 0;
            int enemyTotal = 0;
            int combatTotal = 0;

            float _playerTotal = 0;
            float _enemyTotal = 0;

            while (!escaped && !playerDefeated && !enemiesDefeated)
            {
                if (playerTurn && !playerDefeated) // On player turn
                {
                    // Combat UI
                    Console.WriteLine(" = BATTLE MENU = ");
                    Console.WriteLine("HP: {0} / {1}", character.GetHP(), character.GetHPMax());
                    Console.WriteLine("[0] Escape");
                    Console.WriteLine("[1] Attack");
                    Console.WriteLine("[2] Defend");
                    Console.WriteLine("[3] Use Item");

                    Console.Write("\nYour choice: ");
                    while (!int.TryParse(Console.ReadLine(), out choice)) 
                    {
                        Console.Write("Wrong input! Choice: ");
                    }

                    // Moves
                    switch (choice)
                    {
                        case 0: // Escape
                            escaped = true;
                            break;

                        case 1: //Attack
                            Console.Write("\nSelect enemy: ");
                            for (int i = 0; i < enemies.Count; i++)
                            {
                                Console.WriteLine("[{0}]: Lvl {1} HP: {2} / {3}", i, enemies[i].GetLevel(), enemies[i].GetHp(), enemies[i].GetHpMax());
                            }
                            Console.Write("Choice: ");
                            while (!int.TryParse(Console.ReadLine(), out battleChoice))
                            {
                                Console.Write("Wrong input! Choice: ");
                            }
                            combatTotal = enemies[battleChoice].GetDefence() + character.GetAccuracy();
                            _enemyTotal = (float)enemies[battleChoice].GetDefence() / combatTotal * 100;
                            enemyTotal = Convert.ToInt32(_enemyTotal);
                            _playerTotal = (float)character.GetAccuracy() / combatTotal * 100;
                            playerTotal = Convert.ToInt32(_playerTotal);
                            attackRollPlayer = random.Next() % playerTotal + 1;
                            attackRollEnemy = random.Next() % enemyTotal + 1;

                            if (attackRollPlayer > attackRollEnemy) // On a hit
                            {
                                damage = character.GetDamage();
                                enemies[battleChoice].TakeDamage(damage);
                                Console.WriteLine("\nLvl {0} nemy has taken {1} damage with a failed roll ({2})", enemies[battleChoice].GetLevel(), damage, attackRollEnemy);

                                if (!enemies[battleChoice].IsAlive())
                                {
                                    expGained = enemies[battleChoice].GetExpValue();
                                    character.GainExp(expGained);
                                    enemies.RemoveAt(battleChoice);
                                    Console.WriteLine("\nAn enemy has died.");
                                    Console.WriteLine("You have gained {0} exp.", expGained);
                                }
                            }
                            else // On a miss
                            {
                                Console.WriteLine("You rolled a miss ({0}}", attackRollPlayer);
                                Console.WriteLine("Lvl {0} enemy has dodged your hit ({1})", enemies[battleChoice].GetLevel(), attackRollEnemy);
                            }
                            break;

                        case 2: // Defend
                            break;

                        case 3: // Use item
                            break;

                        default:
                            break;
                    }

                    // End turn
                    playerTurn = false;
                }
                else if (!playerTurn && !escaped && !enemiesDefeated) // On enemies' turn
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();

                    Console.WriteLine("\n = Enemy turn = ");

                    // Enemy attack
                    for (int i = 0; i < enemies.Count; i++) 
                    {
                        combatTotal = enemies[i].GetAccuracy() + character.GetDefence();
                        _enemyTotal = (float)enemies[i].GetAccuracy() / combatTotal * 100;
                        enemyTotal = Convert.ToInt32(_enemyTotal);
                        _playerTotal = (float)character.GetDefence() / combatTotal * 100;
                        playerTotal = Convert.ToInt32(_playerTotal);
                        attackRollPlayer = random.Next() % playerTotal + 1;
                        attackRollEnemy = random.Next() % enemyTotal + 1;

                        if (attackRollEnemy > attackRollPlayer) // On a hit
                        {
                            damage = enemies[i].GetDamage();
                            Console.WriteLine("\n{0} has rolled a hit ({1})", enemies[i].GetName(), attackRollEnemy);
                            Console.WriteLine("You have failed to deflect the blow ({0})", attackRollPlayer);
                            character.TakeDamage(damage);
                            Console.WriteLine("You have taken {0} damage", damage);
                            Console.WriteLine("Remaining HP: {0} / {1}", character.GetHP(), character.GetHPMax());

                            if (!character.IsAlive()) // If the player dies
                            {
                                Console.WriteLine("\nYou have been slain!");
                                playerDefeated = true;

                                // TODO player to lose exp or something like that
                            }

                        }
                        else // On a miss
                        {
                            Console.WriteLine("\n{0} has rolled a miss ({1})", enemies[i].GetName(), attackRollEnemy);
                            Console.WriteLine("You have succesfully dodged ({0}) the enemy's attack", attackRollPlayer);
                        }
                    }

                    // End turn
                    playerTurn = true;
                }

                // Conditions
                if (!character.IsAlive())
                {
                    playerDefeated = true;
                }
                else if (enemies.Count <= 0)
                {
                    enemiesDefeated = true;
                }
            }
        }

        public void PuzzleEncounter(Character character)
        {

        }
    }
}
