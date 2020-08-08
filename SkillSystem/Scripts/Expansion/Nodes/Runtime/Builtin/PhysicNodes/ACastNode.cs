using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEngine;
using XNode;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [Node.NodeWidthAttribute(200)]
    public abstract class ACastNode<T>:AConditionNode
    {
        protected ACastNode()
        {
            Result = new T[MaxHitSize];
        }

        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [Label("Cast Owner")]
        [PortTooltip("no input use SkillGroup Owner")]
        private GameObject _owner;

        [PortTooltip("Follow owner")]
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private ValueInfo<bool> _followOwner;

        [PortTooltip("0 or less 0 is one Cast,less -1 Unlimited duration, else Every time Clock update Cast,Until the end of the duration")]
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private ValueInfo<float> _duration;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [Node.LabelAttribute("Layer Mask")]
        private ValueInfo<LayerMask> _mask;
        
        protected LayerMask Mask => GetInputValue(nameof(_mask),_mask);

        public GameObject Owner => GetInputValue(nameof(_owner),SkillGraph.Owner);

        #region Debug

#if UNITY_EDITOR

        /// <summary>
        /// Only Editor
        /// </summary>
        public bool Debug;
        
        /// <summary>
        /// Only Editor
        /// </summary>
        public Color Color = Color.red;

        private DrawGizmosComponent _drawGizmosComponent;

        void _debugInit()
        {
            if (_drawGizmosComponent == null)
            {
                GameObject go = new GameObject("Cast Node Debug");
                go.transform.SetParent(Owner.transform);
                _drawGizmosComponent = go.AddComponent<DrawGizmosComponent>();
                _drawGizmosComponent.OnDraw += () => { Gizmos.color = Color; };
                _drawGizmosComponent.OnDraw += OnDrawGizmos;
            }
        }
#endif
        private void _debugStart()
        {
#if UNITY_EDITOR
            _debugInit();
            if (!Debug)
            {
                return;
            }
            _drawGizmosComponent.ShowDebug();
#endif
        }

        private void _debugStop()
        {
#if UNITY_EDITOR
            _debugInit();
            if (!Debug)
            {
                return;
            }
            _drawGizmosComponent.HideDebug();
#endif
        }

        protected virtual void OnDrawGizmos(){}
#endregion

        private float _time;
        
        protected sealed override bool Condition()
        {
            _debugStart();
            
            if (_time <= 0)
            {
                _time = GetInputValue(nameof(_duration), _duration);
                _ownerPos = Owner.transform.position;
            }

            if (GetInputValue(nameof(_followOwner),_followOwner))
            {
                _ownerPos = Owner.transform.position;
            }
            
            _resultCount = OnCast();

            var result = _resultCount > 0;
            
            _time -= Time.deltaTime;
            bool durEnd = false;
            
            if (_time <= -1)
            {
                durEnd = false;
            }
            else if (_time <= 0)
            {
                durEnd = true;
            }

            result |= durEnd;
            
            if (result)
            {
                _debugStop();
            }

            return result;
        }

        protected abstract int OnCast();
        
        [OutputAttribute]    
        protected T[] Result;

        [OutputAttribute]    
        private int _resultCount;
        
        protected sealed override object GetPortValue(NodePort port)
        {
            if (port.fieldName == nameof(Result))
            {
                return Result;
            }

            if (port.fieldName == nameof(_resultCount))
            {
                return _resultCount;
            }
            
            return GetOtherPortValue(port);
        }

        protected virtual object GetOtherPortValue(NodePort port)
        {
            return null;
        }

        [SerializeField]
        [PortTooltip("Max Ray cast Hit Result Count,default:100,min is 1")]
        [Min(1)]
        protected int MaxHitSize = 100;

        [PortTooltip("no input Point use")]
        [SerializeField,Node.InputAttribute(Node.ShowBackingValue.Always,Node.ConnectionType.Override,Node.TypeConstraint.Strict)]
        [Node.LabelAttribute("Owner Add Offset")]
        private ValueInfo<Vector3> _offset;

        [PortTooltip("no input use Owner")]
        [SerializeField,Node.InputAttribute(Node.ShowBackingValue.Always,Node.ConnectionType.Override,Node.TypeConstraint.Strict)]
        [Node.LabelAttribute("Designated point")]
        private ValueInfo<Vector3> _point;

        private Vector3 _ownerPos;
        protected Vector3 Origin => _ownerPos + Offset;

        protected Vector3 Point => GetInputValue(nameof(_point), _point);

        protected bool PointIsInput => GetPort(nameof(_point)).IsConnected;
        
        protected Vector3 Offset => GetInputValue(nameof(_offset), _offset);
    }
}