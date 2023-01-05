using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maze_movement : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Sphere");
        ball.GetComponent<Rigidbody>().sleepThreshold = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        //Debug.Log(horizontal + ":" + vertical);
        //transform.Rotate(-vertical*0.3f, 0, horizontal*0.3f);
    }
}
