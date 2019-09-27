using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/MaterialEffectPlayable Value")]
    public partial class MaterialEffectPlayableValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Playables.MaterialEffectPlayable _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Playables.MaterialEffectPlayable);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}