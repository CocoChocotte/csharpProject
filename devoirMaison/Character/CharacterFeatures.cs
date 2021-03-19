using System;
using System.Threading;
using System.Timers;
using devoirMaison.Models;
using Timer = System.Timers.Timer;

namespace devoirMaison.Character
{
    public abstract class CharacterFeatures
    {
        #region Variables

        public string Id { get; set; }
        
        public int Attack { get; set; }
        
        public int Defense { get; set; }
        
        //C’est un float qui représente le nombre d’attaques que le personnage peut lancer par secondes. Sa valeur varie entre 1 et 5.
        public float AttackSpeed { get; set; }
        
        //C’est un float qui représente le nombre de fois que le personnage peut utiliser son pouvoir par secondes. Sa valeur varie entre 0,1 et 5
        public float PowerSpeed { get; set; }
        
        public int Damages { get; set; }
        
        // c’est la valeur maximum que peut atteindre la vie du personnage, c’est aussi la valeur de CurrentLife au début du combat
        public  int MaximumLife { get; set; }

        //vie du personnage
        public int CurrentLife { get; set; }
        
        public EDamageType DamageType { get; set; }
        
        //taux enpoisonnement
        public int PoisonStack { get; set; }

        //bool qui détermine s'il est mort vivant
        public bool IsUndead { get; set; }

        //jet d'attaque
        public int AttackJet { get; set; }

        //delai de pouvoir
        public int PowerDelay { get; set; }
        
        //détermine s'il a été dévoré
        public bool IsDevoured { get; set; }
        
        public bool IsHide { get; set; }
        
        private Random Random;

        #endregion Variables

        #region Events

        public Timer AttackTimer;

        public Timer PowerTimer;
        public event EventHandler OnAttack;
        public event EventHandler OnPower;
        public event EventHandler OnDeath;

        #endregion Events
        
        public CharacterFeatures ()
        {
            Id = Guid.NewGuid().ToString("N");
            Random = new Random(100);
            PoisonStack = 0;
            PowerDelay = 0;
            IsDevoured = false;
            IsHide = false;

            DamageType = EDamageType.Physical;
        }

        public void StartFight()
        {
            AttackTimer = new Timer(GetSpeedJet());
            AttackTimer.Elapsed += OnAttackTimer;
            AttackTimer.AutoReset = true;
            AttackTimer.Enabled = true;
            
            PowerTimer = new Timer(GetSpeedJet());
            PowerTimer.Elapsed += OnPowerTimer;
            PowerTimer.AutoReset = true;
            PowerTimer.Enabled = true;
        }

        private void OnAttackTimer(Object source, ElapsedEventArgs e)
        {
            var handler = OnAttack;
            handler?.Invoke(this, EventArgs.Empty);
        }
        
        private void OnPowerTimer(Object source, ElapsedEventArgs e)
        {
            var handler = OnPower;
            handler?.Invoke(this, EventArgs.Empty);
        }

        public virtual void SufferAttack(CharacterFeatures ennemy, EDamageType damageType)
        {
            if (IsDead())
            {
                Death();
                return;
            }
            var margeAttack = GetMargeAttack(ennemy.GetAttackJet());

            if (margeAttack > 0)
            {
                //Console.WriteLine("Je prend une grosse tatane dans la gueule !");
                if (damageType == EDamageType.Physical || damageType == EDamageType.Holy && !IsUndead)
                {
                    CurrentLife -= margeAttack * ennemy.GetAttackJet() / 100;
                    if (CurrentLife <= 0)
                    {
                        Death();
                    }
                }
                else if (damageType == EDamageType.Holy && IsUndead)
                {
                    CurrentLife -= margeAttack * ennemy.GetAttackJet() * 2 / 100;
                    if (CurrentLife <= 0)
                    {
                        Death();
                    }
                }
                
                if (ennemy is Vampire)
                {
                    //passif: vampire se soige de 50% des dégats qu'il donné
                    ennemy.CurrentLife += Damages/2;
                }
            }
            else
            {
                //Console.WriteLine("Je contre attaque !");
                ennemy.CurrentLife += margeAttack;
            }

            if (ennemy.IsHide || IsHide)
            {
                ennemy.IsHide = false;
                IsHide = false;
            }
            

            if (CurrentLife <= 0)
            {
                Death();
            }
        }

        public int GetMargeAttack(int ennemyAttackJet)
        {
            return (ennemyAttackJet - GetDefenceJet());
        }

        public bool IsDead()
        {
            return CurrentLife <= 0;
        }

        public virtual int GetAttackJet()
        {
            var rand = Random.Next(0,100);
            return Attack + rand;
        }
        
        public virtual int GetDefenceJet()
        {
            var rand = Random.Next(0,100);
            return Defense + rand;
        }

        public virtual double GetSpeedJet()
        {
            var rand = Random.Next(0,100);
            return (1000 / PowerSpeed) - rand;
        }

        public virtual void Power(){}
        
        public virtual void Power(int corpseLife){}
        
        public virtual void Power(CharacterFeatures cible){}

        public virtual void Passive(){}

        public virtual void Passive(int degats) { }

        protected void Death()
        {
            AttackTimer.Stop();
            PowerTimer.Stop();

            var handler = OnDeath;
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}