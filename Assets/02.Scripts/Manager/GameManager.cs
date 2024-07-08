using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviour
{
    //  Singleton Instance
    private static GameManager instance = null;
    public enum State { beforeLoad, onLoad, inTeaching, inPlayingFirst, inPlayingSecond };
    [HideInInspector]
    public static State currState;
    public static uint currUser;

    //접근하기 위한 프로퍼티
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    // GameManager 에서 사용 하는 데이터
    public bool isTeacher = true;
    public string myName = "";

    #region Photon Callbacks


    /// <summary>
    /// Called when the local player left the room. We need to load the launcher scene.
    /// </summary>
    public void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }


    #endregion
    #region Public Methods


    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }


    #endregion

    void Awake()
    {
        // Scene에 이미 인스턴스가 존재 하는지
        if (instance)
        {
            Destroy(this.gameObject);
            return;
        }


        // instance를 유일 오브젝트로 만든다
        instance = this;
        // Scene 이동 시 삭제 되지 않도록 처리
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        currState = State.beforeLoad;
        currUser = 0;
    }
}

