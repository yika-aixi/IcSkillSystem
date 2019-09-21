//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-23:55
//Assembly-CSharp

using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    public abstract class NeedBlackboardNPBehaveNode:NPBehaveNode
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private BlackboardNode _blackboardNode;

        protected Blackboard Blackboard { get; private set; }

        public override object GetValue(NodePort port)
        {
            Blackboard = GetInputValue(nameof(_blackboardNode), _blackboardNode)?.Blackboard;
           
            return base.GetValue(port);
        }
    }
}