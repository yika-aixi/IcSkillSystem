using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Blackboard/Get Shared")]
    public class SharedBlackboardNode:BlackboardNode
    {
        [SerializeField,Input(ShowBackingValue.Unconnected,ConnectionType.Override)]
        private string _key;

        public override object GetValue(NodePort port)
        {
            var key = GetInputValue(nameof(_key), string.Empty);
            
            Blackboard = UnityContext.GetSharedBlackboard(key);
            
            return base.GetValue(port);
        }
    }
}