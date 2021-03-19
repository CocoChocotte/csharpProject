using devoirMaison.Models;

namespace devoirMaison.Character
{
    public class Pretre: CharacterFeatures
    {
        public Pretre() {
            Attack = 100;
            Defense = 125;
            AttackSpeed = 1.5f;
            Damages = 90;
            MaximumLife = 150;
            CurrentLife = 150;
            PowerSpeed = 1;
            IsUndead = false;
            DamageType = EDamageType.Holy;
        }

        public override void Power()
        {
            CurrentLife = CurrentLife + (MaximumLife * 10 / 100);
        }
        
        public override string ToString()
        {
            return $"Pretre {Id}. Vie: {CurrentLife}";
        }
    }
}