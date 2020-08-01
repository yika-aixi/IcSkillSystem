using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/SpherecastCommand Value")]
    public partial class SpherecastCommandValueNode:ValueNode<IcVariableSpherecastCommand>
    {
        [SerializeField]
        private UnityEngine.SpherecastCommand _value;
   
        private IcVariableSpherecastCommand _variableValue = new IcVariableSpherecastCommand();
   
        protected override IcVariableSpherecastCommand GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}