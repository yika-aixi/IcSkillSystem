using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/EffectorSelection2D Value")]
    public partial class EffectorSelection2DValueNode:ValueNode<IcVariableEffectorSelection2D>
    {
        [SerializeField]
        private UnityEngine.EffectorSelection2D _value;
   
        private IcVariableEffectorSelection2D _variableValue = new IcVariableEffectorSelection2D();
   
        protected override IcVariableEffectorSelection2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}