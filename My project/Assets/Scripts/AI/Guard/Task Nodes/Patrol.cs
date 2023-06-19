using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using BehaviourTree;
public class Patrol : BTNode
{
    private Transform transform;
    private Transform[] waypoints;
    private float speed;

    private int currentWaypointIndex = 0;

    public Patrol(Transform _transform, Transform[] _waypoints, float _speed)
    {
        transform = _transform;
        waypoints = _waypoints;
        speed = _speed;
    }

    public override BTResult Run()
    {
        GuardBT.nav.speed = speed;
        Transform wp = waypoints[currentWaypointIndex];

        GuardBT.nav.SetDestination(wp.position);

        if (Vector3.Distance(transform.position, wp.position) < 2f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
        return BTResult.Running;
    }
}
