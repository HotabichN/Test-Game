using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Projection : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private TMPro.TMP_Text _text;
    [SerializeField] private Transform _visualTransform;
    public Rigidbody Rigidbody;

    public void Setup(Material material, string numberText, float radius) {
        _renderer.material = material;
        _text.text = numberText;
        _visualTransform.localScale = Vector3.one * radius * 2f; 
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    public void SetPosition(Vector3 position) {
        transform.position = position;
    }
}
