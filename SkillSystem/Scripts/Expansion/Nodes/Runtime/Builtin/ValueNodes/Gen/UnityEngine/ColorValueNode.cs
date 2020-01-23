using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Color Value")]
    public partial class ColorValueNode:ValueNode<IcVariableColor>
    {
        [SerializeField]
        private UnityEngine.Color _value;
   
        private IcVariableColor _variableValue = new IcVariableColor();
   
        protected override IcVariableColor GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}