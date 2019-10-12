//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月15日-19:04
//CabinIcarus.SkillSystem.Runtime

using System;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys
{
    public interface IEntity
    {
    }
    
    public struct IcSkSEntity:IEquatable<IcSkSEntity>
    {
        public readonly int ID;

        public IcSkSEntity(int id)
        {
            ID = id;
        }
#if CSHARP_7_OR_LATER
        //todo 
#endif

        public bool Equals(IcSkSEntity other)
        {
            return ID == other.ID;
        }

        public override bool Equals(object obj)
        {
            return obj is IcSkSEntity other && Equals(other);
        }

        public override int GetHashCode()
        {
            return ID;
        }

        public static implicit operator int(IcSkSEntity entity)
        {
            return entity.ID;
        }
        
        public static implicit operator IcSkSEntity(int id)
        {
            return new IcSkSEntity(id);
        }
    }
}