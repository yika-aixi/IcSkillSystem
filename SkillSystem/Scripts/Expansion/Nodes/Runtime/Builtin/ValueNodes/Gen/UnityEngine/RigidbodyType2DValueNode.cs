using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/RigidbodyType2D Value")]
    public partial class RigidbodyType2DValueNode:ValueNode<IcVariableRigidbodyType2D>
    {
        [SerializeField]
        private UnityEngine.RigidbodyType2D _value;
   
        private IcVariableRigidbodyType2D _variableValue = new IcVariableRigidbodyType2D();
   
        protected override IcVariableRigidbodyType2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}