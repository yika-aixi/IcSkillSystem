using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Vector3 Value")]
    public partial class Vector3ValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Vector3 _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Vector3);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}