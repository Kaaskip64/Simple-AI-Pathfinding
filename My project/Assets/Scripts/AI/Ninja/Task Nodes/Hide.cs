using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class Hide : BTNode
{
    private Material[] materials;
    private Transform[] waypoints;
    private Transform transform;
    private GuardAlertStatus guard;

    private int currentWaypointIndex = 0;

    public Hide(Transform[] _waypoints, Transform _transform, GuardAlertStatus _guard, Material[] _materials)
    {
        waypoints = _waypoints;
        transform = _transform;
        guard = _guard;
        materials = _materials;
    }
    public override BTResult Run()
    {
        if (guard.seesPlayer)
        {
            Debug.Log("Player Detected");

            NinjaBT.statusRenderer.material = materials[1];

            Vector3 guardPos = guard.transform.position;

            Transform wp = waypoints[currentWaypointIndex];
            NinjaBT.nav.SetDestination(wp.position);
            if (Vector3.Distance(transform.position, wp.position) < 2f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }

            RaycastHit hit;
            Debug.DrawRay(transform.position, guardPos - transform.position);

            Physics.Raycast(transform.position, guardPos - transform.position, out hit, Mathf.Infinity);
            
            if (hit.transform.gameObject.tag != "Guard" &&  hit.transform.gameObject.tag != "Player")
            {
                Debug.Log("LOS broken");
                return BTResult.Succes;
            }
        }

        return BTResult.Failed;
    }
}
