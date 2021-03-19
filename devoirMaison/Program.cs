using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devoirMaison.Character;

namespace devoirMaison
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Début battle");

            var fighters = new List<CharacterFeatures>
            {
                new Guerrier(),
                new Magicien(), 
                new Assassin(), 
                new Robot(), 
                new Necromancien(),
                new Pretre(),
                new Berserker(), 
                new Zombie(),
                new Vampire(),
                new Illusionniste(), 
                new Paladin(), 
                new Alchimiste(),
            };

            Console.WriteLine("Fithers: ");
            foreach (var fighter in fighters)
            {
                Console.WriteLine($"{fighter}");
            }

            var fight = new Fight(fighters);

            var results = await fight.Launch();

            Console.WriteLine("Fin battle");

            Console.WriteLine("Résultats");
            var i = 0;
            foreach (var result in results)
            {
                Console.WriteLine($"{result} obtient {i} points");
                i++;
            }

            var winner = fighters.FirstOrDefault(x => !x.IsDead());
            Console.WriteLine($"And the winner is : {winner} with {i} point");
        }
    }
}