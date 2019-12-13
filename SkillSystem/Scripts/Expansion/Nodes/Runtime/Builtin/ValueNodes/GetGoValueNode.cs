using System;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Component To GameObject")]
    public class GetGoValueNode:ValueNode<GameObject>
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private Component _component;

        protected override GameObject GetTValue()
        {
            var com = GetInputValue(nameof(_component), _component);

            if (!com)
            {
                return null;
            }
            
            return com.gameObject;
        }
    }
}