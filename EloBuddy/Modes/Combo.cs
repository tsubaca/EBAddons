using EloBuddy;
using EloBuddy.SDK;
using Settings = AddonTemplate.Config.Modes.Combo;

namespace AddonTemplate.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            if (Settings.UseQ)
            {
                var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);

                ModeManager.QLogic.Cast(target, Orbwalker.ActiveModes.Combo);                
            }
            if (Settings.UseW)
            {
                ModeManager.WLogic.Cast(Orbwalker.ActiveModes.Combo);
            }
        }
    }
}
