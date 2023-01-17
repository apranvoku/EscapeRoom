using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portrait : MonoBehaviour
{
    public GameObject Room2Door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        OnClick();
    }
    public void OnClick()
    {
        StartCoroutine(RotatePortrait());
    }

    public IEnumerator RotatePortrait()
    {
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            transform.Rotate(new Vector3(0f, 0, Time.deltaTime * 180f));
            yield return null;
        }
        transform.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(OpenRoom2Door());
    }

    public IEnumerator OpenRoom2Door()
    {
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            Room2Door.transform.Rotate(new Vector3(0f, -Time.deltaTime * 100f, 0f));
            yield return null;
        }
    }
}
