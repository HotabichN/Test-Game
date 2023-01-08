using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlus : MonoBehaviour
{
    public Vector3 RotateSpeed;

    void Update()
    {
        transform.Rotate(RotateSpeed * Time.deltaTime);
    }
}
