using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

public class LobbyManager : NetworkManager {

    [Header("Selection des personnages")]
    [Space(10)]
    public Button player1Button;
    public Button player2Button;
    public Button player3Button;

    [Space(10)]
    //public GameObject PannelPerso;
    public MainMenu Menu;
    public int PlayerNB = 0;

    public int avatarIndex = 0;

    void Start()
    {
        player1Button.onClick.AddListener(delegate { AvatarPicker(player1Button.name); });
        player2Button.onClick.AddListener(delegate { AvatarPicker(player2Button.name); });
        player3Button.onClick.AddListener(delegate { AvatarPicker(player3Button.name); });
      

    }

    void AvatarPicker(string buttonName)
    {
        switch (buttonName)
        {
            case "Archer 1":
                avatarIndex = 0;
                break;
            case "Wizard 1":
                avatarIndex = 1;
                break;
            case "Rifleman 1":
                avatarIndex = 2;
                break;
            //default:
            //    Debug.Log("Lol");
            //    break;
        }

        playerPrefab = spawnPrefabs[avatarIndex];
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        //PannelPerso.SetActive(false);
        IntegerMessage msg = new IntegerMessage(avatarIndex);

        if (!clientLoadedScene)
        {
            ClientScene.Ready(conn);
            if (autoCreatePlayer)
            {
                ClientScene.AddPlayer(conn, 0, msg);
            }
        }
    }

    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        base.OnServerDisconnect(conn);
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    {
        int id = 0;
        Debug.Log("Spawn");
        if (extraMessageReader != null)
        {
            IntegerMessage i = extraMessageReader.ReadMessage<IntegerMessage>();
            id = i.value;
        }

        GameObject playerPrefab = spawnPrefabs[id];

        GameObject player;
        Transform startPos = GetStartPosition();
        if (startPos != null)
        {
            player = (GameObject)Instantiate(playerPrefab, startPos.position, startPos.rotation);
            PlayerNB++;
        }
        else
        {
           
            player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }

        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);

        if(Menu.isSolo)
        {
            GameObject player1;
            Transform startPos1 = GetStartPosition();
            if (startPos != null)
            {
                player1 = (GameObject)Instantiate(playerPrefab, startPos1.position, startPos1.rotation);
            }
            else
            {

                player1 = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            }

            NetworkServer.AddPlayerForConnection(conn, player1, playerControllerId);
        }
        
    }
}



