using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.currUser += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        GameManager.currUser -= 1;
    }
}
