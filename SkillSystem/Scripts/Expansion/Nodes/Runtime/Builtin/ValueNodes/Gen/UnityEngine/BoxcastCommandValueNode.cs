using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/BoxcastCommand Value")]
    public partial class BoxcastCommandValueNode:ValueNode<IcVariableBoxcastCommand>
    {
        [SerializeField]
        private UnityEngine.BoxcastCommand _value;
   
        private IcVariableBoxcastCommand _variableValue = new IcVariableBoxcastCommand();
   
        protected override IcVariableBoxcastCommand GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}