using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/RigidbodyConstraints2D Value")]
    public partial class RigidbodyConstraints2DValueNode:ValueNode<IcVariableRigidbodyConstraints2D>
    {
        [SerializeField]
        private UnityEngine.RigidbodyConstraints2D _value;
   
        private IcVariableRigidbodyConstraints2D _variableValue = new IcVariableRigidbodyConstraints2D();
   
        protected override IcVariableRigidbodyConstraints2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}