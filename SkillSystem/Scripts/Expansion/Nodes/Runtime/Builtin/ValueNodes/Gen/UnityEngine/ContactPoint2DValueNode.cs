using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/ContactPoint2D Value")]
    public partial class ContactPoint2DValueNode:ValueNode<IcVariableContactPoint2D>
    {
        [SerializeField]
        private UnityEngine.ContactPoint2D _value;
   
        private IcVariableContactPoint2D _variableValue = new IcVariableContactPoint2D();
   
        protected override IcVariableContactPoint2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}