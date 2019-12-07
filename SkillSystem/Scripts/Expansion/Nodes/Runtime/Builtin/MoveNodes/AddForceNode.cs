using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Move/Add Force")]
    public class AddForceNode : AMoveNode
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private Vector3 _forward;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private ForceMode _mode;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private float _force;
        
        protected override Action.Result Move(Action.Request arg)
        {
            Tran.GetComponent<Rigidbody>().AddForce(GetInputValue(nameof(_forward),_forward) * GetInputValue(nameof(_force),_force),GetInputValue(nameof(_mode),_mode));

            return CompleteResult;
        }
    }
}