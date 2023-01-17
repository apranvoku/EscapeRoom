using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class PadButton : MonoBehaviour
{
    public GameObject StairwayDoor;
    public GameObject EntryField;
    public TMP_InputField InputField;
    // Start is called before the first frame update
    void Start()
    {
        StairwayDoor = GameObject.Find("StairwayDoor");
        EntryField = GameObject.Find("InputField");
        InputField = EntryField.GetComponent<TMP_InputField>();
        InputField.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        OnPress();
        //Debug.Log("I've been pressed, tee hee!");
    }
    public void OnPress()
    {
        if (transform.GetSiblingIndex() >= 0 && transform.GetSiblingIndex() <= 9)
        {
            InputField.text += transform.GetSiblingIndex().ToString();
        }
        else if(transform.GetSiblingIndex() == 10)
        {
            if(InputField.text == "4236")
            {
                Debug.Log("Correct Keycode");
                StartCoroutine(OpenStairWaydoor());
            }
            //Confirm()
        }
        else if (transform.GetSiblingIndex() == 11)
        {
            InputField.text = "";
        }
    }

    public IEnumerator OpenStairWaydoor()
    {
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            StairwayDoor.transform.Rotate(new Vector3(0f, -Time.deltaTime * 100f, 0f));
            yield return null;
        }
    }
}
