using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeControl : MonoBehaviour
{
    public GameObject Maze;
    public GameObject Ball;
    // Start is called before the first frame update
    void Start()
    {
        Maze = GameObject.Find("Maze");
        Ball = GameObject.Find("MazeBall");
        Ball.GetComponent<Rigidbody>().sleepThreshold = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPress()
    {
        if(transform.gameObject.name == "Up")
        {
            Maze.transform.Rotate(new Vector3(0f, 0f, -3f * Time.deltaTime));
        }
        if (transform.gameObject.name == "Right")
        {
            Maze.transform.Rotate(new Vector3(-3f*Time.deltaTime, 0f, 0f));
        }
        if (transform.gameObject.name == "Down")
        {
            Maze.transform.Rotate(new Vector3(0f, 0f, 3f*Time.deltaTime));
        }
        if (transform.gameObject.name == "Left")
        {
            Maze.transform.Rotate(new Vector3(3f*Time.deltaTime, 0f, 0f));
        }
    }
}
