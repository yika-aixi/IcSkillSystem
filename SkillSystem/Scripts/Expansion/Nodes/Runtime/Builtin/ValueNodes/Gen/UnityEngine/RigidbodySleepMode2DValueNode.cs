using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/RigidbodySleepMode2D Value")]
    public partial class RigidbodySleepMode2DValueNode:ValueNode<IcVariableRigidbodySleepMode2D>
    {
        [SerializeField]
        private UnityEngine.RigidbodySleepMode2D _value;
   
        private IcVariableRigidbodySleepMode2D _variableValue = new IcVariableRigidbodySleepMode2D();
   
        protected override IcVariableRigidbodySleepMode2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}