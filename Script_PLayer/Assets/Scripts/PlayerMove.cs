using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public Transform ColliderTransform;

    private int _jumpFrameCounter;
   
  
    public bool Ground;
    public float MaxSpeed;

   
    public void Update()
    {
       

        if (Ground)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }       

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || Ground == false)
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 10f);
        }
        else
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        }
    }

    public void Jump()
    {
        
        Rigidbody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;

    }

    public void FixedUpdate()
    {

        float speedMultiplayer = 1f;
        if(Ground == false)
        {
            speedMultiplayer = 0.2f;
            if (Rigidbody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultiplayer = 0f;
            }
            if (Rigidbody.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultiplayer = 0f;
            }
        }

        Rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedMultiplayer, 0, 0, ForceMode.VelocityChange);

        if (Ground)
        {
            Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15f);
        }

        _jumpFrameCounter += 1;
        if(_jumpFrameCounter == 2)
        {
            Rigidbody.freezeRotation = false;
            Rigidbody.AddRelativeTorque(0f, 0f, 10f, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        float dot = Vector3.Dot(Vector3.up, normal);
        if(dot > 0.5f)
        {
            Ground = true;
            Rigidbody.freezeRotation = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Ground = false;
    }
}
