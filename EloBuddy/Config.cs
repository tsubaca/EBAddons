using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
namespace AddonTemplate
{
    public static class Config
    {
        private const string MenuName = "Lux";

        private static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Lux Addon");
            Menu.AddLabel("Special Thanks to Hellsing for the addon template.");

            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu Menu;

            static Modes()
            {
                Menu = Config.Menu.AddSubMenu("Modes");

                Combo.Initialize();
                Menu.AddSeparator();

                Harass.Initialize();
                Menu.AddSeparator();

                Misc.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                static Combo()
                {
                    Menu.AddGroupLabel("Combo");
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Use Q"));
                    _useW = Menu.Add("comboUseW", new CheckBox("Use W"));
                    _useE = Menu.Add("comboUseE", new CheckBox("Use E"));
                    _useR = Menu.Add("comboUseR", new CheckBox("Use R"));
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly KeyBind _autoHarass;
                private static readonly Slider _manaPercent;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static bool AutoHarass
                {
                    get { return _autoHarass.CurrentValue; }
                }
                public static bool Mana
                {
                    get { return  Player.Instance.ManaPercent > _manaPercent.CurrentValue; }
                }

                static Harass()
                {
                    Menu.AddGroupLabel("Harass");
                    _useQ = Menu.Add("harass.q", new CheckBox("Use Q"));
                    _useW = Menu.Add("harass.w", new CheckBox("Use W"));
                    _useE = Menu.Add("harass.e", new CheckBox("Use E"));
                    _autoHarass = Menu.Add("harass.auto", new KeyBind("Auto Harass", false, KeyBind.BindTypes.PressToggle));
                    _manaPercent = Menu.Add("harass.mana", new Slider("Min Mana %", 45, 0, 100));
                }

                public static void Initialize()
                {
                }
            }

            public static class Misc
            {
                private static readonly CheckBox _autoQImmobile;
                private static readonly CheckBox _autoQOnDash;
                private static readonly CheckBox _autoEOnDash;
                private static readonly CheckBox _antiGapCloserQ;
                private static readonly CheckBox _antiGapCloserW;
                private static readonly CheckBox _antiGapCloserE;
                private static readonly CheckBox _playSoundToRCast;

                public static bool AutoQImmobile
                {
                    get { return _autoQImmobile.CurrentValue; }
                }

                public static bool AutoQOnDash
                {
                    get { return _autoQOnDash.CurrentValue; }
                }

                public static bool AutoEOnDash
                {
                    get { return _autoEOnDash.CurrentValue; }
                }

                public static bool AntiGapQ
                {
                    get { return _antiGapCloserQ.CurrentValue; }
                }

                public static bool AntiGapW
                {
                    get { return _antiGapCloserW.CurrentValue; }
                }

                public static bool AntiGapE
                {
                    get { return _antiGapCloserE.CurrentValue; }
                }

                public static bool IMAFIRINGMALAZER
                {
                    get { return _playSoundToRCast.CurrentValue; }
                }

                static Misc()
                {
                    Menu.AddGroupLabel("Misc");
                    _autoQImmobile = Menu.Add("misc.immobile.q", new CheckBox("Use Q on Immobile"));
                    _autoQOnDash = Menu.Add("misc.ondash.q", new CheckBox("Use Q on Dash", false));
                    _autoEOnDash = Menu.Add("misc.ondash.e", new CheckBox("Use E on Dash", false));
                    _antiGapCloserQ = Menu.Add("misc.antigap.q", new CheckBox("Q for anti gap closers"));
                    _antiGapCloserW = Menu.Add("misc.antigap.w", new CheckBox("W for anti gap closers", false));
                    _antiGapCloserE = Menu.Add("misc.antigap.e", new CheckBox("E for anti gap closers", false));
                    _playSoundToRCast = Menu.Add("misc.lazer.sound", new CheckBox("IMAFIRINGMALAZER :========", false));
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}
