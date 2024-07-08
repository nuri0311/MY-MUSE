using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
    public void MoveToPond()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach(var player in players)
        {
            //이게 창고로감
            player.gameObject.transform.position = new Vector3(0.0f, 0.5f, 56.0f);
        }
    }

    public void MoveToHome()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            //이게 연못으로감
            player.gameObject.transform.position = new Vector3(100.0f, 9.5f, 100.0f);
        }
    }

    public void MoveToGarage()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            //이게 마지막방으로감
            player.gameObject.transform.position = new Vector3(-25.15f, 1.0f, 59.0f);
        }
    }

}
