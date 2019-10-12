using System;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys
{
    public struct IcSkSEntity:IEquatable<IcSkSEntity>,IIcSkSEntity
    {
        public int ID { get; }

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