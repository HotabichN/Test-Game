using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigdbody;
    public Transform CameraCenter;

    public float TorqueValue;

    // Start is called before the first frame update
    void Start()
    {
        _rigdbody = GetComponent<Rigidbody>();
        _rigdbody.maxAngularVelocity = 500;// 7 - по умолчанию
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigdbody.AddTorque(CameraCenter.right * Input.GetAxis("Vertical") * TorqueValue);

        _rigdbody.AddTorque(-CameraCenter.forward * Input.GetAxis("Horizontal") * TorqueValue);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigdbody.AddForce(Vector3.up * 200f);
        }
    }
}
