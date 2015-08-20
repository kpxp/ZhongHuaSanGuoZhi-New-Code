namespace GameObjects
{
    using System;

    internal class FundPack
    {
        internal int Days;
        internal int Fund;

        internal FundPack(int fund, int days)
        {
            this.Fund = fund;
            this.Days = days;
        }
    }
}

