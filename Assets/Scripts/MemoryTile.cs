using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryTile : MonoBehaviour
{
    public GameObject memoryManager;
    // Start is called before the first frame update
    void Start()
    {
        memoryManager = GameObject.Find("MemoryPuzzle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        OnPress();
    }
    public void OnPress()
    {
        memoryManager.GetComponent<MemoryManager>().SubmitPress(transform.GetSiblingIndex());
    }


}
