using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/IMGUIModule/GUISettings Value")]
    public partial class GUISettingsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.GUISettings _value;

        public override Type ValueType { get; } = typeof(UnityEngine.GUISettings);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}