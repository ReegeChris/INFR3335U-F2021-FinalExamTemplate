using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject cameraPrefab;

    public float minX, maxX;
    public float minZ, MaxZ;

    // Start is called before the first frame update
    void Start()
    {
        //Set the position of each player to be a random value using the Random.Range value
        //min and max values are set in the inspector before runtime to match the space of the scene
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 0f, Random.Range(minZ, MaxZ));

        //Player is instantiated as a temporary Gameobject
        GameObject temp = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);



        if (temp.GetComponent<PhotonView>().IsMine)
        {
            
            temp.GetComponent<PlayerMovement>().SetJoysticks(Instantiate(cameraPrefab, randomPosition, Quaternion.identity)); 

        }





    }




}