namespace GameObjects.TroopDetail
{
    using GameObjects;

    public class CastDefaultKindList : GameObjectList
    {
        public CastDefaultKindList GetSelectedList(TroopCastDefaultKind kind)
        {
            CastDefaultKindList list = new CastDefaultKindList();
            foreach (CastDefaultKind kind2 in base.GameObjects)
            {
                if (kind2.ID ==(int) kind)
                {
                    list.Add(kind2);
                }
            }
            return list;
        }
    }
}

