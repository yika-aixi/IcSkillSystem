using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VFXModule/VisualEffect Value")]
    public partial class VisualEffectValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.VFX.VisualEffect _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.VFX.VisualEffect);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}