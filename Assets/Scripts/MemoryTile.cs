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

    public void OnPress()
    {
        memoryManager.GetComponent<MemoryManager>().SubmitPress(transform.GetSiblingIndex());
        StartCoroutine(BlueGlow());
    }

    public IEnumerator BlueGlow()
    {
        Color original = Color.white;
        for (float x = 0; x < 1; x += Time.deltaTime * 2)
        {
            transform.GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.blue, x);
            yield return null;
        }
        for (float x = 1; x > 0; x -= Time.deltaTime * 2)
        {
            transform.GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.blue, x);
            yield return null;
        }
    }
}
