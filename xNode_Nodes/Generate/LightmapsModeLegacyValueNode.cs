using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightmapsModeLegacy Value")]
    public partial class LightmapsModeLegacyValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LightmapsModeLegacy _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LightmapsModeLegacy);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}