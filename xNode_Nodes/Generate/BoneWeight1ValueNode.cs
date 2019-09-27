using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/BoneWeight1 Value")]
    public partial class BoneWeight1ValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.BoneWeight1 _value;

        public override Type ValueType { get; } = typeof(UnityEngine.BoneWeight1);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}