using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;



public class MyMenu : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _coinsText;
    [SerializeField] private TMPro.TMP_Text _levelText;
    [SerializeField] private Image _backgroundImage;

    public  Button _startButton;


    private void Start() {
        _coinsText.text = Progress.Instance.Coins.ToString();
        _levelText.text = "Level" + Progress.Instance.Level.ToString();

        _backgroundImage.color = Progress.Instance.BackgroundColor;

        _startButton.onClick.AddListener(StartLevel);
    }

    void StartLevel() {
        SceneManager.LoadScene(Progress.Instance.Level);
    }

   
}
