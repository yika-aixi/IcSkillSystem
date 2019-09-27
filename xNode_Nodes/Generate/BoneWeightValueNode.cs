using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/BoneWeight Value")]
    public partial class BoneWeightValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.BoneWeight _value;

        public override Type ValueType { get; } = typeof(UnityEngine.BoneWeight);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}