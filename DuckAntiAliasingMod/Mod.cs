using DuckGame;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DuckAntiAliasingMod
{
    public sealed class DuckAntiAliasingMod : DisabledMod
    {
        public const string note = "Why doesn't he just make it a True Client Mod?";
        public const string note2 = "Maybe it's because he want more subscribers.";
        public const string note3 = "Oops. What a shameful little bastard.";

        protected override void OnPostInitialize()
        {
            base.OnPostInitialize();
            (typeof(Game).GetField("updateableComponents", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(MonoMain.instance) as List<IUpdateable>).Add(new updateObject(x =>
            {
                Graphics.device.MultiSampleMask = 2;
                Graphics._manager.PreferMultiSampling = true;
                Graphics._manager.ApplyChanges();
            }));
        }
    }

    public class updateObject : IUpdateable
    {
        public bool Enabled => true;

        public int UpdateOrder => 1;

        public Action<updateObject> action;

#pragma warning disable CS0067 // Unreachable code detected
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
#pragma warning restore CS0067 // Unreachable code detected

        public updateObject() { }

        public updateObject(Action<updateObject> action) { this.action = action; }

        public void Update(GameTime gameTime)
        {
            action.Invoke(this);
            RemoveThis();
        }

        public void RemoveThis()
        {
            (typeof(Game).GetField("updateableComponents", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).GetValue(MonoMain.instance) as List<IUpdateable>).Remove(this);
        }
    }
}
