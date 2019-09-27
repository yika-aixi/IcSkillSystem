using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Ray Value")]
    public partial class RayValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Ray _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Ray);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}