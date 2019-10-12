using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
using SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Entitys;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Unity
{
    public class BuffEntityLinkComponent : MonoBehaviour
    {
        [NonSerialized] 
        public IIcSkSEntityManager<IBuffManager<IIcSkSEntity>, IIcSkSEntity> EntityManager;
        public IBuffManager<AIcStructBuffSystem<IIcSkSEntity>,IIcSkSEntity> BuffManager;
        [NonSerialized] 
        public IcSkSEntity IcSkSEntity;

        public void Init(IIcSkSEntityManager<IBuffManager<IIcSkSEntity>,IIcSkSEntity> entityManager, IBuffManager<AIcStructBuffSystem<IIcSkSEntity>,IIcSkSEntity> buffManager, IcSkSEntity icSkSEntity)
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