using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator;
using NPBehave;
using UnityEngine;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [Node.NodeWidthAttribute(200)]
    public abstract class ACastNode:AObservingDecoratorNode<Condition>
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [Label("Cast Owner")]
        [PortTooltip("no input use SkillGroup Owner")]
        private GameObject _owner;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [Node.LabelAttribute("Layer Mask")]
        private LayerMask _mask;
        
        protected LayerMask Mask => GetInputValue(nameof(_mask),_mask);

        public GameObject Owner => GetInputValue(nameof(_owner),SkillGroup.Owner);

        #region Debug

#if UNITY_EDITOR

        class DrawGizmosCom:MonoBehaviour
        {
            public System.Action OnDraw;
            public bool IsOpen;
            
            private void OnDrawGizmos()
            {
                if (IsOpen)
                {
                    OnDraw?.Invoke();
                }
            }

        }
        
        /// <summary>
        /// Only Editor
        /// </summary>
        public bool Debug;
        
        /// <summary>
        /// Only Editor
        /// </summary>
        public Color Color = Color.red;

        private DrawGizmosCom _drawGizmosCom;

        void _debugInit()
        {
            if (_drawGizmosCom == null)
            {
                GameObject go = new GameObject("Cast Node Debug");
                go.transform.SetParent(Owner.transform);
                _drawGizmosCom = go.AddComponent<DrawGizmosCom>();
                _drawGizmosCom.OnDraw += () => { Gizmos.color = Color; };
                _drawGizmosCom.OnDraw += OnDrawGizmos;
            }
        }
#endif
        protected void DebugStart()
        {
#if UNITY_EDITOR
            _debugInit();
            if (!Debug)
            {
                return;
            }
            _drawGizmosCom.IsOpen = true;
#endif
        }
        
        protected void DebugStop()
        {
#if UNITY_EDITOR
            _debugInit();
            if (!Debug)
            {
                return;
            }
            _drawGizmosCom.IsOpen = false;
#endif
        }

        protected virtual void OnDrawGizmos(){}
#endregion
        
        [SerializeField]
        [PortTooltip("Max Ray cast Hit Result Count,default:100,min is 1")]
        [Min(1)]
        protected int MaxHitSize = 100;

        [SerializeField,Node.InputAttribute(Node.ShowBackingValue.Always,Node.ConnectionType.Override,Node.TypeConstraint.Strict)]
        [Node.LabelAttribute("Owner Add Offset")]
        private Vector3 _offset;

        protected Vector3 Origin => Owner.transform.position + Offset;
        
        protected Vector3 Offset => GetInputValue(nameof(_offset), _offset);
        
        protected sealed override Condition GetDecoratorNode()
        {
            return new Condition(CastCheck,Stops,DecorateeNode);
        }

        protected abstract bool CastCheck();
    }
}