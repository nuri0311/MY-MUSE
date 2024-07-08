using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Com.Mymuse
{
    public class PlayerAnimatorManager : MonoBehaviour
    {
        private  Transform transform;

        #region MonoBehaviour Callbacks


        // Use this for initialization
        void Start()
        {
            transform = GetComponent<Transform>();
        }


        // Update is called once per frame
        void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            transform.position += new Vector3(h, 0, v)*Time.deltaTime*5;
        }


        #endregion
    }
}