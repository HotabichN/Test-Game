using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    public float AttackPeriod = 5f;
    public Animator Animator;
    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > AttackPeriod)
        {
            _timer = 0;
            Animator.SetTrigger("Attack");
        }
    }
}
