using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/QualitySettings Value")]
    public partial class QualitySettingsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.QualitySettings _value;

        public override Type ValueType { get; } = typeof(UnityEngine.QualitySettings);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}