//Create: Icarus
//ヾ(•ω•`)o
//2020-07-05 01:32
//CabinIcarus.IcSkillSystem.Runtime

using UnityEngine;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    public static class ComponentEx
    {
        public static T GetOrAddComponent<T>(this GameObject self) where T : Component
        {
            var value = self.GetComponent<T>();

            if (!value)
            {
                value = self.AddComponent<T>();
            }

            return value;
        }

        public static T GetOrAddComponent<T>(this Transform self) where T : Component
        {
            return self.gameObject.GetOrAddComponent<T>();
        }

        public static T GetOrAddComponent<T>(this Component self) where T : Component
        {
            return self.transform.GetOrAddComponent<T>();
        }
    }
}