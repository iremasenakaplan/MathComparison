using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GeriSayimManager : MonoBehaviour
{
    [SerializeField]
    private GameObject GeriSayimObje;

    [SerializeField]
    private Text gerisayimText;

    GameManager gameManager; // script için yer ayırdık

    private void Awake()
    {
        gameManager= Object.FindObjectOfType<GameManager>(); // gamemanagerdaki tüm fonks. ulaşılabilir
    }

    void Start()
    {
        StartCoroutine(GeriyeSayRoutine());
    }

    IEnumerator GeriyeSayRoutine()
    {
      gerisayimText.text="3";
      yield return new WaitForSeconds(0.5f); // yarım saniye geçmesini istiyoruz

      GeriSayimObje.GetComponent<RectTransform>().DOScale(1,0.5f).SetEase(Ease.OutBack);
      yield return new WaitForSeconds(1f);
      GeriSayimObje.GetComponent<RectTransform>().DOScale(0,0.5f).SetEase(Ease.InBack);
      yield return new WaitForSeconds(0.6f);

      gerisayimText.text="2";
      yield return new WaitForSeconds(0.5f); // yarım saniye geçmesini istiyoruz

      GeriSayimObje.GetComponent<RectTransform>().DOScale(1,0.5f).SetEase(Ease.OutBack);
      yield return new WaitForSeconds(1f);
      GeriSayimObje.GetComponent<RectTransform>().DOScale(0,0.5f).SetEase(Ease.InBack);
      yield return new WaitForSeconds(0.6f);

      gerisayimText.text="1";
      yield return new WaitForSeconds(0.5f); // yarım saniye geçmesini istiyoruz

      GeriSayimObje.GetComponent<RectTransform>().DOScale(1,0.5f).SetEase(Ease.OutBack);
      yield return new WaitForSeconds(1f);
      GeriSayimObje.GetComponent<RectTransform>().DOScale(0,0.5f).SetEase(Ease.InBack);
      yield return new WaitForSeconds(0.6f);

      StopAllCoroutines();

      Debug.Log("Oyun basladı");

      gameManager.OyunaBasla();
      
    }
    
}
