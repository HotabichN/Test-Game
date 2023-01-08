using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Rocket : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;

    private Transform _playerTransform;

 

    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * Speed;
        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);

        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

      
    }
}
