using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_basic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward*0.01f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * 0.01f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * 0.01f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * 0.01f;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0f, -1f, 0f)); 
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0f, 1f, 0f));
        }
    }
}
