using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightmapSettings Value")]
    public partial class LightmapSettingsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LightmapSettings _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LightmapSettings);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}