using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePaneli;

    [SerializeField]
    private GameObject PuanSurePaneli;

    [SerializeField]
    private GameObject ustDikdortgen, altDikdortgen;

    [SerializeField]
    private Text ustText, altText, puanText;

    TimerManager timerManager;
    DairelerManager dairelerManager;
    TrueFalseManager trueFalseManager;

    int oyunSayac, kacinciOyun;
    int ustDeger, altDeger;
    int buyukDeger;
    int butonDegeri;
    int toplamPuan, artisPuan;

    private void Awake()
    {
       timerManager= Object.FindObjectOfType<TimerManager>();
       dairelerManager=Object.FindObjectOfType<DairelerManager>();
       trueFalseManager=Object.FindObjectOfType<TrueFalseManager>();
    }

    void Start()
    {   
        kacinciOyun=0;
        oyunSayac=0;

        ustText.text ="";
        altText.text ="";

        puanText.text="0";
        toplamPuan =0;

        SahneEkraniniGuncelle();
    }

    void SahneEkraniniGuncelle()
    {
        PuanSurePaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        ustDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0, 1f).SetEase(Ease.OutBack);
        altDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0, 1f).SetEase(Ease.OutBack);
    }
    
    public void OyunaBasla()
    {
        timerManager.sureyiBaslat();
        KacinciOyun();
    }
    

    void KacinciOyun()
    {
       if (oyunSayac<5)
       {
          kacinciOyun=1;
          artisPuan = 10;

       }else if(oyunSayac>=5 && oyunSayac<10)
       {
          kacinciOyun=2;
          artisPuan = 15;

       }else if(oyunSayac>=10 && oyunSayac<15)
       {
          kacinciOyun=3;
          artisPuan = 20;

       }else if(oyunSayac>=15 && oyunSayac<20)
       {
          kacinciOyun=4;
          artisPuan = 25;

       }else if(oyunSayac>=20 && oyunSayac<25)
       {
          kacinciOyun=5;
          artisPuan = 30;
       }else
       {
          kacinciOyun = Random.Range(1,6);
          artisPuan = 35;
       }

       switch (kacinciOyun)
       {
           case 1:
           BirinciFonksiyon();
           break;

           case 2:
           IkinciFonksiyon();
           break;

            case 3:
           UcuncuFonksiyon();
           break;

           case 4:
           DorduncuFonksiyon();
           break;

            case 5:
           BesinciFonksiyon();
           break;
       }
    }
    
    void BirinciFonksiyon()
    {
        int rastgeleDeger=Random.Range(1,50);

        if (rastgeleDeger<=25)
        {
            ustDeger=Random.Range(2,50);
            altDeger=Mathf.Abs(ustDeger+Random.Range(1,15));

        }else
        {
            ustDeger=Random.Range(2,50);
            altDeger=ustDeger-Random.Range(1,15);
        }
        
        if (ustDeger>altDeger)
        {
            buyukDeger=ustDeger;

        }else if(ustDeger<altDeger)
        {
            buyukDeger=altDeger;
        }

        if(ustDeger==altDeger)
        {
         BirinciFonksiyon();
         return;
        }

         ustText.text=ustDeger.ToString();
         altText.text=altDeger.ToString();

          Debug.Log(" buyuk deger " + buyukDeger);
    }

    void IkinciFonksiyon()
    {
       int birinciSayi = Random.Range(1,10);
       int ikinciSayi = Random.Range(1,20);

       int ucuncuSayi = Random.Range(1,10);
       int dorduncuSayi = Random.Range(1,20);

       ustDeger = birinciSayi + ikinciSayi;
       altDeger = ucuncuSayi + dorduncuSayi;

       if (ustDeger>altDeger)
       {
          buyukDeger = ustDeger;

       }else if(ustDeger<altDeger)
       {
          buyukDeger = altDeger;
       }

       if(ustDeger==altDeger)
       {
          IkinciFonksiyon();
          return;
       }

        ustText.text = birinciSayi + "+" + ikinciSayi;
        altText.text = ucuncuSayi + "+" + dorduncuSayi;

    }

    void UcuncuFonksiyon()
    {
       int birinciSayi = Random.Range(11,30);
       int ikinciSayi = Random.Range(1,11);

       int ucuncuSayi = Random.Range(11,40);
       int dorduncuSayi = Random.Range(1,11);

       ustDeger = birinciSayi - ikinciSayi;
       altDeger = ucuncuSayi - dorduncuSayi;

       if (ustDeger>altDeger)
       {
          buyukDeger = ustDeger;

       }else if(ustDeger<altDeger)
       {
          buyukDeger = altDeger;
       }

       if(ustDeger==altDeger)
       {
          UcuncuFonksiyon();
          return;
       }

        ustText.text = birinciSayi + "-" + ikinciSayi;
        altText.text = ucuncuSayi + "-" + dorduncuSayi;
    }

    void DorduncuFonksiyon()
    {
        int birinciSayi = Random.Range(1,10);
       int ikinciSayi = Random.Range(1,10);

       int ucuncuSayi = Random.Range(1,10);
       int dorduncuSayi = Random.Range(1,10);

       ustDeger = birinciSayi * ikinciSayi;
       altDeger = ucuncuSayi * dorduncuSayi;

       if (ustDeger>altDeger)
       {
          buyukDeger = ustDeger;

       }else if(ustDeger<altDeger)
       {
          buyukDeger = altDeger;
       }

       if(ustDeger==altDeger)
       {
          DorduncuFonksiyon();
          return;
       }

        ustText.text = birinciSayi + "x" + ikinciSayi;
        altText.text = ucuncuSayi + "x" + dorduncuSayi;
    }

    void BesinciFonksiyon()
    {
       int birinciSayi = Random.Range(1,10);
       int ikinciSayi = Random.Range(1,10);

       int ucuncuSayi = Random.Range(1,10);
       int dorduncuSayi = Random.Range(1,10);

       ustDeger = birinciSayi / ikinciSayi;
       altDeger = ucuncuSayi / dorduncuSayi;

       if (ustDeger>altDeger)
       {
          buyukDeger = ustDeger;

       }else if(ustDeger<altDeger)
       {
          buyukDeger = altDeger;
       }

       if(ustDeger==altDeger)
       {
          BesinciFonksiyon();
          return;
       }

        ustText.text = birinciSayi + "/" + ikinciSayi;
        altText.text = ucuncuSayi + "/" + dorduncuSayi;
    }

    public void ButonDegeriniBelirle(string butonAdi)
    {
        if (butonAdi=="ustButon")
        {
            butonDegeri = ustDeger;

        }else if (butonAdi =="altButon")
        {
            butonDegeri = altDeger;
        }

        if (butonDegeri==buyukDeger)
        {
            trueFalseManager.TrueFalseScaleAc(true);

            dairelerManager.DairelerinScaleAc(oyunSayac%5);
            oyunSayac++;

            toplamPuan+=artisPuan;
            puanText.text=toplamPuan.ToString();

            KacinciOyun(); // ekrana yeni soru gelmesi icin

        }else
        {
            trueFalseManager.TrueFalseScaleAc(false);

            HatayaGöreSayaciAzalt();
            KacinciOyun();
        }
    }

   void HatayaGöreSayaciAzalt()
   {
      oyunSayac-=(oyunSayac%5+5);
      
      if(oyunSayac<0)
      {
         oyunSayac =0;
      }
   
      dairelerManager.DairelerinScaleKapat();

   }

   public void PausePaneliniAc()
   {
      pausePaneli.SetActive(true);
   }

 }
