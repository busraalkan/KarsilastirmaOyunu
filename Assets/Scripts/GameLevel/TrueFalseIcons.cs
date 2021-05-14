using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TrueFalseIcons : MonoBehaviour
{
    [SerializeField]
    private GameObject TrueIcon;
    [SerializeField]
    private GameObject FalseIcon;
    void Start()
    {
        IconsOff();
    }
    public void GetIcon(bool State)
    {
        if (State)
        {
            TrueIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
            FalseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        else if (!State)
        {
            FalseIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
            TrueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        Invoke("IconsOff", 0.5f);
    }
    void IconsOff()
    {
        TrueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        FalseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}
