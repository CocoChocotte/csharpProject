using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devoirMaison.Character;

namespace devoirMaison
{
    public class Fight
    {
        private List<CharacterFeatures> Fighters { get; set; }
        private Random Random;
        private List<CharacterFeatures> DeadFighters { get; set; }

        public Fight(List<CharacterFeatures> fighters)
        {
            Fighters = fighters;
            Random = new Random();
            DeadFighters = new List<CharacterFeatures>();
        }

        public async Task<List<CharacterFeatures>> Launch()
        {
            Fighters.ForEach(x =>
            {
                x.OnPower += (sender, e) =>
                {
                    if (Fighters.Count <= 1)
                    {
                        return;
                    }

                    var fighter = sender as CharacterFeatures;

                    if (fighter.CurrentLife > 0)
                    {
                        //Console.WriteLine($"{fighter} utilise son pouvoir");

                        CharacterFeatures enemy;
                        switch (fighter)
                        {
                            case Zombie:
                                enemy = GetDeadEnemy(fighter);
                                fighter.Power(enemy.MaximumLife);
                                break;
                            case Vampire:
                                enemy = GetEnemy(fighter);
                                fighter.Power(enemy);
                                break;
                            case Pretre:
                                fighter.Power();
                                break;
                            case Assassin:
                                if (GetNumberOfAliveFighter() > 5)
                                {
                                    fighter.Power();
                                }
                                break;
                            case Necromancien:
                                if (DeadFighters.Count == 0)
                                {
                                    fighter.Power();
                                }
                                else
                                {
                                    fighter.IsHide = false;
                                }
                                break;
                            default:
                                //fighter.Power();
                                break;
                        }
                    }
                };

                x.OnDeath += (sender, args) =>
                {
                    var deadGuy = sender as CharacterFeatures;
                    if (DeadFighters.All(dead => deadGuy != null && dead.Id != deadGuy.Id))
                    {
                        DeadFighters.Add(deadGuy);
                        Fighters.Remove(deadGuy);

                        Console.WriteLine($"Bouhouhou {deadGuy} is dead");
                    }

                };

                x.OnAttack += (sender, e) =>
                {
                    if (Fighters.Count <= 1)
                    {
                        return;
                    }

                    var fighter = sender as CharacterFeatures;

                    if (fighter.CurrentLife > 0)
                    {
                        var enemy = GetEnemy(fighter);

                        //Console.WriteLine($"{fighter} attaque {enemy}");

                        enemy.SufferAttack(fighter, fighter.DamageType);
                        
                        if (enemy.IsDead())
                        {
                            Death(enemy);
                        }

                        if (fighter.IsDead())
                        {
                            Death(fighter);
                        }
                    }
                };

                x.StartFight();
            });

            do
            {
                await Task.Delay(2000);
            } while (Fighters.Count(x => !x.IsDead()) > 1);

            await Task.Delay(5000);

            return DeadFighters.Distinct().ToList();
        }


        protected void Death(CharacterFeatures deadGuy)
        {
            deadGuy.AttackTimer.Stop();
            deadGuy.PowerTimer.Stop();

            if (DeadFighters.All(dead => deadGuy != null && dead.Id != deadGuy.Id))
            {
                DeadFighters.Add(deadGuy);
                Fighters.Remove(deadGuy);
            }
        }

        public CharacterFeatures GetEnemy(CharacterFeatures fighter)
        {
            CharacterFeatures enemy;

            if (fighter is Pretre)
            {
                enemy = Fighters.FirstOrDefault(x => x.IsUndead);

                if (enemy != null)
                {
                    return enemy;
                }
            }

            do
            {
                var otherFighters = Fighters
                    .Where(x => x.Id != fighter.Id && !x.IsDead() && x.CurrentLife > 0 && !x.IsHide).ToList();

                //AfficherListeEnnemi(otherFighters);

                if (otherFighters.Count == 0)
                {
                    otherFighters = Fighters
                        .Where(x => x.Id != fighter.Id && !x.IsDead() && x.CurrentLife > 0 && x.IsHide).ToList();
                }

                var randomEnemy = Random.Next(otherFighters.Count(f => f.Id != fighter.Id && !f.IsDead()));

                enemy = otherFighters[randomEnemy];
            } while (enemy.Id == fighter.Id);

            return enemy;
        }

        private void AfficherListeEnnemi(List<CharacterFeatures> list)
        {
            Console.WriteLine("Liste ennemis potentiels");
            foreach (var fighter in list)
            {
                Console.WriteLine($"{fighter}");
            }
        }

        public CharacterFeatures GetDeadEnemy(CharacterFeatures fighter)
        {
            CharacterFeatures enemy;
            do
            {
                var otherFighters = Fighters.Where(x => x.Id != fighter.Id && x.IsDead() && !x.IsDevoured).ToList();

                var randomEnemy = Random.Next(otherFighters.Count(f => f.Id != fighter.Id));

                enemy = otherFighters[randomEnemy];
            } while (enemy.Id == fighter.Id);

            return enemy;
        }

        private int GetNumberOfAliveFighter()
        {
            return Fighters.Count(x => !x.IsDead());
        }
    }
}