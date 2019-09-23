//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月23日-23:08
//Assembly-CSharp

using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Systems;
using CabinIcarus.IcSkillSystem.Expansions.Skills;
using NPBehave;
using SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Skills.Manager;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansions
{
    public class GameRoot : MonoBehaviour
    {
        public BuffManager BuffManager;
        public SkillManager SkillManager;

        public StateManager StateManager;
        
        public const string SharedBlackboardKey = "Test";

        public string SkillManagerKey = "SkillManager";

        public AudioClip Clip;
        private AudioSource _source;

        private void Awake()
        {
            var bb = UnityContext.GetSharedBlackboard(SharedBlackboardKey);
            
            BuffManager = new BuffManager();
            SkillManager = new SkillManager();

            bb.Set(SkillManagerKey,SkillManager);
            
            BuffManager
                //固定减伤buff
                .AddBuffSystem(new DamageReduceFixedSystem(BuffManager))
                //百分比减伤buff
                .AddBuffSystem(new DamageReducePercentageSystem(BuffManager))
                //带有持续时间buff的时间处理,一定在所有持续类buff之前,因为时间的减少发生在buff产生效果之前
                .AddBuffSystem(new BuffTimeSystem(BuffManager))
                //持续伤害buff
                .AddBuffSystem(new ContinuousDamageSystem<DamageBuff>(BuffManager))
                //伤害buff
                .AddBuffSystem(new DamageSystem(BuffManager))
                .AddBuffSystem(new HPBarChanageSystem(BuffManager,StateManager))
                .AddBuffSystem(new ContinuousDamageBuffShowSystem(StateManager))
                .AddBuffSystem(new DamageReducePercentageShowSystem(StateManager))
                .AddBuffSystem(new DamageReduceFixedBuffIconShowSystem(StateManager));
            
            
            SkillManager
                // Hello World Skill 同时随机一个buff
                .AddSkillSystem(new Skill1System(BuffManager))
                .AddSkillSystem(new Skill2System(BuffManager))
                .AddSkillSystem(new Skill3System(BuffManager))
                .AddSkillSystem(new Skill4System(BuffManager))
                .AddSkillSystem(new Skill4AudioSystem(_playClip));

            _source = gameObject.AddComponent<AudioSource>();
            _source.playOnAwake = false;
            _source.clip = Clip;
        }

        private void _playClip()
        {
            _source.Play();
        }

        private void Update()
        {
            //buff系统更新
            BuffManager.Update();
        }
    }
}