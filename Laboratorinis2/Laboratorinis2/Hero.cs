using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy
{
    class Hero
    {
        public string Name { get; set; }    //determining variables
        public string Race { get; set; }
        public string Characterclass { get; set; }
        public double HealthPoints { get; set; }
        public double Mana { get; set; }
        public double DamagePoints { get; set; }
        public double DefencePoints { get; set; }
        public double Strength { get; set; }
        public double Dexterity { get; set; }
        public double Intelligence { get; set; }
        public string SpecialPower { get; set; }

        public Hero(string name, string race, string characterclass, double healthPoints, double mana, double damagePoints, double defencePoints, double strength, double dexterity, double intelligence, string specialPower)
        {
            this.Name = name;
            this.Race = race;
            this.Characterclass = characterclass;
            this.HealthPoints = healthPoints;
            this.Mana = mana;
            this.DamagePoints = damagePoints;
            this.DefencePoints = defencePoints;
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Intelligence = intelligence;
            this.SpecialPower = specialPower;

        }
        public static List<Hero> AddList(List<Hero> Hero1, List<Hero> Hero2)
        {
            List<Hero> newHeroList = new List<Hero>();
            foreach (Hero hero in Hero1)
            {
                if (!newHeroList.Contains(hero))
                {
                    newHeroList.Add(hero);
                }
            }
            foreach (Hero hero in Hero2)
            {
                if (!newHeroList.Contains(hero))
                {
                    newHeroList.Add(hero);
                }
            }
            return newHeroList;
        }

    }
}
