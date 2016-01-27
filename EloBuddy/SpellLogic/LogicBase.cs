using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace AddonTemplate.Modes
{
    public abstract class LogicBase
    {
        protected Spell.Skillshot Q
        {
            get { return SpellManager.Q; }
        }
        protected Spell.Skillshot W
        {
            get { return SpellManager.W; }
        }
        protected Spell.Skillshot E
        {
            get { return SpellManager.E; }
        }
        protected Spell.Skillshot R
        {
            get { return SpellManager.R; }
        }

        /// <summary>
        /// Casts the specified active mode.
        /// </summary>
        /// <param name="activeMode">The active mode.</param>
        public virtual void Cast(Orbwalker.ActiveModes activeMode) { }

        /// <summary>
        /// Casts the specified enemy.
        /// </summary>
        /// <param name="enemy">The enemy.</param>
        /// <param name="activeMode">The active mode.</param>
        public virtual void Cast(Obj_AI_Base enemy, Orbwalker.ActiveModes activeMode) { }

        /// <summary>
        /// Casts the specified position.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <param name="activeMode">The active mode.</param>
        public virtual void Cast(Vector3 pos, Orbwalker.ActiveModes activeMode) { }

        public virtual bool HitChanceCast(Spell.Skillshot spell, Obj_AI_Base target, float chance = 85)
        {
            var pred = spell.GetPrediction(target);

            if (pred.HitChancePercent >= chance)
                if (spell.Cast(pred.CastPosition))
                    return true;

            return false;
        }

        /// <summary>
        /// Shoulds the cast.
        /// </summary>
        /// <returns></returns>
        public virtual bool ShouldCast() { return false; }
    }
}
