//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月17日-23:13
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Play Audio/Self")]
    public class SelfPlayAudioNode:APlayAudioNode
    {
        protected override Action CreateAction()
        {
            return new Action(_play);
        }

        private void _play()
        {
            var source = SkillGroup.Owner.GetComponent<AudioSource>();

            if (!source)
            {
                source = SkillGroup.Owner.AddComponent<AudioSource>();
            }

            source.clip = Clip;
            
            source.Play();
        }
    }
}