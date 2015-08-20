namespace GameObjects.Conditions
{
    using System;

    internal static class ConditionKindFactory
    {
        internal static ConditionKind CreateConditionKindByID(int id)
        {
            try
            {
                return (Activator.CreateInstance(Type.GetType("GameObjects.Conditions.ConditionKindPack.ConditionKind" + id.ToString())) as ConditionKind);
            }
            catch
            {
                return null;
            }
        }
    }
}

