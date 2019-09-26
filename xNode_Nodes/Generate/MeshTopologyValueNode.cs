using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/MeshTopology Value")]
    public partial class MeshTopologyValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.MeshTopology _value;

        public override Type ValueType { get; } = typeof(UnityEngine.MeshTopology);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}