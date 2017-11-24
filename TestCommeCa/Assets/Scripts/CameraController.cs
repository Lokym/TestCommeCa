using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public int speed;
    private LobbyManager LM;
	// Use this for initialization
	void Start () {

        LM = GameObject.FindObjectOfType<LobbyManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if(LM.PlayerNB < 2)
        {
            speed = 0;
        }
        else if (LM.PlayerNB >= 2)
        {
            speed = 3;
        }

        transform.Translate( new Vector2(1f, 0f) * speed * Time.deltaTime);
	}


}
