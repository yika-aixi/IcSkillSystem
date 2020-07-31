//Create: Icarus
//ヾ(•ω•`)o
//2020-07-30 06:57
//CabinIcarus.IcSkillSystem.xNodeIc.Base

using CabinIcarus.IcSkillSystem;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.xNode_Group;
using NPBehave;
using UnityEngine;
using Node = XNode.Node;

namespace CabinIcarus.IcFrameWork.IcSkillSystem.xNode_IcSkill.Base
{
    public abstract class AAutoExecuteNode:Node,IIcSkillSystemNode
    {
        public IcSkillGraph SkillGraph { get; set; }
        
        [SerializeField,Input(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Inherited)]
        [PortTooltip("执行节点")]
        private Root _node;

        protected Root Node;

        protected sealed override void Init()
        {
            if (Node == null)
            {
                Node = GetInputValue<Root>(nameof(_node), null);
            }

            OnInit();
        }

        protected virtual void OnInit()
        {
        }

        protected void Execute()
        {
            if (Node == null)
            {
                Debug.LogWarning("no node input");
                return;
            }

            if (Node.IsActive)
            {
                Debug.LogWarning("node action ing");
                return;
            }
            
            Node.Start();
        }
    }
}