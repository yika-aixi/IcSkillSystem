using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/IMGUIModule/GUIStyle Value")]
    public partial class GUIStyleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.GUIStyle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.GUIStyle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}