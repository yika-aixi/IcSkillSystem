using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/RaycastCommand Value")]
    public partial class RaycastCommandValueNode:ValueNode<IcVariableRaycastCommand>
    {
        [SerializeField]
        private UnityEngine.RaycastCommand _value;
   
        private IcVariableRaycastCommand _variableValue = new IcVariableRaycastCommand();
   
        protected override IcVariableRaycastCommand GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}