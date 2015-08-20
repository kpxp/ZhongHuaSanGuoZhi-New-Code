namespace GameObjects.TroopDetail
{
    using GameObjects;

    public class AttackDefaultKindList : GameObjectList
    {
        public AttackDefaultKindList GetSelectedList(TroopAttackDefaultKind kind)
        {
            AttackDefaultKindList list = new AttackDefaultKindList();
            foreach (AttackDefaultKind kind2 in base.GameObjects)
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

