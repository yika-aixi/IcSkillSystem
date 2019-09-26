using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/IMGUIModule/GUIContent Value")]
    public partial class GUIContentValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.GUIContent _value;

        public override Type ValueType { get; } = typeof(UnityEngine.GUIContent);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}