//Create: Icarus
//ヾ(•ω•`)o
//2020-08-01 04:46
//CabinIcarus.IcSkillSystem.xNodeIc.Base

using System;
using CabinIcarus.IcSkillSystem;
using CabinIcarus.IcSkillSystem.xNode_Group;
using XNode;

namespace CabinIcarus.IcFrameWork.IcSkillSystem.xNode_IcSkill.Base
{
    public abstract class ABaseNode : Node,IIcSkillSystemNode
    {
        public IcSkillGraph SkillGraph { get; set; }

        public virtual void OnInit()
        {
        }

        public virtual void OnStop()
        {
        }

        protected sealed override void Init()
        {
        }
    }
}