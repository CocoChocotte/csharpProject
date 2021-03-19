using devoirMaison.Models;

namespace devoirMaison.Character
{
    public class Assassin: CharacterFeatures
    {
        public Assassin()
        {
            Attack = 150;
            Defense = 100;
            AttackSpeed = 1f;
            Damages = 100;
            MaximumLife = 185;
            CurrentLife = 185;
            PowerSpeed = 0.5f;
            IsUndead = false;
        }
        
        public override string ToString()
        {
            return $"Assassin {Id}. Vie: {CurrentLife}";
        }

        public override void Power()
        {
            IsHide = true;
        }
        
    }
}