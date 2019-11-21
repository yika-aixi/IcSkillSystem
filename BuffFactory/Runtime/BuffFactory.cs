using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;

//### Using
                
//###

namespace  CabinIcarus.IcSkillSystem.BuffFactory
{
    public static class BuffFactory
    {
        public static void AddBuff(IIcSkSEntityManager<IIcSkSEntity> entityManager, IIcSkSEntity entity,string buffType,
            IBuffDataComponent buff)
        {
            AddBuff<IIcSkSEntity>(entityManager, entity,buffType, buff);
        }
        
        public static void AddBuff<TE>(IIcSkSEntityManager<TE> entityManager, TE entity,string buffType,
            IBuffDataComponent buff) where TE : IIcSkSEntity
        {
            if (entityManager is IStructIcSkSEntityManager<TE> structIcSkSEntityManager)
            {
                //### Code
                if (buffType == typeof(Damage).FullName)
                {
                    structIcSkSEntityManager.AddBuff(entity,(Damage) buff);   
                }
                else if (buffType == typeof(DeathStruct).FullName)
                {
                    structIcSkSEntityManager.AddBuff(entity,(DeathStruct) buff);
                }
                else if (buffType == typeof(Mechanics).FullName)
                {
                    structIcSkSEntityManager.AddBuff(entity,(Mechanics) buff);
                }
                //###
            }
        }
    }
}