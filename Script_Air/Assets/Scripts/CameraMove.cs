using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform PlayerTransform;
    public Rigidbody PlayerRigidbody;

    public List<Vector3> VelocityList = new List<Vector3>();

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            VelocityList.Add(Vector3.zero);
        }
    }

    private void FixedUpdate()
    {
        VelocityList.Add(PlayerRigidbody.velocity);
        VelocityList.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 summ = Vector3.zero;
        for (int i = 0; i < VelocityList.Count; i++)
        {
            summ += VelocityList[i];
        }
        transform.position = PlayerTransform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(summ),Time.deltaTime * 10f);
    }
}
