using AddonTemplate.Modes;
using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lux.SpellLogic
{
    class WLogic : LogicBase
    {
        /// <summary>
        /// Shoulds the cast.
        /// </summary>
        /// <returns></returns>
        public override bool ShouldCast()
        {
            return W.IsReady();
        }

        /// <summary>
        /// Casts W Logic.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="activeMode">The active mode.</param>
        public override void Cast(Orbwalker.ActiveModes activeMode)
        {
            if (!ShouldCast()) return;

            switch (activeMode)
            {
                case Orbwalker.ActiveModes.Combo:
                    if(Player.Instance.HealthPercent <= 20 && EntityManager.Heroes.Enemies.Count(e => !e.IsDead && W.IsInRange(e)) > 0)
                    {
                        if (CastOnAlly())
                        {
                            return;
                        }
                        else
                        {
                            W.Cast(EntityManager.Heroes.Enemies.FirstOrDefault(e => !e.IsDead && W.IsInRange(e)).ServerPosition);
                        }
                    }
                    if (CastOnAlly()) return;
                    break;
                case Orbwalker.ActiveModes.Harass:
                    if (Player.Instance.HealthPercent <= 20 && EntityManager.Heroes.Enemies.Count(e => !e.IsDead && W.IsInRange(e)) > 0)
                    {
                        if (CastOnAlly())
                        {
                            return;
                        }
                        else
                        {
                            W.Cast(EntityManager.Heroes.Enemies.FirstOrDefault(e => !e.IsDead && W.IsInRange(e)).ServerPosition);
                        }
                    }
                    if (CastOnAlly()) return;
                    break;
            }
        }

        internal bool CastOnAlly()
        {
            var nearAllies = EntityManager.Heroes.Allies.Where(a => a != null && !a.IsInvulnerable && a.IsValidTarget(W.Range));

            foreach(var ally in nearAllies)
            {
                if(ally.HealthPercent <= 20 && ally.CountEnemiesInRange(550) >= 1)
                {
                    base.HitChanceCast(W, ally, 75);
                    return true;
                }
            }

            return false;
        }
    }
}
