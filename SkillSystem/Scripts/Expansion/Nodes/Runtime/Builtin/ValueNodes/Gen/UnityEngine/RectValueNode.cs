using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Rect Value")]
    public partial class RectValueNode:ValueNode<IcVariableRect>
    {
        [SerializeField]
        private UnityEngine.Rect _value;
   
        private IcVariableRect _variableValue = new IcVariableRect();
   
        protected override IcVariableRect GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}