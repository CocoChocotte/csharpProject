namespace devoirMaison.Character
{
    public class Illusionniste:CharacterFeatures
    {
        public Illusionniste()
        {
            Attack = 75;
            Defense = 75;
            AttackSpeed = 1f;
            Damages = 50;
            MaximumLife = 100;
            CurrentLife = 100;
            PowerSpeed = 0.5f;
            IsUndead = false;
        }
        
        public override string ToString()
        {
            return $"Illusioniste {Id}. Vie: {CurrentLife}";
        }
    }
}