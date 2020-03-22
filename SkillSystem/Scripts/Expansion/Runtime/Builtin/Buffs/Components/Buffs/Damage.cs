//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月28日-14:40
//Assembly-CSharp

using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components
{
    public struct Damage:IDamageBuff
    {
        public float Value { get; set; }
        public int Type { get; set; }
        public int ID { get; }
        public IIcSkSEntity Entity { get; set; }
    }
}