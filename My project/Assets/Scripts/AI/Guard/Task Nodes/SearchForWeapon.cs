using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


using BehaviourTree;

public class SearchForWeapon : BTNode
{
    private Transform transform;
    private Transform[] weaponCaches;
    private float speed;
    private Material[] materials;

    private float cacheInRange = 2f;
    public SearchForWeapon(Transform _transform, Transform[] _weaponCaches, float _speed, Material[] _materials)
    {
        transform = _transform;
        weaponCaches = _weaponCaches;
        speed = _speed;
        materials = _materials;
    }
    public override BTResult Run()
    {
        GuardBT.statusRenderer.material = materials[1];
        Transform[] cachesByDistance = weaponCaches.OrderBy(t => Vector3.Distance(transform.position, t.transform.position)).ToArray();
        GuardBT.nav.speed = speed;
        GuardBT.nav.SetDestination(cachesByDistance[0].transform.position);

        if (Vector3.Distance(transform.position, cachesByDistance[0].transform.position) < cacheInRange)
        {
             return BTResult.Succes;
        }

        return BTResult.Running;
    }
}
