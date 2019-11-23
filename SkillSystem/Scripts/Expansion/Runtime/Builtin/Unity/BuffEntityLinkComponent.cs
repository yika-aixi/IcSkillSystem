using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Entitys;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Builtin.Component
{
    public class BuffEntityLinkComponent : MonoBehaviour
    {
        [NonSerialized] 
        public IIcSkSEntityManager<IcSkSEntity> EntityManager;
        [NonSerialized] 
        public IcSkSEntity IcSkSEntity;

        public void Init(IIcSkSEntityManager<IcSkSEntity> entityManager, IcSkSEntity icSkSEntity)
        {
            EntityManager = entityManager;
            Link(icSkSEntity);
        }

        public void Link(IcSkSEntity icSkSEntity)
        {
            this.IcSkSEntity = icSkSEntity;
        }
    }
}