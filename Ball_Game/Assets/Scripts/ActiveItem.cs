using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActiveItem : Item
{
    public int Level;
    public float Radius;
    [SerializeField] protected TMPro.TMP_Text _levelText;

    
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected SphereCollider _trigger;

    public bool IsDead;
    public Projection Projection;
    public Rigidbody Rigidbody;

    [SerializeField] private Animator _animator;

    protected virtual void Start() {
        Projection.Hide();
    }

    [ContextMenu("IncreaseLevel")]

    public void IncreaseLevel() {
        Level++;
        SetLevel(Level);

        _animator.SetTrigger("IncreaseLevel");

        _trigger.enabled = false;
        Invoke(nameof(EnableTrigger), 0.08f);
    }

    public virtual void SetLevel(int level) {
        Level = level;
        //Обновляем число на шаре
        int number = (int)Mathf.Pow(2, level + 1);
        string numberString = number.ToString();
        _levelText.text = numberString;
    }

    private void EnableTrigger() {
        _trigger.enabled = true;
    }


    //Устанавливаем Item в трубу наверху
    public void SetupToTube() {
        //выключаем физику
        _trigger.enabled = false;
        _collider.enabled = false;
        Rigidbody.isKinematic = true;
        Rigidbody.interpolation = RigidbodyInterpolation.None;
    }

    //Роняем(Drop) шар из трубы вниз
    public void Drop() {
        //Делаем его физическим
        _trigger.enabled = true;
        _collider.enabled = true;
        Rigidbody.isKinematic = false;
        Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        //отперенчиваем от Spawn-a
        transform.parent = null;
        //задаем скорость вниз чтобы летел быстрее
        Rigidbody.velocity = Vector3.down * 0.8f;
    }

    
    private void OnTriggerEnter(Collider other) {

        if (IsDead) return;

        if (other.attachedRigidbody) {
            ActiveItem otherItem = other.attachedRigidbody.GetComponent<ActiveItem>();
            if (otherItem) {
                if (!otherItem.IsDead  && Level == otherItem.Level) {
                    //обьеденить шары
                    CollapseManager.Instance.Collapse(this, otherItem);
                }
            }
        }
    }

    public void Disable() {
        _trigger.enabled = false;
        Rigidbody.isKinematic = true;
        _collider.enabled = false;
        IsDead = true;
    }

    public void Die() {
        Destroy(gameObject);
    }

    public virtual void DoEffect() {

    }
}
