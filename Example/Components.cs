using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using Entitas;
using IEntity = CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys.IEntity;

namespace CabinIcarus.IcSkillSystem.Expansions
{
    public class MechanicBuff:IMechanicBuff
    {
        public float Value { get; set; }
        public MechanicsType MechanicsType { get; }

        public MechanicBuff(MechanicsType mechanicsType)
        {
            MechanicsType = mechanicsType;
        }
    }
    
    public class DamageBuff:IDamageBuff
    {
        public float Value { get; set; }
        public IEntity Maker { get; set; }
        public int Type { get; set; }
    }
    
    public class ContinuousDamageBuff:IContinuousDamageBuff
    {
        public float Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public float Duration { get; set; }
        public float LastTriggerTime { get; set; }
        public float TriggerInterval { get; set; }
        public IEntity Maker { get; set; }
    }
    
    public class DamageReduceFixedBuff:IDamageReduceFixedBuff
    {
        public float Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
    }
    
    public class DamageReducePercentageBuff:IDamageReducePercentageBuff
    {
        private float _value;

        public float Value
        {
            get => _value / 100;
            set => _value = value;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
    }
}