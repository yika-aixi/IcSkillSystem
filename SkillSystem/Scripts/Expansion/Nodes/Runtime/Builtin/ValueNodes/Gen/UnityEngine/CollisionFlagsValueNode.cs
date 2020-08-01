using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/CollisionFlags Value")]
    public partial class CollisionFlagsValueNode:ValueNode<IcVariableCollisionFlags>
    {
        [SerializeField]
        private UnityEngine.CollisionFlags _value;
   
        private IcVariableCollisionFlags _variableValue = new IcVariableCollisionFlags();
   
        protected override IcVariableCollisionFlags GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}