using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DaireManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] DairelerDizisi = new GameObject[5];
    void Start()
    {
        DaireninGorunurlugunuKapat();
    }
    public void DaireninGorunurlugunuKapat()
    {
        foreach (GameObject daire in DairelerDizisi)
        {
            daire.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }
    public void DaireninGorunurlugunuAc(int DaireIndis)
    {
         DairelerDizisi[DaireIndis].GetComponent<RectTransform>().DOScale(1f, 0.5f);
    } 
}
