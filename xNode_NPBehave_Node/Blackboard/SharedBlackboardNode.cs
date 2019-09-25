using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Blackboard/Get Shared")]
    public class SharedBlackboardNode:BlackboardNode
    {
        [SerializeField,Input(ShowBackingValue.Unconnected,ConnectionType.Override,TypeConstraint.Strict)]
        private string _key;

        protected override Blackboard GetOutValue()
        {
            var key = GetInputValue(nameof(_key), _key);

            return UnityContext.GetSharedBlackboard(key);
        }
    }
}