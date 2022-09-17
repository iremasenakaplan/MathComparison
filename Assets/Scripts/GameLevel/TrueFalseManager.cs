using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrueFalseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject trueIcon, falseIcon;


    void Start()
    {
        ScaleDegeriniKapat();
    }

    
    public void TrueFalseScaleAc(bool dogrumuYanlismi)
    {
        if (dogrumuYanlismi==true)
        {
            trueIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
            falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        }else
        {
            falseIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
            trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        }

       Invoke("ScaleDegeriniKapat", 0.4f); // true false iconlarının 0.4 sn sonra kapanması için
    }

    void ScaleDegeriniKapat()
    {
        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}
