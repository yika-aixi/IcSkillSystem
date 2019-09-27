using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CombineInstance Value")]
    public partial class CombineInstanceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CombineInstance _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CombineInstance);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}