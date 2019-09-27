using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/MathfInternal Value")]
    public partial class MathfInternalValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngineInternal.MathfInternal _value;

        public override Type ValueType { get; } = typeof(UnityEngineInternal.MathfInternal);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}