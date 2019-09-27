using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SortingSettings Value")]
    public partial class SortingSettingsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.SortingSettings _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.SortingSettings);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}