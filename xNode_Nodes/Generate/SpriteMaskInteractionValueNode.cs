using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SpriteMaskInteraction Value")]
    public partial class SpriteMaskInteractionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SpriteMaskInteraction _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SpriteMaskInteraction);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}