using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RectInt Value")]
    public partial class RectIntValueNode:ValueNode<IcVariableRectInt>
    {
        [SerializeField]
        private UnityEngine.RectInt _value;
   
        private IcVariableRectInt _variableValue = new IcVariableRectInt();
   
        protected override IcVariableRectInt GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}