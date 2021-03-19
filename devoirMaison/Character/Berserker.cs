using System;
using devoirMaison.Models;

namespace devoirMaison.Character
{
    public class Berserker : CharacterFeatures
    {
        public Berserker()
        {
            Attack = 50;
            Defense = 50;
            AttackSpeed = 1.1f;
            Damages = 20;
            MaximumLife = 400;
            CurrentLife = 400;
            PowerSpeed = 1;
            IsUndead = false;
        }
        
        public override void Power()
        {
            if (CurrentLife < MaximumLife / 2)
            {
                Attack = Attack + (CurrentLife * 50 / 100);
                Damages = Damages + (CurrentLife * 50 / 100);
                AttackSpeed = (float) (AttackSpeed + 1.5);
            }
        }

        public override void Power(int corpseLife)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Berserker {Id}. Vie: {CurrentLife}";
        }
        
        
        
    }
}