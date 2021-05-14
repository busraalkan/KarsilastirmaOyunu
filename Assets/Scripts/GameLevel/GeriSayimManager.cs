using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GeriSayimManager : MonoBehaviour
{
    [SerializeField]
    private GameObject GeriSayimImage;

    [SerializeField]
    private Text GeriSayimText;
    GameManager GameManagerObje;
    private void Awake()
    {
        GameManagerObje = Object.FindObjectOfType<GameManager>();
    }
    void Start()
    {
        StartCoroutine(UcIkiBirBaslatRoutine());   
    }
    IEnumerator UcIkiBirBaslatRoutine()
    {
        GeriSayimText.text = "3";
        GeriSayimImage.GetComponent<RectTransform>().DOScale(1f, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.4f);
        GeriSayimImage.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.4f);

        GeriSayimText.text = "2";
        GeriSayimImage.GetComponent<RectTransform>().DOScale(1f, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.4f);
        GeriSayimImage.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.4f);

        GeriSayimText.text = "1";
        GeriSayimImage.GetComponent<RectTransform>().DOScale(1f, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.4f);
        GeriSayimImage.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.4f);
        GameManagerObje.OyunBaslasin();
        StopAllCoroutines();
 
    }
}
