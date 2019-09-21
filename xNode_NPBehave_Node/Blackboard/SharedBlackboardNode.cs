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

        protected override void CreateNode()
        {
            var key = GetInputValue(nameof(_key), _key);

#if UNITY_EDITOR
            //没有播放,不执行
            if (!Application.isPlaying)
            {
                return;
            }
#endif
            
            Blackboard = UnityContext.GetSharedBlackboard(key);
        }
    }
}