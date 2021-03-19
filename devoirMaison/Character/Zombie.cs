namespace devoirMaison.Character
{
    public class Zombie: CharacterFeatures
    {
        public Zombie()
        {
            Attack = 150;
            Defense = 0;
            AttackSpeed = 1f;
            Damages = 20;
            MaximumLife = 1500;
            CurrentLife = 1500;
            PowerSpeed = 0.1f;
            IsUndead = true;
        }

        public override void Power(int corpseLife)
        {
            MaximumLife += corpseLife;
        }

        public override int GetDefenceJet()
        {
            return 0;
        }

        public override void Passive()
        {
            PoisonStack = 0;
        }
        
        public override string ToString()
        {
            return $"Zombie {Id}. Vie: {CurrentLife}";
        }
    }
}