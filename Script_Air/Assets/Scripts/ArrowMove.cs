using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public Transform PlayerTransform;

    // Update is called once per frame
    void Update()
    {
        Vector3 toTargetXZ = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y + 1f, PlayerTransform.position.z);
        transform.position = toTargetXZ;
    }
}
