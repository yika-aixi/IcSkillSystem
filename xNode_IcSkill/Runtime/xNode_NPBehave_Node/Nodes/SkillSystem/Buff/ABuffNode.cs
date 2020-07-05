using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Utils;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.SkillSystems.Buff
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

        protected sealed override Node CreateOutValue()
        {
            BuffType = Type.GetType(_buffAQName);

            return Execute();
        }

        protected abstract Node Execute();
    }
}