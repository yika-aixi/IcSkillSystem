using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LODFadeMode Value")]
    public partial class LODFadeModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LODFadeMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LODFadeMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}