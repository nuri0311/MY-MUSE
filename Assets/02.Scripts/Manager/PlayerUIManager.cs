using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;


public class PlayerUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panelTeacher;
    [SerializeField]
    private GameObject question1;
    [SerializeField]
    private GameObject question2;
    [SerializeField]
    private GameObject EndPanel;

    private bool lastButtonState = false;
    private bool lastButtonPressed = true;
    private List<InputDevice> devicesWithPrimaryButton;
    private Collider m_ObjectCollider1;
    private Collider m_ObjectCollider2;
    private Collider m_ObjectColliderEnd;

    private void Awake()
    {
        devicesWithPrimaryButton = new List<InputDevice>();
        m_ObjectCollider1 = GameObject.FindGameObjectWithTag("col1").GetComponent<Collider>();
        m_ObjectCollider2 = GameObject.FindGameObjectWithTag("col2").GetComponent<Collider>();
        m_ObjectColliderEnd = GameObject.FindGameObjectWithTag("colEnd").GetComponent<Collider>();
    }

    void OnEnable()
    {
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach (InputDevice device in allDevices)
            InputDevices_deviceConnected(device);

        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= InputDevices_deviceConnected;
        InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
        devicesWithPrimaryButton.Clear();
    }

    private void InputDevices_deviceConnected(InputDevice device)
    {
        bool discardedValue;
        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out discardedValue))
        {
            devicesWithPrimaryButton.Add(device); // Add any devices that have a primary button.
        }
    }

    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        if (devicesWithPrimaryButton.Contains(device))
            devicesWithPrimaryButton.Remove(device);
    }

    void Update()
    {
        bool tempState = false;
        foreach (var device in devicesWithPrimaryButton)
        {
            
            bool primaryButtonState = false;
            tempState = device.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonState) // did get a value
                        && primaryButtonState // the value we got
                        || tempState; // cumulative result from other controllers
        }

        if (tempState != lastButtonState) // Button state changed since last frame
        {
            if(tempState && GameManager.Instance.isTeacher)
            {
                panelTeacher.SetActive(lastButtonPressed);
                lastButtonPressed = !lastButtonPressed;
            }
            lastButtonState = tempState;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == m_ObjectCollider1)
        {
            question1.SetActive(true);
        }
        else if (other == m_ObjectCollider2)
        {
            question2.SetActive(true);
        }
        else if (other == m_ObjectColliderEnd)
        {
            EndPanel.SetActive(true);
        }
    }

}


    
