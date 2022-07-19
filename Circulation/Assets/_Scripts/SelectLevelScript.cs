using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelScript : MonoBehaviour
{
    public GameObject panel;


    private void Start()
    {
        panel = gameObject;
    }
    public void SelectLevel(int i)
    {
        SceneManager.LoadScene("Level" + i.ToString());
    }

    public void ReturnToMenu()
    {
        panel.SetActive(false);
    }
}
