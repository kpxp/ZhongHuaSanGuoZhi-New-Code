namespace GameObjects.Influences
{
    using System;

    internal static class InfluenceKindFactory
    {
        internal static InfluenceKind CreateInfluenceKindByID(int id)
        {
            try
            {
                return (Activator.CreateInstance(Type.GetType("GameObjects.Influences.InfluenceKindPack.InfluenceKind" + id.ToString())) as InfluenceKind);
            }
            catch
            {
                return null;
            }
        }
    }
}

