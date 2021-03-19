using System;

namespace devoirMaison.Character
{
    public class Alchimiste: CharacterFeatures
    {
        private Random Random;
        public Alchimiste()
        {
            Attack = 50;
            Defense = 50;
            AttackSpeed = 1f;
            Damages = 30;
            MaximumLife = 150;
            CurrentLife = 150;
            PowerSpeed = 0.1f;
            IsUndead = false;
        }

        public override string ToString()
        {
            return $"Alchimiste {Id}. Vie: {CurrentLife}";
        }

        public override int GetAttackJet()
        {
            var rand = Random.Next(0,200);
            return Attack + rand;
        }
        
        // public override int GetDefenceJet()
        // {
        //     var rand = Random.Next(0,200);
        //     return Defense + rand;
        // }
        
        // public override double GetSpeedJet()
        // {
        //     var rand = Random.Next(0,200);
        //     return (1000 / PowerSpeed) - rand;
        // }
    }
}