using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/GenerationType Value")]
    public partial class GenerationTypeValueNode:ValueNode<IcVariableGenerationType>
    {
        [SerializeField]
        private UnityEngine.CompositeCollider2D.GenerationType _value;
   
        private IcVariableGenerationType _variableValue = new IcVariableGenerationType();
   
        protected override IcVariableGenerationType GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}