using devoirMaison.Models;

namespace devoirMaison.Character
{
    public class Paladin: CharacterFeatures
    {
        public Paladin()
        {
            Attack = 60;
            Defense = 145;
            AttackSpeed = 1.6f;
            Damages = 40;
            MaximumLife = 250;
            CurrentLife = 250;
            PowerSpeed = 0.5f;
            IsUndead = false;
            DamageType = EDamageType.Holy;
        }

        public override void Power()
        {
            PowerDelay = 0;
        }
        
        public override string ToString()
        {
            return $"Paladin {Id}. Vie: {CurrentLife}";
        }
    }
}