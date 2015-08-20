namespace GameObjects.ArchitectureDetail.EventEffect
{
    using System;

    internal class EventEffectKindFactory
    {
        internal static EventEffectKind CreateEventEffectKindByID(int id)
        {
            try
            {
                return (Activator.CreateInstance(Type.GetType("GameObjects.ArchitectureDetail.EventEffect.EventEffect" + id.ToString())) as EventEffectKind);
            }
            catch
            {
                return null;
            }
        }
    }
}

