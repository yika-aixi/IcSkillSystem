using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DesperateDevs.Utils;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node.Utils
{
    public static class TypeUtil
    {
        private static List<Type> _objectTypes = new List<Type>();

        public static IEnumerable<Type> AllTypes => _objectTypes;
        
        public static IEnumerable<Type> RuntimeTypes => _objectTypes.Where(x=>!x.Assembly.FullName.Contains("Editor"));

        static TypeUtil()
        {
            _collectValueTyps();
        }

        private static void _collectValueTyps()
        {
            _objectTypes.AddRange(AppDomain.CurrentDomain.GetAllTypes().Where(x => x.IsPublic));
        }
    }
}