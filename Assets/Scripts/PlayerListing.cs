using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    public Text playerName;

    //Player element created from Photon.Realtime namespace
    private Player player;

    //Function to set the information of each player upon entering the room
    public void SetPlayerInfo(Player _player)
    {
        player = _player;
        playerName.text = _player.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (player == otherPlayer)
        {
            Destroy(gameObject);
        }

    }

    public override void OnLeftRoom()
    {
        //After leaving the room the player listeing prefab is destroyed
        Destroy(gameObject);
    }

}
