using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PausePanel;
    void OnEnable()
    {
        Time.timeScale = 0f;
    }
    void OnDisable()
    {
        Time.timeScale = 1f;
    }
    public void YenidenOynaButonu()
    {
        PausePanel.SetActive(false);
        SceneManager.LoadScene("GameLevel");
    }
    public void MenuyeDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }
    public void OyundanCik()
    {
        Application.Quit();
    }
    public void PaneldenCikis()
    {
        PausePanel.SetActive(false);
    }
}
