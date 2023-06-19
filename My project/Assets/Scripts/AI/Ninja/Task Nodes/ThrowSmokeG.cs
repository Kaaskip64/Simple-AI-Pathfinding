using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class ThrowSmokeG : BTNode
{
    private GuardAlertStatus guard;

    public ThrowSmokeG(GuardAlertStatus _guard)
    {
        guard = _guard;
    }

    public override BTResult Run()
    {
        if (guard.seesPlayer)
        {
            guard.isStunned = true;
            NinjaBT.smokeGrenadeParticles.Play();
            return BTResult.Succes;
        }
        return BTResult.Failed;
    }
}
