using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class CheckForPlayer : BTNode
{
    private Material[] materials;
    private Transform transform;
    private Transform playerTransform;
    private GuardAlertStatus guard;
    private float fov;
    public CheckForPlayer(Transform _transform, Transform _playerTransform, GuardAlertStatus _guard, Material[] _materials, float _fov)
    {
        transform = _transform;
        playerTransform = _playerTransform;
        fov = _fov;
        guard = _guard;
        materials = _materials;
    }

    public override BTResult Run()
    {
        if (playerTransform != null)
        {


            RaycastHit hit;
            Debug.DrawRay(transform.position, playerTransform.position - transform.position);

            if (Physics.Raycast(transform.position, playerTransform.position - transform.position, out hit, fov))
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    //Debug.Log("Player Detected");
                    guard.seesPlayer = true;
                    return BTResult.Succes;
                }
            }
        }
        guard.seesPlayer = false;
        GuardBT.statusRenderer.material = materials[0];
        return BTResult.Failed;
    }
}
