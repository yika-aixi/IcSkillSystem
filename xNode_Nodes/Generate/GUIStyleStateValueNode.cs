using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/IMGUIModule/GUIStyleState Value")]
    public partial class GUIStyleStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.GUIStyleState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.GUIStyleState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}