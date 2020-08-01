using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/ForceMode2D Value")]
    public partial class ForceMode2DValueNode:ValueNode<IcVariableForceMode2D>
    {
        [SerializeField]
        private UnityEngine.ForceMode2D _value;
   
        private IcVariableForceMode2D _variableValue = new IcVariableForceMode2D();
   
        protected override IcVariableForceMode2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}