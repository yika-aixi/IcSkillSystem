using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ForceMode Value")]
    public partial class ForceModeValueNode:ValueNode<IcVariableForceMode>
    {
        [SerializeField]
        private UnityEngine.ForceMode _value;
   
        private IcVariableForceMode _variableValue = new IcVariableForceMode();
   
        protected override IcVariableForceMode GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}