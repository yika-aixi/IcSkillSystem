using System.Collections.Generic;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    /// <summary>
    /// https://github.com/sebas77/Svelto.ECS/blob/master/Svelto.ECS.Components/ECSResources/ECSResources.cs
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct ECSResources<T>
    {
        internal uint id;
        
        ECSResources(uint toEcs)
        {
            id = toEcs;
        }
        
        public static implicit operator T(ECSResources<T> resources) { return ResourcesECSDB<T>.FromECS(resources.id); }
        
        public static implicit operator ECSResources<T>(T value) { return new ECSResources<T>(ResourcesECSDB<T>.ToECS(value));}

        public void Release()
        {
            ResourcesECSDB<T>.Release(id);
            id = 0;
        }
    }
    
    static class ResourcesECSDB<T>
    {
        internal static readonly FasterList<T> _resources = new FasterList<T>();

        static Queue<int> _releaseQueue = new Queue<int>();
        
        internal static uint ToECS(T resource)
        {
            if (resource == null)
            {
                return 0;
            }

            if (_releaseQueue.Count > 0)
            {
                var index = _releaseQueue.Dequeue();
                _resources[index] = resource;
                return (uint) (index + 1);
            }
            else
            {
                _resources.Add(resource);
                return (uint)_resources.Count;
            }
        }

        public static T FromECS(uint id)
        {
            if (id - 1 < _resources.Count && id >= 1)
                return _resources[(int) id - 1];
            
            return default;
        }

        public static void Release(uint id)
        {
            if (id - 1 < _resources.Count && id >= 1)
                _releaseQueue.Enqueue((int) id - 1);
        }
    }   

    public static class ResourceExtensions
    {
        public static T Get<T>(ref this ECSResources<T> resources)
        {
            return resources;
        }
        public static void Set<T>(ref this ECSResources<T> resource, T newText)
        {
            if (resource.id != 0)
                ResourcesECSDB<T>._resources[(int) resource.id] = newText;
            else
                resource.id = ResourcesECSDB<T>.ToECS(newText);
        }
        
        public static void Set(ref this ECSString resource, string newText)
        {
            if (resource.id != 0)
                ResourcesECSDB<string>._resources[(int) resource.id] = newText;
            else
                resource.id = ResourcesECSDB<string>.ToECS(newText);
        }
        
    }
}