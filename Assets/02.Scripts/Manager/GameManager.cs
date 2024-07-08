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

    //�����ϱ� ���� ������Ƽ
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    // GameManager ���� ��� �ϴ� ������
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
        // Scene�� �̹� �ν��Ͻ��� ���� �ϴ���
        if (instance)
        {
            Destroy(this.gameObject);
            return;
        }


        // instance�� ���� ������Ʈ�� �����
        instance = this;
        // Scene �̵� �� ���� ���� �ʵ��� ó��
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        currState = State.beforeLoad;
        currUser = 0;
    }
}

