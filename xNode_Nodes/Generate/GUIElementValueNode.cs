using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/GUIElement Value")]
    public partial class GUIElementValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.GUIElement _value;

        public override Type ValueType { get; } = typeof(UnityEngine.GUIElement);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}