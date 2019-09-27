using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/TransformAccessArray Value")]
    public partial class TransformAccessArrayValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Jobs.TransformAccessArray _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Jobs.TransformAccessArray);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}