using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region GameObjectTypeValues
    [SerializeField]
    private GameObject UstBilgiPaneli;
    [SerializeField]
    private GameObject PuanKapImage;
    [SerializeField]
    private GameObject BuyukSayiyiSecImage;
    [SerializeField]
    private GameObject UstKutu;
    [SerializeField]
    private GameObject AltKutu;
    [SerializeField]
    private GameObject PausePanel;
    [SerializeField]
    private GameObject SonucPaneli;
    [SerializeField]
    private Text UstKutuText;
    [SerializeField]
    private Text AltKutuText;
    [SerializeField]
    private Text PuanText;
    [SerializeField]
    private AudioClip BaslangicSesi, DogruSesi, YanlisSesi, BitisSesi;
    
    #endregion

    #region IntTypeValues
    int OyunIndeksi;
    private int OyunSayisi;
    int DegerUreteci;
    int UstKutuDegeri;
    int AltKutuDegeri;
    int BuyukDeger;
    int ButonDegeri;
    int ToplamPuan = 0;
    int PuanArtisMiktari = 0;
    int DogruSayisi, YanlisSayisi = 0;
    #endregion

    #region ClassValues
    SureSayimi SureSayimiObje;
    DaireManager DaireManagerObje;
    TrueFalseIcons TrueFalseIconsObje;
    SonucManager SonucManagerObje;
    AudioSource AudioSourceObje;
    #endregion
    void Awake()
    {
        SureSayimiObje = Object.FindObjectOfType<SureSayimi>();
        DaireManagerObje = Object.FindObjectOfType<DaireManager>();
        TrueFalseIconsObje = Object.FindObjectOfType<TrueFalseIcons>();
        AudioSourceObje = GetComponent<AudioSource>();
    }
    void Start()
    {
        PuanText.text = "0";
        UstKutuText.text = "";
        AltKutuText.text = "";
        ArayuzuGuncelle();
        PausePanel.SetActive(false);
    }
    void ArayuzuGuncelle()
    {
        UstBilgiPaneli.transform.GetComponent<CanvasGroup>().DOFade(1f, 1f);
        PuanKapImage.transform.GetComponent<CanvasGroup>().DOFade(1f, 1f);
        UstKutu.transform.GetComponent<RectTransform>().DOLocalMoveX(1f, 1f).SetEase(Ease.OutBack);
        AltKutu.transform.GetComponent<RectTransform>().DOLocalMoveX(1f, 1f).SetEase(Ease.OutBack);
    }
    public void OyunBaslasin()
    {
        PuanKapImage.transform.GetComponent<CanvasGroup>().DOFade(0f, 0.5f);
        BuyukSayiyiSecImage.transform.GetComponent<CanvasGroup>().DOFade(1f, 0.5f);
        SureSayimiObje.SureyiBaslat();
        KacinciOyun();
        AudioSourceObje.PlayOneShot(BaslangicSesi);
    }
    void KacinciOyun()
    {
        if (OyunSayisi < 5)
        {
            OyunIndeksi = 1;
            PuanArtisMiktari = 25;
        }
        else if (OyunSayisi >= 5 && OyunSayisi < 10)
        {
            OyunIndeksi = 2;
            PuanArtisMiktari = 50;
        }
        else if (OyunSayisi >= 10 && OyunSayisi < 15)
        {
            OyunIndeksi = 3;
            PuanArtisMiktari = 75;
        }
        else if (OyunSayisi >= 15 && OyunSayisi < 20)
        {
            OyunIndeksi = 4;
            PuanArtisMiktari = 100;
        }
        else if (OyunSayisi > 20 && OyunSayisi < 25)
        {
            OyunIndeksi = 5;
            PuanArtisMiktari = 125;
        }
        else
        {
            OyunIndeksi = Random.Range(1, 6);
            PuanArtisMiktari = 150;
        }
        switch (OyunIndeksi)
        {
            case 1:
                BirinciFonk();
                break;
            case 2:
                IkinciFonk();
                break;
            case 3:
                UcuncuFonk();
                break;
            case 4:
                DorduncuFonk();
                break;
            case 5:
                BesinciFonk();
                break;
        }
    }
    void BirinciFonk()
    {
        DegerUreteci = Random.Range(1, 50);
        if (DegerUreteci < 25)
        {
            UstKutuDegeri = Random.Range(1, 50);
            AltKutuDegeri = UstKutuDegeri + Random.Range(1, 10);
        }
        else
        {
            UstKutuDegeri = Random.Range(1, 50);
            AltKutuDegeri = Mathf.Abs(UstKutuDegeri - Random.Range(1, 10));
        }

        if (UstKutuDegeri > AltKutuDegeri)
        {
            BuyukDeger = UstKutuDegeri;
        }
        else if (AltKutuDegeri > UstKutuDegeri)
        {
            BuyukDeger = AltKutuDegeri;
        }
        else if (AltKutuDegeri == UstKutuDegeri)
        {
            BirinciFonk();
            return;
        }

        UstKutuText.text = UstKutuDegeri.ToString();
        AltKutuText.text = AltKutuDegeri.ToString();
    }
    void IkinciFonk()
    {
        int birinciDeger = Random.Range(1, 10);
        int ikinciDeger = Random.Range(1, 20);
        int ucuncuDeger = Random.Range(1, 10);
        int dorduncuDeger = Random.Range(1, 20);

        UstKutuDegeri = birinciDeger + ikinciDeger;
        AltKutuDegeri = ucuncuDeger + dorduncuDeger;

        UstKutuText.text = birinciDeger + "+" + ikinciDeger;
        AltKutuText.text = ucuncuDeger + "+" + dorduncuDeger;

        if (UstKutuDegeri > AltKutuDegeri)
        {
            BuyukDeger = UstKutuDegeri;
        }
        else if (AltKutuDegeri > UstKutuDegeri)
        {
            BuyukDeger = AltKutuDegeri;
        }
        else if (AltKutuDegeri == UstKutuDegeri)
        {
            IkinciFonk();
            return;
        }
    }
    void UcuncuFonk()
    {
        int birinciDeger = Random.Range(11, 30);
        int ikinciDeger = Random.Range(1, 11);
        int ucuncuDeger = Random.Range(11, 40);
        int dorduncuDeger = Random.Range(1, 11);

        UstKutuDegeri = birinciDeger - ikinciDeger;
        AltKutuDegeri = ucuncuDeger - dorduncuDeger;

        UstKutuText.text = birinciDeger + "-" + ikinciDeger;
        AltKutuText.text = ucuncuDeger + "-" + dorduncuDeger;

        if (UstKutuDegeri > AltKutuDegeri)
        {
            BuyukDeger = UstKutuDegeri;
        }
        else if (AltKutuDegeri > UstKutuDegeri)
        {
            BuyukDeger = AltKutuDegeri;
        }
        else if (AltKutuDegeri == UstKutuDegeri)
        {
            UcuncuFonk();
            return;
        }
    }
    void DorduncuFonk()
    {
        int birinciDeger = Random.Range(1, 10);
        int ikinciDeger = Random.Range(1, 10);
        int ucuncuDeger = Random.Range(1, 10);
        int dorduncuDeger = Random.Range(1, 10);

        UstKutuDegeri = birinciDeger * ikinciDeger;
        AltKutuDegeri = ucuncuDeger * dorduncuDeger;

        UstKutuText.text = birinciDeger + "*" + ikinciDeger;
        AltKutuText.text = ucuncuDeger + "*" + dorduncuDeger;

        if (UstKutuDegeri > AltKutuDegeri)
        {
            BuyukDeger = UstKutuDegeri;
        }
        else if (AltKutuDegeri > UstKutuDegeri)
        {
            BuyukDeger = AltKutuDegeri;
        }
        else if (AltKutuDegeri == UstKutuDegeri)
        {
            DorduncuFonk();
            return;
        }
    }
    void BesinciFonk()
    {
        int bolen1 = Random.Range(2, 10);
        UstKutuDegeri = Random.Range(2, 10);
        int bolunen1 = bolen1 * UstKutuDegeri;

        int bolen2 = Random.Range(2, 10);
        AltKutuDegeri = Random.Range(2, 10);
        int bolunen2 = bolen2 * AltKutuDegeri;

        UstKutuText.text = bolunen1 + "/" + bolen1;
        AltKutuText.text = bolunen2 + "/" + bolen2;

        if (UstKutuDegeri > AltKutuDegeri)
        {
            BuyukDeger = UstKutuDegeri;
        }
        else if (AltKutuDegeri > UstKutuDegeri)
        {
            BuyukDeger = AltKutuDegeri;
        }
        else if (AltKutuDegeri == UstKutuDegeri)
        {
            BesinciFonk();
            return;
        }
    }
    public void ButonDegeriniBelirle(string ButonAdi)
    {
        if (ButonAdi == "UstButon")
        {
            ButonDegeri = UstKutuDegeri;
        }
        else if (ButonAdi == "AltButon")
        {
            ButonDegeri = AltKutuDegeri;
        }
        if (ButonDegeri == BuyukDeger)
        {
            TrueFalseIconsObje.GetIcon(true);
            DaireManagerObje.DaireninGorunurlugunuAc(OyunSayisi % 5);

            if (OyunSayisi % 5 == 0)
            {
                DaireManagerObje.DaireninGorunurlugunuKapat();
            }
            OyunSayisi++;

            ToplamPuan += PuanArtisMiktari;
            PuanText.text = ToplamPuan.ToString();
            DogruSayisi++;
            AudioSourceObje.PlayOneShot(DogruSesi);
            KacinciOyun();
        }
        else
        {
            TrueFalseIconsObje.GetIcon(false);
            YanlisCevapDurumu();
            YanlisSayisi++;
            AudioSourceObje.PlayOneShot(YanlisSesi);
            KacinciOyun();
            DaireManagerObje.DaireninGorunurlugunuKapat();
        }
    }
    public void YanlisCevapDurumu()
    {
        OyunSayisi -= (OyunSayisi % 5 + 5);
        if (OyunSayisi < 0)
        {
            OyunSayisi = 0;
        }
    }
    public void PauseButon()
    {
        PausePanel.SetActive(true);
    }

    public void OyunBitti()
    {
        AudioSourceObje.PlayOneShot(BitisSesi);
        SonucPaneli.SetActive(true);
        SonucManagerObje = Object.FindObjectOfType<SonucManager>();
        SonucManagerObje.SonuclariGetir(DogruSayisi, YanlisSayisi, ToplamPuan);
    }
}
