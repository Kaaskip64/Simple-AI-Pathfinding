using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class FollowPlayer : BTNode
{
    private Material[] materials;
    private Transform playerPos;
    private GuardAlertStatus guard;
    public FollowPlayer(Transform _playerPos, GuardAlertStatus _guard, Material[] _materials)
    {
        playerPos = _playerPos;
        guard = _guard;
        materials = _materials;
    }

    public override BTResult Run()
    {
        if (!guard.seesPlayer)
        {
            NinjaBT.statusRenderer.material = materials[0];
            NinjaBT.nav.SetDestination(playerPos.position);
            return BTResult.Running;
        }

        return BTResult.Failed;
    }
}
