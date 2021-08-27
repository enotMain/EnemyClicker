using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class PSEnemy : MonoBehaviour
{
    private ParticleSystem _enemyPS;

    private void Awake()
    {
        _enemyPS = GetComponent<ParticleSystem>();
    }

    [System.Obsolete]
    private void Start()
    {
        _enemyPS.startColor = new Color(0.4f, 0.75f, 0.47f);
    }
}
