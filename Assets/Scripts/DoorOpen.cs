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
        StartCoroutine(DoorOpening());
    }

    public IEnumerator DoorOpening()
    {
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            Door1.transform.Rotate(new Vector3(0f, Time.deltaTime * 100f, 0f));
            Door2.transform.Rotate(new Vector3(0f,-Time.deltaTime * 100f, 0f));
            yield return null;
        }
        transform.GetComponent<BoxCollider>().enabled = false;
    }
}
