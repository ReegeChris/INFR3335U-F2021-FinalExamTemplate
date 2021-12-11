using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //After the loading screen is finished, the photon network is created and we can join the lobby
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
         //Switch to the Lobby scene after succedfully joining a lobby on the network
        SceneManager.LoadScene("Lobby");

        //Set name of player to a "Player" with a random number ranging from 0 - 100
        PhotonNetwork.NickName = "Player " + Random.Range(0, 100).ToString("000"); //*
    }
}
