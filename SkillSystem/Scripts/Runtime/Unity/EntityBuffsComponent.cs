using System;
using Cabin_Icarus.SkillSystem.Scripts.Runtime.Buffs.Entitys;
using CabinIcarus.SkillSystem.Scripts.Runtime.Buffs;
using UnityEngine;

namespace SkillSystem.SkillSystem.Scripts.Runtime.Unity
{
    public class EntityBuffsComponent : MonoBehaviour
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