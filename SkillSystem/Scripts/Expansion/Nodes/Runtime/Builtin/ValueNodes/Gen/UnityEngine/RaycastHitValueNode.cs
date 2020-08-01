using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/RaycastHit Value")]
    public partial class RaycastHitValueNode:ValueNode<IcVariableRaycastHit>
    {
        [SerializeField]
        private UnityEngine.RaycastHit _value;
   
        private IcVariableRaycastHit _variableValue = new IcVariableRaycastHit();
   
        protected override IcVariableRaycastHit GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}