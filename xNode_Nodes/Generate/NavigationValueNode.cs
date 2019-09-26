using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/Navigation Value")]
    public partial class NavigationValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.Navigation _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.Navigation);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}