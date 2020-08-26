using DuckGame;

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
            Graphics.device.MultiSampleMask = 2;
            Graphics._manager.PreferMultiSampling = true;
            Graphics._manager.ApplyChanges();
        }
    }
}
