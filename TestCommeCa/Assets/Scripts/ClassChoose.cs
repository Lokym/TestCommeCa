using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ClassChoose : MonoBehaviour {

    public MainMenu menu;
    public int classnumber = 0;
    public bool isArcherPlayer;
    public bool isMagePlayer;
    public bool isRiflemanPlayer;
    public bool isArcherPlayer2;
    public bool isMagePlayer2;
    public bool isRiflemanPlayer2;
    public int NumberPlayers = 0;
    public bool CanPlay = false;
    private LobbyManager LM;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        LM = GameObject.FindObjectOfType<LobbyManager>();
        LM.avatarIndex = 0;

    }

    private void Update()
    {
        if(classnumber == 2)
        {
            CanPlay = true;
        }

        
            if (CanPlay && menu.isSolo)
            {
                 classnumber++;
            CanPlay = false;
           
            SceneManager.LoadScene("SceneTuto");

            }

            else if (CanPlay && menu.isMulti)
            {
            classnumber++;
            CanPlay = false;
           
            SceneManager.LoadScene("SceneMulti");

           
        }
        
       
      
    }

    public void Archer()
    {
        classnumber++;
        if(menu.isSolo && NumberPlayers == 0)
        {
            
            isArcherPlayer = true;
            NumberPlayers++;
        }
        else if (menu.isSolo && NumberPlayers >= 1)
        {
            
                isArcherPlayer2 = true;
            NumberPlayers++;
        }

    }

    public void Mage()
    {
        classnumber++;

        if (menu.isSolo && NumberPlayers == 0)
        {

            isMagePlayer = true;
            NumberPlayers++;
        }
        else if (menu.isSolo && NumberPlayers >= 1)
        {

            isMagePlayer2 = true;
            NumberPlayers++;
        }

     
    }

    public void Rifleman()
    {

     
        classnumber++;

        if (menu.isSolo && NumberPlayers == 0)
        {

            isRiflemanPlayer = true;
            NumberPlayers++;
        }
        else if (menu.isSolo && NumberPlayers >= 1)
        {

            isRiflemanPlayer2 = true;
            NumberPlayers++;
        }


    }
}
