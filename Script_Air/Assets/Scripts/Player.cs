using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CoinManager CoinManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Coin>())
        {
            CoinManager.CollectCoin(other.GetComponent<Coin>());
        }
    }
}
