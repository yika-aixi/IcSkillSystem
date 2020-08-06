//Create: Icarus
//ヾ(•ω•`)o
//2020-07-05 10:48
//CabinIcarus.IcSkillSystem.Expansion.Nodes.Runtime

using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    public abstract class ACast2DNode<T>:ACastNode<T>
    {
        [SerializeField] 
        private bool _zIsY;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private ValueInfo<float> _minDepth;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private ValueInfo<float> _maxDepth;

        protected float MinDepth => GetInputValue(nameof(_minDepth), _minDepth);
        
        protected float MaxDepth => GetInputValue(nameof(_maxDepth),_maxDepth);

        protected Vector2 ToVector2(in Vector3 point)
        {
            return new Vector2(point.x, _zIsY ? point.z : point.y);
        }

        protected Vector2 GetPoint()
        {
            return PointIsInput ? ToVector2(Point) : ToVector2(Origin);
        }
    }
}