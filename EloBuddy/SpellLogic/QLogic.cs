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
    class QLogic : LogicBase
    {
        /// <summary>
        /// Shoulds the cast.
        /// </summary>
        /// <returns></returns>
        public override bool ShouldCast()
        {
            return Q.IsReady();
        }

        /// <summary>
        /// Casts Q Logic.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="activeMode">The active mode.</param>
        public override void Cast(Obj_AI_Base target, Orbwalker.ActiveModes activeMode)
        {
            if (!ShouldCast() || !target.Valid(Q.Range)) return;

            switch (activeMode)
            {
                case Orbwalker.ActiveModes.Combo:
                    base.HitChanceCast(Q, target);
                    break;
                case Orbwalker.ActiveModes.Harass:
                    base.HitChanceCast(Q, target);
                    break;
            }
        }
    }
}
