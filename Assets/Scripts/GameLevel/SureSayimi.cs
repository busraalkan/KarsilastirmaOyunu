using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SureSayimi : MonoBehaviour
{
    [SerializeField]
    private Text SureText;
    int KalanSure;
    GameManager GameManagerObje;
    void Start()
    {
        GameManagerObje = Object.FindObjectOfType<GameManager>();
        KalanSure = 20;
    }
    public void SureyiBaslat()
    {
        StartCoroutine(SureBaslasinRoutine());
    }
    IEnumerator SureBaslasinRoutine()
    {
        while (true)
        {
            if (KalanSure < 10)
            {
                SureText.text = "0" + KalanSure.ToString();
                if (KalanSure == 0)
                {
                    SureText.text = " ";
                    GameManagerObje.OyunBitti();
                    StopAllCoroutines();
                }
            }
            else
            {
                SureText.text = KalanSure.ToString();
            }
            yield return new WaitForSeconds(1f);
            KalanSure--;
        }
    }
}
