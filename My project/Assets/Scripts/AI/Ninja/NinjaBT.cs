using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

using BehaviourTree;

public class NinjaBT : Tree
{
    public UnityEngine.Material[] statusIconMaterials;
    public UnityEngine.Transform[] waypoints;
    public UnityEngine.Transform playerProximityTransform;
    public GuardAlertStatus guardStatus;

    public static NavMeshAgent nav;
    public static UnityEngine.ParticleSystem smokeGrenadeParticles;
    public static UnityEngine.MeshRenderer statusRenderer;

    void Awake()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        smokeGrenadeParticles = guardStatus.gameObject.GetComponent<UnityEngine.ParticleSystem>();
        statusRenderer = UnityEngine.GameObject.Find("Ninja Status Icon").GetComponent<UnityEngine.MeshRenderer>();
    }

    protected override BTNode SetupTree()
    {
        BTNode root = new BTSelector(new BTNode[]
        {
            new BTSequence(new BTNode[]
            {
                new Hide(waypoints, transform, guardStatus, statusIconMaterials),
                new ThrowSmokeG(guardStatus),
            }),
            new FollowPlayer(playerProximityTransform, guardStatus, statusIconMaterials),

        });
        return root;
    }
}
