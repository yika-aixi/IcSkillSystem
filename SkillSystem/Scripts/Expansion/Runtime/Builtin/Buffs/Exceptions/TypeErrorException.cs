using System;

namespace IcSkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Buffs.Exceptions
{
    public class TypeErrorException:Exception
    {
        public Type TargetType { get; }

        public TypeErrorException(Type targetType)
        {
            TargetType = targetType;
        }

        public TypeErrorException(string message, Type targetType) : base(message)
        {
            TargetType = targetType;
        }

        public TypeErrorException(string message, Exception innerException, Type targetType) : base(message, innerException)
        {
            TargetType = targetType;
        }
    }
}