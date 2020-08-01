using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/ContactFilter2D Value")]
    public partial class ContactFilter2DValueNode:ValueNode<IcVariableContactFilter2D>
    {
        [SerializeField]
        private UnityEngine.ContactFilter2D _value;
   
        private IcVariableContactFilter2D _variableValue = new IcVariableContactFilter2D();
   
        protected override IcVariableContactFilter2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}