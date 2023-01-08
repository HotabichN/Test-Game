using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float Speed = 5f;

    void Start()
    {
        transform.rotation = Quaternion.identity;
        Transform PlayerTransform = FindObjectOfType<PlayerMove>().transform;
        Vector3 toPlayer = (PlayerTransform.position - transform.position).normalized;
        Rigidbody.velocity = toPlayer * Speed;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }

}
