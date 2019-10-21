//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月28日-14:39
//Assembly-CSharp

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components
{
    public interface IPercentage{}
    
    public struct Mechanics:IMechanicBuff
    {
        public float BaseValue;
        public float Value
        {
            get => BaseValue + AddValue;
            set{}
        }
        public float AddValue;
        public MechanicsType MechanicsType { get; set; }
    }
}