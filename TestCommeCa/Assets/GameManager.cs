using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public ClassChoose CC;
    public GameObject Archer;
    public GameObject Mage;
    public GameObject Rifleman;

    public GameObject Spawn;
    public GameObject Spawn2;
    private Life life;


    void Start()
    {
        CC = GameObject.FindObjectOfType<ClassChoose>();
        life = GameObject.FindObjectOfType<Life>();

       
        if (CC.isArcherPlayer)
        {
            Instantiate(Archer, Spawn.transform.position, Quaternion.identity);
        }
        if (CC.isArcherPlayer2)
        {
            Instantiate(Archer, Spawn2.transform.position, Quaternion.identity);
        }

        if (CC.isMagePlayer)
        {
            Instantiate(Mage, Spawn.transform.position, Quaternion.identity);
        }
        if (CC.isMagePlayer2)
        {
            Instantiate(Mage, Spawn2.transform.position, Quaternion.identity);
        }

        if (CC.isRiflemanPlayer)
        {
            Instantiate(Rifleman, Spawn.transform.position, Quaternion.identity);
        }
        if (CC.isRiflemanPlayer2)
        {
            Instantiate(Rifleman, Spawn2.transform.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        if (life.LifeNb <= 0)
        {
            SceneManager.LoadScene("SceneTuto");
        }
    }
}
