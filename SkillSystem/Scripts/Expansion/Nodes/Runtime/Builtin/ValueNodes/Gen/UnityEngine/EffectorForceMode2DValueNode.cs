using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/EffectorForceMode2D Value")]
    public partial class EffectorForceMode2DValueNode:ValueNode<IcVariableEffectorForceMode2D>
    {
        [SerializeField]
        private UnityEngine.EffectorForceMode2D _value;
   
        private IcVariableEffectorForceMode2D _variableValue = new IcVariableEffectorForceMode2D();
   
        protected override IcVariableEffectorForceMode2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}