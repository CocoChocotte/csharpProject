using System.Threading;
using devoirMaison.Models;
using Timer = System.Timers.Timer;

namespace devoirMaison.Character
{
    public class Vampire : CharacterFeatures
    {
        public int SufferedDamage;
        
        public Vampire(){
            Attack = 125;
            Defense = 125;
            AttackSpeed = 2f;
            Damages = 50;
            MaximumLife = 150;
            CurrentLife = 150;
            PowerSpeed = 0.2f;
            IsUndead = true;
            SufferedDamage = 0;
        }
        
        public override string ToString()
        {
            return $"Vampire {Id}. Vie: {CurrentLife}";
        }

        public override void SufferAttack(CharacterFeatures ennemy, EDamageType damageType)
        {
            var currentLifeBeforeAttack = CurrentLife;
            base.SufferAttack(ennemy, damageType);

            SufferedDamage += currentLifeBeforeAttack - CurrentLife;
        }

        public override void Power(CharacterFeatures cible)
        {
            cible.PowerTimer = new Timer(GetSpeedJet() + SufferedDamage);
            SufferedDamage = 0;
        }
    }
}