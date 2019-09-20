using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Systems;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansions.Skills
{
    public class HelloWorldSkillSystem:ISkillExecuteSystem
    {
        private readonly IBuffManager _buffManager;

        public HelloWorldSkillSystem(IBuffManager buffManager)
        {
            this._buffManager = buffManager;
        }

        public void Execute(IEntity entity, ISkillDataComponent skill)
        {
            Debug.LogError($"使用技能HelloWorld! `Hello World IcSkillSystem!`,随机获得了一个buff");

            var value = Random.Range(1, 5);
            
            switch (value)
            {
                case 1:
                    _buffManager.AddBuff(entity,new DamageBuff()
                    {
                        Type = Random.Range(1,4),
                        Value = Random.Range(10,40f)
                    });
                    break;
                case 2:
                    var intr = Random.Range(0.2f, 1.5f);
                    var damage = Random.Range(10, 50f);
                    var duration = Random.Range(2, 4.5f);
                    _buffManager.AddBuff(entity,new ContinuousDamageBuff()
                    {
                        Name = "来自上天的奖励",
                        Description = $"你将每隔{intr}秒受到{damage}伤害,持续{duration}秒",
                        TriggerInterval = intr,
                        Duration = duration,
                        Type = Random.Range(1,4),
                    });
                    break;
                case 3:
                    var reduceValue = Random.Range(5, 20);
                    var type = Random.Range(1, 4);
                    _buffManager.AddBuff(entity,new DamageReduceFixedBuff()
                    {
                        Name = "来自上天的奖励",
                        Description = $"伤害固定减少,减少{type}类型伤害{reduceValue}点",
                        Type = type,
                        Value = reduceValue
                    });
                    break;
                case 4:
                    reduceValue = Random.Range(10, 85);
                    type = Random.Range(1, 4);
                    _buffManager.AddBuff(entity,new DamageReducePercentageBuff()
                    {
                        Name = "来自上天的奖励",
                        Description = $"伤害百分比减少,减少{type}类型伤害{reduceValue}%",
                        Type = type,
                        Value = reduceValue
                    });
                    break;
            }
        }

        public bool Filter(IEntity entity, ISkillDataComponent skill)
        {
            return skill is HelloWorldSkill;
        }
    }
}