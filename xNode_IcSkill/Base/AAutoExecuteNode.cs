//Create: Icarus
//ヾ(•ω•`)o
//2020-07-30 06:57
//CabinIcarus.IcSkillSystem.xNodeIc.Base

using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcFrameWork.IcSkillSystem.xNode_IcSkill.Base
{
    public abstract class AAutoExecuteNode:ABaseNode
    {
        [SerializeField,Input(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Inherited)]
        [PortTooltip("执行节点")]
        private Root _node;

        protected Root Node;

        public override void OnInit()
        {
            if (Node == null)
            {
                Node = GetInputValue<Root>(nameof(_node), null);
            }

            On_Init();
        }

        protected virtual void On_Init()
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