using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Transform _playerTransform;
    public float Speed = 3f;
    public float TimeToReashSpeed;
    

    void Start()
    {
        
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    
    void Update()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = Rigidbody.mass * (toPlayer * Speed - Rigidbody.velocity) / TimeToReashSpeed;
        Rigidbody.AddForce(force);
    }
}
