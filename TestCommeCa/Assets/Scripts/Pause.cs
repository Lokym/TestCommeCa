using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public GameObject PauseUI;

    private void Start()
    {
        PauseUI.SetActive(false);
    }

    public  void pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1;
    }




    public void Menu()
    {
        Time.timeScale = 1;
        PauseUI.SetActive(false);
        Destroy(GameObject.Find("NetworkManager"));
        Destroy(GameObject.Find("Manager"));
        Destroy(GameObject.Find("Canvas (2)"));
        SceneManager.LoadScene("ChoixMenu");
    }
}
