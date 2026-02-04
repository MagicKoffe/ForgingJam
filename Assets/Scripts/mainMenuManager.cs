using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    public GameObject menuManager;
    bool optionsHidden;

    private void Start()
    {
        optionsHidden = true;
    }

    public void toggleOptions()
    {
        if (optionsHidden)
            optionsHidden = false;
        else
            optionsHidden = true;
    }

    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void Update()
    {
        menuManager.SetActive(!optionsHidden);
    }
}
