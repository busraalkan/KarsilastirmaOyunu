using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Transform Brain;
    [SerializeField]
    private Transform StartBtn;
    void Start()
    {
        Brain.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
        StartBtn.transform.GetComponent<RectTransform>().DOLocalMoveY(-220f, 1f).SetEase(Ease.OutBack);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("GameLevel");
    }
}

//public class A
//{
//    int toplam;
//    IIslem islem;
//    public A(B islem)
//    {
//        this.islem = islem;
//    }
//   public void Toplam()
//    {
//        //B bNesnesi = new B();
//        // toplam = bNesnesi.Topla();
//        islem.Topla();

//    }
//}

//public interface IIslem
//{
//    public int Topla();
//}
//public class B : IIslem
//{
   
//    public int Topla()
//    {
//        return 1 + 1;
//    }
//}

//public class C:IIslem
//{
//    public int Topla()
//    {
//        return 1 + 1;
//    }
//}
