using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/PhysicsScene Value")]
    public partial class PhysicsSceneValueNode:ValueNode<IcVariablePhysicsScene>
    {
        [SerializeField]
        private UnityEngine.PhysicsScene _value;
   
        private IcVariablePhysicsScene _variableValue = new IcVariablePhysicsScene();
   
        protected override IcVariablePhysicsScene GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}