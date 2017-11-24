using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Networking;

public class MainMenu : MonoBehaviour {

    public bool isMulti = false;
    public bool isSolo = false;
    public GameObject CanvasClass;
    public GameObject MultiManager;
    public GameObject CanvasMenu;
    private ClassChoose choose;
    

    private void Start()
    {
        choose = GetComponent<ClassChoose>();
        CanvasMenu.SetActive(true);
        CanvasClass.SetActive(false);
        MultiManager.GetComponent<NetworkManagerHUD>().enabled = false;
 
    }

    public void Solo()
    {
        isSolo = true;
        CanvasMenu.SetActive(false);
        CanvasClass.SetActive(true);
      

    }

    public void Multi()
    {
        isMulti = true;
        choose.classnumber = 1;
        CanvasMenu.SetActive(false);
        CanvasClass.SetActive(true);
        MultiManager.GetComponent<NetworkManagerHUD>().enabled = true;

    }
}
