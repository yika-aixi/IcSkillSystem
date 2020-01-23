using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEngine;
using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Move/Add Force")]
    public class AddForceNode : AMoveNode
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private ValueInfo<Vector3> _forward;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private IcVariableForceMode _mode;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private IcVariableSingle _force;
        
        protected override Action.Result Move(Action.Request arg)
        {
            var rigid = Tran.GetComponent<Rigidbody>();

            if (rigid)
            {
                rigid.AddForce(GetInputValue(nameof(_forward),_forward).Value * GetInputValue(nameof(_force),_force),GetInputValue(nameof(_mode),_mode));
            }

            return CompleteResult;
        }
    }
}