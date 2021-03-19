namespace devoirMaison.Character
{
    public class Magicien: CharacterFeatures
    {
        public Magicien()
        {
            Attack = 75;
            Defense = 125;
            AttackSpeed = 1.5f;
            Damages = 100;
            MaximumLife = 125;
            CurrentLife = 125;
            PowerSpeed = 0.1f;
            IsUndead = false;
        }
        
        public override string ToString()
        {
            return $"Magicien {Id}. Vie: {CurrentLife}";
        }
    }
}