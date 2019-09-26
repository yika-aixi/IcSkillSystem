using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/DrivenTransformProperties Value")]
    public partial class DrivenTransformPropertiesValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.DrivenTransformProperties _value;

        public override Type ValueType { get; } = typeof(UnityEngine.DrivenTransformProperties);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}