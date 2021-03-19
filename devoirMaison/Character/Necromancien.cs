namespace devoirMaison.Character
{
    public class Necromancien: CharacterFeatures
    {
        public Necromancien( )
        {
            Attack = 0;
            Defense = 10;
            AttackSpeed = 1f;
            Damages = 0;
            MaximumLife = 275;
            CurrentLife = 275;
            PowerSpeed = 5;
            IsUndead = true;
        }
        
        public override string ToString()
        {
            return $"Necromancien {Id}. Vie: {CurrentLife}";
        }

        public override void Power()
        {
            IsHide = true;
        }
    }
}