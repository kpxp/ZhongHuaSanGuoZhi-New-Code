namespace GameObjects.TroopDetail
{
    using GameObjects;

    public class AttackTargetKindList : GameObjectList
    {
        public AttackTargetKindList GetSelectedList(TroopAttackTargetKind kind)
        {
            AttackTargetKindList list = new AttackTargetKindList();
            foreach (AttackTargetKind kind2 in base.GameObjects)
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

