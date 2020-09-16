//Create: Icarus
//ヾ(•ω•`)o
//2020-09-15 12:24
//CabinIcarus.IcSkillSystem.Expansion.Nodes.Runtime

using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEngine;
using XNode;
using Random = UnityEngine.Random;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Random Vector3")]
    public class RandomVector3ValueNode:ValueNode<ValueInfo<Vector3>>
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override, TypeConstraint.Inherited)]
        [SerializeField]
        private ValueInfo<Vector3> _a;
        
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Inherited)]
        [SerializeField]
        private ValueInfo<Vector3> _b;

        [Output(ShowBackingValue.Always,ConnectionType.Multiple,TypeConstraint.InheritedInverse)]
        private ValueInfo<Vector3> _lastRandom;

        private ValueInfo<Vector3> _value;
        
        protected override ValueInfo<Vector3> GetTValue()
        {
            var a = GetInputValue(nameof(_a), _a);
            
            var b = GetInputValue(nameof(_b), _b);
            
            var value = new Vector3(
                _random(a.Value.x, b.Value.x),
                _random(a.Value.y, b.Value.y),
                _random(a.Value.z, b.Value.z));

            _lastRandom = value;

            _value = value;
            
            return _value;
        }

        protected override object GetPortValue(NodePort port)
        {
            if (port.fieldName == nameof(_lastRandom))
            {
                return _lastRandom;
            }
            
            return base.GetPortValue(port);
        }

        float _random(float a, float b)
        {
            return Random.Range(a, b);
        }
        
        
    }
}