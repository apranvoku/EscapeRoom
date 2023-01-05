using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject Door1;
    public GameObject Door2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoors()
    {
        for(float i = 0; i < 1; i+=Time.deltaTime)
        {
            Door1.transform.Rotate(new Vector3(0f, i * 100f, 0f));
            Door2.transform.Rotate(new Vector3(0f, -i * 100f, 0f));
        }
        transform.GetComponent<BoxCollider>().enabled = false;
    }
}
