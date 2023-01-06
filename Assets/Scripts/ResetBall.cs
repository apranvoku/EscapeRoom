using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    GameObject MazeBall;
    Vector3 InitialPos;
    // Start is called before the first frame update
    void Start()
    {
        MazeBall = GameObject.Find("MazeBall");
        InitialPos = MazeBall.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPress()
    {
        MazeBall.transform.position = InitialPos;
    }
}
