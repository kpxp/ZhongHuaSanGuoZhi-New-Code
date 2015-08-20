namespace GameObjects.TroopDetail.EventEffect
{
    using System;

    internal class EventEffectKindFactory
    {
        internal static EventEffectKind CreateEventEffectKindByID(int id)
        {
            try
            {
                return (Activator.CreateInstance(Type.GetType("GameObjects.TroopDetail.EventEffect.EventEffectKindPack.EventEffectKind" + id.ToString())) as EventEffectKind);
            }
            catch
            {
                return null;
            }
        }
    }
}

