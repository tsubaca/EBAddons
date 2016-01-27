﻿using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace AddonTemplate
{
    public static class Program
    {
        public const string ChampName = "Lux";

        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName != ChampName)
            {
                return;
            }

            Config.Initialize();
            SpellManager.Initialize();
            ModeManager.Initialize();

            Drawing.OnDraw += OnDraw;

            /*
            Fully Loaded
            */

            ShowDisplayMessage();
        }

        private static void OnDraw(EventArgs args)
        {
            // Draw range circles of our spells
            Circle.Draw(Color.Red, SpellManager.Q.Range, Player.Instance.Position);
            // TODO: Uncomment if you want those enabled aswell, but remember to enable them
            // TODO: in the SpellManager aswell, otherwise you will get a NullReferenceException
            //Circle.Draw(Color.Red, SpellManager.W.Range, Player.Instance.Position);
            //Circle.Draw(Color.Red, SpellManager.E.Range, Player.Instance.Position);
            //Circle.Draw(Color.Red, SpellManager.R.Range, Player.Instance.Position);
        }

        private static void ShowDisplayMessage()
        {
            var r = new Random();
            try
            {
                var sr = new System.IO.StreamReader(System.Net.WebRequest.Create(string.Format("https://raw.githubusercontent.com/tsubaca/Nope/master/lux.name")).GetResponse().GetResponseStream());
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }catch{}
        }
    }
}
