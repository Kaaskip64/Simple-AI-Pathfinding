using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

using BehaviourTree;

public class GuardBT : Tree
{
    public UnityEngine.Transform[] waypoints;
    public UnityEngine.Transform[] guardWeaponCaches;
    public UnityEngine.Material[] statusIconMaterials;
    public UnityEngine.Transform playerTransform;
    public GuardAlertStatus guardStatus;

    public float patrolSpeed;
    public float alertSpeed;

    public float fovRange;
    public float attackRange;

    public int stunnedTime;

    public static NavMeshAgent nav;
    public static UnityEngine.MeshRenderer statusRenderer;

    void Awake()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        statusRenderer = UnityEngine.GameObject.Find("Guard Status Icon").GetComponent<UnityEngine.MeshRenderer>();
    }

    protected override BTNode SetupTree()
    {
        BTNode root = new BTSelector(new BTNode[] 
        {
            new Stunned(stunnedTime, guardStatus),
                new BTSelector(new BTNode[] 
                {
                    new BTSequence(new BTNode[] 
                    {
                        new CheckForPlayer(transform, playerTransform, guardStatus,statusIconMaterials, fovRange),
                        new SearchForWeapon(transform, guardWeaponCaches, alertSpeed, statusIconMaterials),
                        new ChasePlayer(transform, playerTransform, fovRange, attackRange, alertSpeed, guardStatus, statusIconMaterials),
                    }),
                    new Patrol(transform, waypoints, patrolSpeed)
                })  
        });
        return root;
    }
}
