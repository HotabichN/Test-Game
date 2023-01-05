using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    public CoinManager CoinManager;
    public Coin ClosestCoin;


    // Update is called once per frame
    void Update()
    {
        ClosestCoin = CoinManager.GetClosest(transform.position);

        Vector3 toTarget = ClosestCoin.transform.position - transform.position;
        Vector3 toTargetXZ = new Vector3(toTarget.x, 0f, toTarget.z);
        transform.rotation = Quaternion.LookRotation(toTargetXZ);

        Debug.DrawLine(transform.position, ClosestCoin.transform.position);
    }
}
