//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月23日-23:25
//Assembly-CSharp

using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansions
{
    //对目标造成1类型伤害
    public class Skill1:ISkillDataComponent,IBuffValueDataComponent,IBuffType,IBuffMakerEntityComponent
    {
        public float Value { get; set; }
        public int Type { get; set; } = 1;
        public IEntity Maker { get; set; }
    }
    
    //对目标造成2类型伤害
    public class Skill2:ISkillDataComponent,IBuffValueDataComponent,IBuffType,IBuffMakerEntityComponent
    {
        public float Value { get; set; }
        public int Type { get; set; } = 2;
        public IEntity Maker { get; set; }
    }
    
    //对目标造成3类型伤害,有概率变为持续伤害
    public class Skill3:ISkillDataComponent,IBuffValueDataComponent,IBuffType,IBuffMakerEntityComponent,IBuffTimeDataComponent,IBuffTriggerTime
    {
        public float Value { get; set; }
        public int Type { get; set; } = 3;

        public float Probability;
        public IEntity Maker { get; set; }
        public float Duration { get; set; }
        public float LastTriggerTime { get; set; }
        public float TriggerInterval { get; set; }
    }

    /// <summary>
    /// 对目标造成无类型伤害
    /// </summary>
    public class Skill4:ISkillDataComponent,IBuffValueDataComponent,IBuffMakerEntityComponent
    {
        public float Value { get; set; }
        public IEntity Maker { get; set; }
    }

    public class PlayAudioClip:ISkillDataComponent
    {
        public AudioClip Clip;
        public float Volume = 1;
    }
}