using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LOD Value")]
    public partial class LODValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LOD _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LOD);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}