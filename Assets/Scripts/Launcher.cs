using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks
{

    public GameObject lobbyPanel; //*    
    public GameObject roomPanel; //*

    public InputField createInput;
    public InputField joinInput;

    public Text roomName;
    public Text playerCount;

    public GameObject playerListing; //*    
    public Transform playerListContent; //*

    public Button startButton; //*   
    public Button joinButton;


    public void Start()
    {
        lobbyPanel.SetActive(true); //*       
        roomPanel.SetActive(false); //*       
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(createInput.text))
            return;
        PhotonNetwork.CreateRoom(createInput.text);

    }


    public void JoinRoom()
    {

        PhotonNetwork.JoinRoom(joinInput.text);

        Debug.Log(".." + joinInput.text + "..");

        joinButton.interactable = false;

    }

    public override void OnJoinedRoom()
    {


        lobbyPanel.SetActive(false); 
        roomPanel.SetActive(true); 

        Debug.Log(" On Joined Room Function was called");

        //Set text of room name  to be what the user input in the text field
        roomName.text = PhotonNetwork.CurrentRoom.Name;

        //List of players grabbed from PhotonNetwork.playerlist
        Player[] players = PhotonNetwork.PlayerList;

        playerCount.text = "" + players.Length;

        //For loop runs through every single element in the players list
        for (int i = 0; i < players.Length; i++)
        {

            Instantiate(playerListing, playerListContent).GetComponent<PlayerListing>().SetPlayerInfo(players[i]);

            if (i == 0)
            {
                startButton.interactable = true;
            }

            else
            {
                startButton.interactable = false;   
            }
        }


    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {

        Debug.Log("Error creating room! " + message);

    }

    //Leave room function is called 
    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    //After leaving the room, the player returns to the loading scene
    public override void OnLeftRoom()  
    {
        SceneManager.LoadScene("Loading");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) 
    {
        Instantiate(playerListing, playerListContent).GetComponent<PlayerListing>().SetPlayerInfo(newPlayer);
    }
    
    
    //After pressing the start button, scene is switched to the Arena
    public void OnClickStartGame()   
    {
        PhotonNetwork.LoadLevel("Arena");
    }

}










