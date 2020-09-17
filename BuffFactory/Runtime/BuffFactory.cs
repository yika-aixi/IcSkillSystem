using System;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;

//### Using
                
//###

namespace  CabinIcarus.IcSkillSystem
{
    public static class BuffFactory
    {
        #region Has Buff
        public static bool HasBuff(IIcSkSEntityManager<IIcSkSEntity> entityManager, IIcSkSEntity entity,
            IBuffData buff)
        {
            bool result = false;
            if (entityManager is IStructIcSkSEntityManager<IIcSkSEntity> structIcSkSEntityManager)
            {
                //### Code
                _buffAddOrRemove(ActionType.Has,out result ,entity, buff, structIcSkSEntityManager);
                //###
            }
            return result;
        }

        #endregion

        #region Remove Buff

        public static bool RemoveBuff(IIcSkSEntityManager<IIcSkSEntity> entityManager, IIcSkSEntity entity,
            IBuffData buff)
        {
            bool result = false;
            
            if (entityManager is IStructIcSkSEntityManager<IIcSkSEntity> structIcSkSEntityManager)
            {
                //### Code
                _buffAddOrRemove(ActionType.Remove, out result,entity, buff, structIcSkSEntityManager);
                //###
            }

            return result;
        }

        #endregion

        #region Add Buff

        public static void AddBuff(IIcSkSEntityManager<IIcSkSEntity> entityManager, IIcSkSEntity entity,
            IBuffData buff)
        {
            if (entityManager is IStructIcSkSEntityManager<IIcSkSEntity> skSEntityManager)
            {
                _buffAddOrRemove(ActionType.Add, out _,entity, buff, skSEntityManager);
            }
        }

        #endregion

        enum ActionType
        {
            Add,
            Remove,
            Has
        }
        
        private static void _buffAddOrRemove(ActionType actionType,out bool result,IIcSkSEntity entity, IBuffData buff,
            IStructIcSkSEntityManager<IIcSkSEntity> structIcSkSEntityManager)
        {
            result = false;
            switch (buff)
            {
                case Damage damage:
                    switch (actionType)
                    {
                        case ActionType.Add:
                            structIcSkSEntityManager.AddBuff(entity, damage);
                            break;
                        case ActionType.Remove:
                            result = structIcSkSEntityManager.RemoveBuff(entity, (Damage) buff);
                            break;
                        case ActionType.Has:
                            result = structIcSkSEntityManager.HasBuff(entity, (Damage) buff);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(actionType), actionType, null);
                    }
                    break;
            }
        }
    }
}