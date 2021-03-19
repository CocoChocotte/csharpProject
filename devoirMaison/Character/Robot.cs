namespace devoirMaison.Character
{
    public class Robot: CharacterFeatures
    {
        public Robot()
        {
            Attack = 25;
            Defense = 100;
            AttackSpeed = 1.2f;
            Damages = 50;
            MaximumLife = 275;
            CurrentLife = 275;
            PowerSpeed = 0.5f;
            IsUndead = false;
        }

        public override void Power()
        {
            Attack += (Attack * 50 / 100);
            PoisonStack = 0;
        }

        public override int GetDefenceJet()
        {
            return Defense + 50;
        }

        public override int GetAttackJet()
        {
            Attack += 50;

            return base.GetAttackJet();
        }
        
        public override string ToString()
        {
            return $"Robot {Id}. Vie: {CurrentLife}";
        }
    }
}