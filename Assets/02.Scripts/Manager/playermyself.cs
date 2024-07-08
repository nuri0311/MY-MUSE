using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit.Examples;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.InputSystem.XR;
using Unity.XR.CoreUtils;

public class playermyself : MonoBehaviour
{
    private PhotonView view;

    [SerializeField]
    private XRBaseController leftcontroller;
    [SerializeField]
    private XRBaseController rightcontroller;
    [SerializeField]
    private PhotonView selfview;
    [SerializeField]
    private AudioListener listenAudio;
    [SerializeField]
    private LocomotionSystem locomotion;
    [SerializeField]
    private DeviceBasedSnapTurnProvider snapturn;
    [SerializeField]
    private DeviceBasedContinuousMoveProvider move;

    [SerializeField]
    private Camera theCamera;
    // Start is called before the first frame update
    void Start()
    {
        if (!selfview.IsMine)
        {
            leftcontroller.enabled = false;
            rightcontroller.enabled = false;
            listenAudio.enabled = false;
            locomotion.enabled = false;
            snapturn.enabled = false;  
            move.enabled = false;
            theCamera.enabled = false;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
     
    }
}
