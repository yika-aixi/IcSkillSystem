using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/TransformAccess Value")]
    public partial class TransformAccessValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Jobs.TransformAccess _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Jobs.TransformAccess);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}