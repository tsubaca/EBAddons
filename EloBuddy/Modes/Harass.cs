using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = AddonTemplate.Config.Modes.Harass;

namespace AddonTemplate.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass) || Settings.AutoHarass) && Settings.Mana;
        }

        public override void Execute()
        {
            if (Settings.UseQ)
            {
                var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
                ModeManager.QLogic.Cast(target, Orbwalker.ActiveModes.Harass);
            }
        }
    }
}
