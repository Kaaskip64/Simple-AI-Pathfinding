using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class Stunned : BTNode
{
    float stunnedCounter = 0;

    float stunnedTime;

    private GuardAlertStatus guard;


    public Stunned (float _stunnedTime, GuardAlertStatus _guard)
    {
        stunnedTime = _stunnedTime;
        guard = _guard;
    }

    public override BTResult Run()
    {
        if(guard.isStunned)
        {
            GuardBT.nav.isStopped = true;
            guard.seesPlayer = false;
            stunnedCounter += Time.deltaTime;
            if (stunnedCounter >= stunnedTime)
            {
                stunnedCounter = 0;
                GuardBT.nav.isStopped = false;
                guard.isStunned = false;
            }
            return BTResult.Running;
        }
        //Debug.Log("Not Stunned");
        return BTResult.Failed;
    }
}
