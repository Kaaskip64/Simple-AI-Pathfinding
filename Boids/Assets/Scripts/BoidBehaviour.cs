using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Most of this script is implemented from this tutorial: https://www.dawn-studio.de/tutorials/boids/
public class BoidBehaviour : MonoBehaviour
{
    public int swarmIndex { get; set; }
    public float noClumpingRadius = 5f;
    public float localAreaRadius = 10f;
    public float speed = 10f;
    public float steeringSpeed = 100f;

    public void SimulateMovement(List<BoidBehaviour> other, float time)
    {
        Vector3 steering = Vector3.zero;
        Vector3 alignmentDirection = Vector3.zero;
        Vector3 cohesionDirection = Vector3.zero;

        int alignmentCount = 0;
        int cohesionCount = 0;
        int separationCount = 0;

        transform.position += transform.TransformDirection(new Vector3(0, 0, speed)) * time;

        Vector3 separationDirection = Vector3.zero;

        foreach (BoidBehaviour boid in other)
        {
            if (boid == this)
            {
                continue;
            }
            float distance = Vector3.Distance(boid.transform.position, transform.position);

            if (distance < noClumpingRadius)
            {
                Seperation(ref separationDirection, boid, ref separationCount);
            }

            if (distance < localAreaRadius)
            {
                Alignment(ref alignmentDirection, boid, ref alignmentCount);

                Cohesion(ref cohesionDirection, boid, ref cohesionCount);
            }
        }

        cohesionDirection -= transform.position;

        if (separationCount > 0)
        {
            separationDirection /= separationCount;
        }

        separationDirection = -separationDirection.normalized;

        steering = separationDirection;

        steering += alignmentDirection;
        steering += cohesionDirection;

        if (steering != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(steering), steeringSpeed * time);
        }

    }

    public void Seperation(ref Vector3 separationDirection, BoidBehaviour boid, ref int separationCount)
    {
        separationDirection += boid.transform.position - transform.position;
        separationCount++;
    }
    public void Alignment(ref Vector3 alignmentDirection, BoidBehaviour boid, ref int alignmentCount)
    {
        alignmentDirection += boid.transform.forward;
        alignmentCount++;
    }

    public void Cohesion(ref Vector3 cohesionDirection, BoidBehaviour boid, ref int cohesionCount)
    {
        cohesionDirection += boid.transform.position - transform.position;
        cohesionCount++;
    }
}
