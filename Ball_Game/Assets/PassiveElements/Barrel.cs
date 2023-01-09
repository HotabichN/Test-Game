using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : PassiveItem
{
    [SerializeField] private GameObject _barrelExplosition;
    public override void OnAffect() {
        base.OnAffect();
        Die();
    }

    [ContextMenu("Die")]
    public void Die() {
        Instantiate(_barrelExplosition, transform.position, Quaternion.Euler(-90f, 0f, 0f));
        Destroy(gameObject);
        ScoreManager.Instance.AddScore(ItemType, transform.position);
    }
}
