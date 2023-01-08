using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenSpawner : MonoBehaviour
{
    public GameObject Prefab;
    public Transform[] Spawn;

    public void Start()
    {
        for (int i = 0; i < Spawn.Length; i++)
        {
            Instantiate(Prefab, Spawn[i].position, Spawn[i].rotation);
        }
    }
}
