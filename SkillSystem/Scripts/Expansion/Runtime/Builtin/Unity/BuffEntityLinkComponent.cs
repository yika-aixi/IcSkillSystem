using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Entitys;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Unity
{
    public class BuffEntityLinkComponent : MonoBehaviour
    {
        [NonSerialized] 
        public IIcSkSEntityManager<IBuffSystem,IcSkSEntity> EntityManager;
        public IBuffManager<AIcStructBuffSystem<IIcSkSEntity>,IcSkSEntity> BuffManager;
        [NonSerialized] 
        public IcSkSEntity IcSkSEntity;

        public void Init(IIcSkSEntityManager<IBuffSystem,IcSkSEntity> entityManager, IBuffManager<AIcStructBuffSystem<IIcSkSEntity>,IcSkSEntity> buffManager, IcSkSEntity icSkSEntity)
        {
            EntityManager = entityManager;
            BuffManager = buffManager;
            Link(icSkSEntity);
        }

        public void Link(IcSkSEntity icSkSEntity)
        {
            this.IcSkSEntity = icSkSEntity;
        }
    }
}