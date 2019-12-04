using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEditor;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Editor
{
    [CustomPropertyDrawer(typeof(ValueSDict))]
    public class ValueSDictPropertyDrawer : SerializationDictDrawer
    {
    }
}