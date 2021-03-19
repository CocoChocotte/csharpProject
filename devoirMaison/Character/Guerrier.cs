namespace devoirMaison.Character
{
    public class Guerrier: CharacterFeatures
    {
        public Guerrier()
        {
            Attack = 150;
            Defense = 105;
            AttackSpeed = 2.2f;
            Damages = 150;
            MaximumLife = 250;
            CurrentLife = 250;
            PowerSpeed = 0.2f;
            IsUndead = false;
            PowerDelay = 3;
        }

        public override void Power()
        {
            AttackSpeed = AttackSpeed + 0.5f;
        }
        
        public override string ToString()
        {
            return $"Guerrier {Id}. Vie: {CurrentLife}";
        }
    }
}