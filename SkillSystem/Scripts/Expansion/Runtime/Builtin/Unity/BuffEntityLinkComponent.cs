using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Unity
{
    public class BuffEntityLinkComponent : MonoBehaviour
    {
        [NonSerialized] 
        public INewBuffManager<AIcStructBuffSystem<IcSkSEntity>,IcSkSEntity> BuffManager;
        [NonSerialized] 
        public IcSkSEntity IcSkSEntity;

        public void Init(INewBuffManager<AIcStructBuffSystem<IcSkSEntity>,IcSkSEntity> buffManager,IcSkSEntity icSkSEntity)
        {
            BuffManager = buffManager;
            Link(icSkSEntity);
        }

        public void Link(IcSkSEntity icSkSEntity)
        {
            this.IcSkSEntity = icSkSEntity;
        }
    }
}