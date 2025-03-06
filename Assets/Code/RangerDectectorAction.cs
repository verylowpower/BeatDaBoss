using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RangerDectector", story: "Update [RangeDetectors] and Assign [Target]", category: "Action", id: "44e2470874cf94aea0a731c900dcccb9")]
public partial class RangerDectectorAction : Action
{
    [SerializeReference] public BlackboardVariable<RangeDectector> RangeDetectors;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    
    protected override Status OnUpdate()
    {   
        Target.Value = RangeDetectors.Value.UpdateDetector();
        return Target.Value == null ? Status.Failure : Status.Success;
    
    }
}

