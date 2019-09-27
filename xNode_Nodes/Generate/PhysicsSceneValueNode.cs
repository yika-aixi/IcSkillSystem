using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/PhysicsScene Value")]
    public partial class PhysicsSceneValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.PhysicsScene _value;

        public override Type ValueType { get; } = typeof(UnityEngine.PhysicsScene);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}