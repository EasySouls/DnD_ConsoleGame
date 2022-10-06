using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_ConsoleGame
{
    class Character
    {
        //Inventory inventory
        //Weapon weapon;
        //Armor armor_head;
        //Armor armor_chest;
        //Armor armor_arms;
        //Armor armor_legs;

        private int distanceTraveled;
        private int gold;

        private string name;
        private int level;
        private int exp;
        private int expNext;

        private int strength;
        private int dexterity;
        private int constitution;
        private int intelligence;
        private int wisdom;
        private int charisma;

        private int hp;
        private int hpMax;
        private int stamina;
        private int staminaMax;
        private int damageMin;
        private int damageMax;
        private int defence;
        private int accuracy;
        private int luck;

        private int statPoints;
        private int skillPoints;

        public Character()
        {
            distanceTraveled = 0;
            gold = 0;
            name = "";
            level = 0;
            exp = 0;
            expNext = 0;

            strength = 0;
            dexterity = 0;
            constitution = 0;
            intelligence = 0;
            wisdom = 0;
            charisma = 0;

            hp = 0;
            hpMax = 0;
            stamina = 0;
            staminaMax = 0;
            damageMin = 0;
            damageMax = 0;
            defence = 0;
            accuracy = 0;
            luck = 0;

            statPoints = 0;
            skillPoints = 0;
        }

        public Character(string name, int distanceTraveled, int gold, int level, int exp, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int hp, int stamina, int statPoints, int skillPoints)
        {
            this.distanceTraveled = distanceTraveled;
            this.gold = gold;
            this.name = name;
            this.level = level;
            this.exp = exp;
            this.strength = strength;
            this.dexterity = dexterity;
            this.constitution = constitution;
            this.intelligence = intelligence;
            this.wisdom = wisdom;
            this.charisma = charisma;
            this.hp = hp;
            this.stamina = stamina;
            this.statPoints = statPoints;
            this.skillPoints = skillPoints;

            UpdateStats();
        }


        // Functions
        public void Initialize(string name)
        {
            // When the character first loads
            this.name = name;

            distanceTraveled = 0;
            gold = 10;
            level = 1;
            exp = 0;
            expNext = 100;

            strength = 5;
            dexterity = 5;
            constitution = 5;
            intelligence = 5;
            wisdom = 5;
            charisma = 5;

            hpMax = (constitution * 2) + (strength / 2) + (level * 10);
            hp = hpMax;
            staminaMax = constitution + (constitution / 2) + (dexterity / 2);
            stamina = staminaMax;
            damageMin = strength;
            damageMax = strength + (level / 2);
            defence = dexterity + (intelligence / 2);
            accuracy = dexterity + intelligence;
            luck = intelligence + (charisma / 2);

            statPoints = 0;
            skillPoints = 0;
        }

        public void PrintStats()
        {
            // lazyyyyyyyyyy
        }

        public void LevelUp()
        {
            if (exp >= expNext)
            {
                exp -= expNext;
                level++;
                expNext = (expNext * 2) + (level * 100);

                statPoints++;
                skillPoints++;

                UpdateStats();

                Console.WriteLine("You have leveled up. You are now level {0}!\n", level);
            }
            else
            {
                Console.WriteLine("Not enough exp to level up!\n");
            }
        }
        //TODO
        public string GetAsString()
        {
            return null;
        }

        public string GetAsString2()
        {
            return null;
        }

        public void UpdateStats()
        {
            hpMax = (constitution * 2) + (strength / 2) + (level * 10);
            staminaMax = constitution + (constitution / 2) + (dexterity / 2);
            damageMin = strength;
            damageMax = strength + (level / 2);
            defence = dexterity + (intelligence / 2);
            accuracy = dexterity + intelligence;
            luck = intelligence + (charisma / 2);
        }

        public void AddToStat(int stat, int value)
        {
            switch (stat)
            {
                case 1: //STR
                    strength += value;
                    UpdateStats();
                    Console.WriteLine("Your strength has leveled up by {0}/\n", value);
                    break;
                case 2: //DEX
                    dexterity += value;
                    UpdateStats();
                    Console.WriteLine("Your dexterity has leveled up by {0}/\n", value);
                    break;
                case 3: //CON
                    constitution += value;
                    UpdateStats();
                    Console.WriteLine("Your constitution has leveled up by {0}/\n", value);
                    break;
                case 4: //INT
                    intelligence += value;
                    UpdateStats();
                    Console.WriteLine("Your intelligence has leveled up by {0}/\n", value);
                    break;
                case 5: //WIS
                    wisdom += value;
                    UpdateStats();
                    Console.WriteLine("Your wisdom has leveled up by {0}/\n", value);
                    break;
                case 6: //CHA
                    charisma += value;
                    UpdateStats();
                    Console.WriteLine("Your charisma has leveled up by {0}/\n", value);
                    break;
            }
        }

        public void TakeDamage(int value)
        {
            hp -= damageMax;

            if (hp < 0)
            {
                hp = 0;

                // Character dies
            }
        }

        public void Heal(int value) 
        {
            hp += value;

            if (hp > hpMax)
            {
                hp = hpMax;
            }
        }

        // Accessors
        public int GetDistanceTraveled() { return this.distanceTraveled; }
        public string GetName() { return this.name; }
        public int GetLevel() { return this.level; }
        public int GetExp() { return this.exp; }
        public int GetExpNext() { return this.expNext; }
        public int GetHP() { return this.hp; }
        public int GetHPMax() { return this.hpMax; }
        public bool IsAlive() { return this.hp > 0; }
        public int GetStamina() { return this.stamina; }
        public int GetDamageMin() { return this.damageMin; }
        public int GetDamageMax() { return this.damageMax; }
        public int GetDefence() { return this.defence; }
        public int GetAccuracy() { return this.accuracy; }
        public int GetStatPoints() { return this.statPoints; }
        public int GetSkillPoints() { return this.skillPoints; }
        public int GetStrength() { return this.strength; }
        public int GetDexterity() { return this.dexterity; }
        public int GetConstituion() { return this.constitution; }
        public int GetIntelligence() { return this.intelligence; }
        public int GetWisdom() { return this.wisdom; }
        public int GetCharisma() { return this.charisma; }


        // Modifiers
        public void SetDistanceTraveled(int distance) { this.distanceTraveled = distance; }
        public void Travel() { this.distanceTraveled++; }
        public void GainExp(int exp) { this.exp += exp; }
        public void UpgradeStrenght() { this.strength++; UpdateStats(); }
        public void UpgradeDexterity() { this.dexterity++; UpdateStats(); }
        public void UpgradeConstitution() { this.constitution++; UpdateStats(); }
        public void UpgradeIntelligence() { this.intelligence++; UpdateStats(); }
        public void UpgradeWisdom() { this.wisdom++; UpdateStats(); }
        public void UpgradeCharisma() { this.charisma++; UpdateStats(); }
    }
}
