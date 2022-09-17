using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 
using UnityEngine.SceneManagement; // sahneler arası geçiş için

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Transform head;

    [SerializeField]
    private Transform startButton;

    void Start()
    {
       head.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack); //kafanın RectTransform componentine ulaş ve onu loval olarak hareket ettir
       startButton.transform.GetComponent<RectTransform>().DOLocalMoveY(-779f, 1f).SetEase(Ease.OutBack);
    }

    public void OyunaBasla()
    {
       SceneManager.LoadScene("GameLevel");
    }
}
