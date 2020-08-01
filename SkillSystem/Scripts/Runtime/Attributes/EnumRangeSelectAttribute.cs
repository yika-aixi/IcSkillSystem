//Create: Icarus
//ヾ(•ω•`)o
//2020-08-01 05:19
//CabinIcarus.IcSkillSystem.Runtime

using System;
using UnityEngine;

namespace CabinIcarus.IcFrameWork.IcSkillSystem.SkillSystem.Scripts.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumRangeSelectAttribute:PropertyAttribute
    {
        public readonly Type EnumType;

        public readonly int Min;
        
        public readonly int Max;

        public readonly string Label;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType">enum Type</param>
        /// <param name="min">range contain min</param>
        /// <param name="max">range contain max</param>
        /// <param name="label">custom label. null or WhiteSpace use default label</param>
        public EnumRangeSelectAttribute(Type enumType, int min, int max,string label)
        {
            EnumType = enumType;
            if (!EnumType.IsEnum)
            {
                throw new ArgumentException("type not is enum type",nameof(enumType));
            }
            Min = min;
            Max = max;
            Label = label;
        }

        public string GetLabel(string defaultLabel)
        {
            if (string.IsNullOrWhiteSpace(Label))
            {
                return defaultLabel;
            }

            return Label;
        }
    }
}