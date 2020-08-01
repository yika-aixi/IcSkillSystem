using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/CollisionDetectionMode Value")]
    public partial class CollisionDetectionModeValueNode:ValueNode<IcVariableCollisionDetectionMode>
    {
        [SerializeField]
        private UnityEngine.CollisionDetectionMode _value;
   
        private IcVariableCollisionDetectionMode _variableValue = new IcVariableCollisionDetectionMode();
   
        protected override IcVariableCollisionDetectionMode GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}