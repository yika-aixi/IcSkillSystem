using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/HumanBodyBones Value")]
    public partial class HumanBodyBonesValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.HumanBodyBones _value;

        public override Type ValueType { get; } = typeof(UnityEngine.HumanBodyBones);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}