using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys
{
    public struct IcEntityStruct
    {
        private readonly uint id;

        public IcEntityStruct(uint id)
        {
            this.id = id;
        }

        public static implicit operator uint(IcEntityStruct ecsString)
        {
            return ecsString.id;
        }
    }

    public static class IcEntityStructEX
    {
        public static IIcSkSEntity ToIIcSkSEntity(this IcEntityStruct entityStruct)
        {
            return ResourcesECSDB<IIcSkSEntity>.FromECS(entityStruct);
        }

        public static IcEntityStruct FromIIcSkSEntity(this IIcSkSEntity entity)
        {
            return new IcEntityStruct(ResourcesECSDB<IIcSkSEntity>.ToECS(entity));
        }
    }
}