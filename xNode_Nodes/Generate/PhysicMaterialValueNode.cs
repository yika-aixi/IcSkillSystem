using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/PhysicMaterial Value")]
    public partial class PhysicMaterialValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.PhysicMaterial _value;

        public override Type ValueType { get; } = typeof(UnityEngine.PhysicMaterial);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}