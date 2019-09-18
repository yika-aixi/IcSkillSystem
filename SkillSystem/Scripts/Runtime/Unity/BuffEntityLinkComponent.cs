using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Unity
{
    public class BuffEntityLinkComponent : MonoBehaviour
    {
        [NonSerialized] 
        public IBuffManager BuffManager;
        [NonSerialized] 
        public IEntity Entity;

        public void Init(IBuffManager buffManager,IEntity entity)
        {
            BuffManager = buffManager;
            Link(entity);
        }

        public void Link(IEntity entity)
        {
            this.Entity = entity;
        }
    }
}