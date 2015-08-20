namespace GameObjects.TroopDetail
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct TroopSounds
    {
        public string MovingSoundPath;
        public string NormalAttackSoundPath;
        public string CriticalAttackSoundPath;
    }
}

