using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/PhysicMaterialCombine Value")]
    public partial class PhysicMaterialCombineValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.PhysicMaterialCombine _value;

        public override Type ValueType { get; } = typeof(UnityEngine.PhysicMaterialCombine);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}