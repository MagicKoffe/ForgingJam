using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    public GameObject tutorialPage1;
    public GameObject tutorialPage2;
    public GameObject tutorialPage3;
    bool optionsHidden;

    private void Start()
    {
        tutorialPage1.SetActive(false);
        tutorialPage2.SetActive(false);
        tutorialPage3.SetActive(false);
    }


    public void page1()
    {
        tutorialPage1.SetActive(true);
        tutorialPage2.SetActive(false);
        tutorialPage3.SetActive(false);
    }

    public void page2()
    {
        tutorialPage1.SetActive(false);
        tutorialPage2.SetActive(true);
        tutorialPage3.SetActive(false);
    }

    public void page3()
    {
        tutorialPage1.SetActive(false);
        tutorialPage2.SetActive(false);
        tutorialPage3.SetActive(true);
    }

    public void closeTut()
    {
        tutorialPage1.SetActive(false);
        tutorialPage2.SetActive(false);
        tutorialPage3.SetActive(false);
    }

    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }

 
}
