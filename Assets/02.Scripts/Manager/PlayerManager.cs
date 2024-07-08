using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;
using UnityEngine.InputSystem.XR;

public class PlayerManager : MonoBehaviour
{
    [Tooltip("The prefab to use for representing the player")]
    public GameObject playerPrefabTeacher;
    public GameObject playerPrefab1;
    public GameObject playerPrefab2;
    private PhotonView[] photonView;

   
    // Start is called before the first frame update
    void Start()
    {
        // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
        Debug.LogFormat("We are Instantiating LocalPlayer from {0}", Application.loadedLevelName);
        if(GameManager.Instance.isTeacher)
            PhotonNetwork.Instantiate(this.playerPrefabTeacher.name, new Vector3(0f, 0.4f, 1.5f), Quaternion.identity, 0);
        else if(Random.Range(0, 1) > 0.5)
        {
            PhotonNetwork.Instantiate(this.playerPrefab1.name, new Vector3(0f, 0.4f, 1.5f), Quaternion.identity, 0);
        }
        else
        {
            PhotonNetwork.Instantiate(this.playerPrefab2.name, new Vector3(0f, 0.4f, 1.5f), Quaternion.identity, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
