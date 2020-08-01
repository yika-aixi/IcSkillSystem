using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/PhysicsScene2D Value")]
    public partial class PhysicsScene2DValueNode:ValueNode<IcVariablePhysicsScene2D>
    {
        [SerializeField]
        private UnityEngine.PhysicsScene2D _value;
   
        private IcVariablePhysicsScene2D _variableValue = new IcVariablePhysicsScene2D();
   
        protected override IcVariablePhysicsScene2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}