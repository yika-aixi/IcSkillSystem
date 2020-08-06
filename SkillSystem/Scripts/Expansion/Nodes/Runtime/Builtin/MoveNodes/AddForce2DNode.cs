using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEngine;
using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Move/Add Force 2D")]
    public class AddForce2DNode : AMoveNode
    {
        [SerializeField]
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private ValueInfo<Vector2> _forward;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private ValueInfo<ForceMode2D> _mode;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private ValueInfo<float> _force;
        
        protected override Action.Result Move(Action.Request arg)
        {
            var rigid = Tran.GetComponent<Rigidbody2D>();

            if (rigid)
            {
                float force = _force;
                var inputValue = GetInputValue(nameof(_force), _force);
                
                rigid.AddForce(GetInputValue(nameof(_forward),_forward).Value * inputValue,GetInputValue(nameof(_mode),_mode));
            }
           
            return CompleteResult;
        }
    }
}