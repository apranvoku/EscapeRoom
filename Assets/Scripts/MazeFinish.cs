using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MazeFinish : MonoBehaviour
{
    public GameObject Floor;
    public TMP_Text text;
    public Image bg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider Other)
    {
        Debug.Log("Success!");
        Floor.GetComponent<BoxCollider>().enabled = false;
        Destroy(transform.gameObject, 3f);
        //StartCoroutine(GameOver());
    }

    public IEnumerator GameOver()
    {
        Color bgColor = bg.color;
        Color textColor = text.color;
        for(float i = 0; i < 1; i+= Time.deltaTime/3f)
        {
            bg.color = Color.Lerp(bgColor, new Color(bgColor.r, bgColor.g, bgColor.b, 1f), i);
            text.color = Color.Lerp(textColor, new Color(textColor.r, textColor.g, textColor.b, 1f), i);

            yield return null;
        }
    }
}
