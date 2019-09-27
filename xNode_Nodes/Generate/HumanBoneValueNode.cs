using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/HumanBone Value")]
    public partial class HumanBoneValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.HumanBone _value;

        public override Type ValueType { get; } = typeof(UnityEngine.HumanBone);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}