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

        public static bool HasBuff(IIcSkSEntityManager<IIcSkSEntity> entityManager, IIcSkSEntity entity,IBuffDataComponent buff)
        {
            return HasBuff<IIcSkSEntity>(entityManager,entity, buff);
        }
        
        public static bool HasBuff<TE>(IIcSkSEntityManager<TE> entityManager, TE entity,
            IBuffDataComponent buff) where TE : IIcSkSEntity
        {
            bool result = false;
            if (entityManager is IStructIcSkSEntityManager<TE> structIcSkSEntityManager)
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
            IBuffDataComponent buff)
        {
            return RemoveBuff<IIcSkSEntity>(entityManager, entity, buff);
        }
        
        public static bool RemoveBuff<TE>(IIcSkSEntityManager<TE> entityManager, TE entity,
            IBuffDataComponent buff) where TE : IIcSkSEntity
        {
            bool result = false;
            
            if (entityManager is IStructIcSkSEntityManager<TE> structIcSkSEntityManager)
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
            IBuffDataComponent buff)
        {
            AddBuff<IIcSkSEntity>(entityManager, entity, buff);
        }
        
        public static void AddBuff<Te>(IIcSkSEntityManager<Te> entityManager, Te entity,
            IBuffDataComponent buff) where Te : IIcSkSEntity
        {
            if (entityManager is IStructIcSkSEntityManager<Te> skSEntityManager)
            {
                _buffAddOrRemove<Te>(ActionType.Add, out _,entity, buff, skSEntityManager);
            }
        }

        #endregion

        enum ActionType
        {
            Add,
            Remove,
            Has
        }
        
        private static void _buffAddOrRemove<Te>(ActionType actionType,out bool result,Te entity, IBuffDataComponent buff,
            IStructIcSkSEntityManager<Te> structIcSkSEntityManager) where Te : IIcSkSEntity
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