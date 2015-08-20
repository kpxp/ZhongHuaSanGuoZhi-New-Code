namespace GameObjects
{
    using GameObjects.TroopDetail.EventEffect;
    using System;

    public class TroopEffectArea
    {
        public GameObjects.TroopDetail.EventEffect.EventEffect Effect;
        public EffectAreaKind Kind;

        public override string ToString()
        {
            return (this.Kind + " " + this.Effect.Name);
        }
    }
}

