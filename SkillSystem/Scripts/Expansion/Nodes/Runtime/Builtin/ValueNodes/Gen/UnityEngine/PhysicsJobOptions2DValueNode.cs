using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/PhysicsJobOptions2D Value")]
    public partial class PhysicsJobOptions2DValueNode:ValueNode<IcVariablePhysicsJobOptions2D>
    {
        [SerializeField]
        private UnityEngine.PhysicsJobOptions2D _value;
   
        private IcVariablePhysicsJobOptions2D _variableValue = new IcVariablePhysicsJobOptions2D();
   
        protected override IcVariablePhysicsJobOptions2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}