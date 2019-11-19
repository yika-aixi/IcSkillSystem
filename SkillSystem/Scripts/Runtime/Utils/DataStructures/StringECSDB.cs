namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    /// <summary>
    /// https://github.com/sebas77/Svelto.ECS/blob/master/Svelto.ECS.Components/ECSResources/StringECSDB.cs
    /// </summary>
    public struct ECSString
    {
        internal uint id;

        ECSString(uint toEcs)
        {
            id = toEcs;
        }

        public static implicit operator string(ECSString ecsString)
        {
            return ResourcesECSDB<string>.FromECS(ecsString.id);
        }
        
        public static implicit operator ECSString(string text)
        {
            return new ECSString(ResourcesECSDB<string>.ToECS(text));
        }
    }
}