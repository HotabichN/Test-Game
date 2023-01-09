using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ScoreElementBall : ScoreElement
{
    [SerializeField] private  TMPro.TMP_Text _leveltext;
    [SerializeField] private RawImage _ballImage;
    [SerializeField] private BallSettings _ballSettings;


    public override void Setup(Task task) {
        base.Setup(task);

        int number = (int)Mathf.Pow(2, task.Level + 1);
        _leveltext.text = number.ToString();
        _ballImage.color = _ballSettings.BallMaterials[task.Level].color;

        Level = task.Level;
    }
}
