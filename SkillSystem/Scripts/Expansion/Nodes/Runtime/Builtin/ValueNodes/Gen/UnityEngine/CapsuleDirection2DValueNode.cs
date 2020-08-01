using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/CapsuleDirection2D Value")]
    public partial class CapsuleDirection2DValueNode:ValueNode<IcVariableCapsuleDirection2D>
    {
        [SerializeField]
        private UnityEngine.CapsuleDirection2D _value;
   
        private IcVariableCapsuleDirection2D _variableValue = new IcVariableCapsuleDirection2D();
   
        protected override IcVariableCapsuleDirection2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}