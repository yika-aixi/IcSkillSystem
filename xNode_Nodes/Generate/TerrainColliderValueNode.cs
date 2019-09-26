using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TerrainPhysicsModule/TerrainCollider Value")]
    public partial class TerrainColliderValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TerrainCollider _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TerrainCollider);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}