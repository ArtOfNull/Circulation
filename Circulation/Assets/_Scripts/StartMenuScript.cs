using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    public GameObject selectLevelPan;
    public GameObject creditPan;

    public void StartGame()
    {
        SceneManager.LoadScene("Level0");
    }

    public void SelectLevel()
    {
        selectLevelPan.SetActive(true);
    }

    public void Credits()
    {
        creditPan.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
