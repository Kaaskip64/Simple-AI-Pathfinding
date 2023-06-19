using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
public class ChasePlayer : BTNode
{
    private Material[] materials;
    private Transform transform;
    private Transform playerTransform;
    private GuardAlertStatus guard;
    private float speed;
    private float fov;
    private float attackRange;


    public ChasePlayer(Transform _transform, Transform _playerTransform, float _fov, float _attackRange, float _speed, GuardAlertStatus _guard, Material[] _materials)
    {
        transform = _transform;
        playerTransform = _playerTransform;
        fov = _fov;
        attackRange = _attackRange;
        speed = _speed;
        guard = _guard;
        materials = _materials;
    }

    public override BTResult Run()
    {
        if (guard.seesPlayer)
        {
            if (Vector3.Distance(transform.position, playerTransform.position) < fov)
            {
                GuardBT.statusRenderer.material = materials[2];
                GuardBT.nav.speed = speed;
                GuardBT.nav.SetDestination(playerTransform.position);
                if (Vector3.Distance(transform.position, playerTransform.position) < attackRange)
                {
                    playerTransform.gameObject.SetActive(false);
                    return BTResult.Succes;
                }
                return BTResult.Running;
            }
        }


        return BTResult.Failed;
    }
}
