using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Text DogruSayisiText, YanlisSayisiText, SonucPuanText;
    int ArtisMiktari, ToplamPuan, HesaplananPuan;
    int AdimSayisi = 10;
    bool AdimSayisiState = true;
    public void SonuclariGetir(int dogruAdet, int yanlisAdet, int Puan)
    {
        DogruSayisiText.text = dogruAdet.ToString();
        YanlisSayisiText.text = yanlisAdet.ToString();

        ToplamPuan = Puan;
        ArtisMiktari = ToplamPuan / AdimSayisi;
        StartCoroutine(PuanYazdirma());
    }
    IEnumerator PuanYazdirma()
    {
        while (AdimSayisiState)
        {
            HesaplananPuan += ArtisMiktari;
            yield return new WaitForSeconds(0.2f);

            if (HesaplananPuan >= ToplamPuan)
            {
                HesaplananPuan = ToplamPuan;
            }
            SonucPuanText.text = HesaplananPuan.ToString();

            if (AdimSayisi == 0)
            {
                AdimSayisiState = false;
            }
        }
    }
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }
    public void YenidenOyna()
    {
        SceneManager.LoadScene("GameLevel");
    }
}