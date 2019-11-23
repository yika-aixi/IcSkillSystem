using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using CabinIcarus.IcSkillSystem.Runtime.Nodes.Attributes;
using NPBehave;
using SkillSystem.xNode_NPBehave_Node.Utils;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes.SkillSystems.Buff
{
    public abstract class ABuffNode:ASkillSNode
    {
        [SerializeField]
        private string _buffAQName;
        
        protected Type BuffType;

        protected IBuffDataComponent Buff
        {
            get
            {
                if (BuffType == null)
                {
                    return null;
                }
            
                return (IBuffDataComponent) this.DynamicInputCreateInstance(BuffType);
            }
        }

        protected sealed override Node GetOutValue()
        {
            BuffType = Type.GetType(_buffAQName);

            return Execute();
        }

        protected abstract Node Execute();
    }
}