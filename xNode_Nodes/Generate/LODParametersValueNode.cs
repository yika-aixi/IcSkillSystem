using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LODParameters Value")]
    public partial class LODParametersValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.LODParameters _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.LODParameters);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}