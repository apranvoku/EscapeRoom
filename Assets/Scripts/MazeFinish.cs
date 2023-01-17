using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MazeFinish : MonoBehaviour
{
    public TMP_Text end;
    public Image crosshair;
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
        StartCoroutine(GameOver());
        transform.GetComponent<BoxCollider>().enabled = false;
    }

    public IEnumerator GameOver()
    {
        Color bgColor = bg.color;
        Color endColor = end.color;
        Color crosshairColor = crosshair.color;
        for(float i = 0; i < 1; i+= Time.deltaTime/3f)
        {
            bg.color = Color.Lerp(bgColor, new Color(bgColor.r, bgColor.g, bgColor.b, 1f), i);
            end.color = Color.Lerp(endColor, new Color(endColor.r, endColor.g, endColor.b, 1f), i);
            crosshair.color = Color.Lerp(crosshairColor, new Color(crosshairColor.r, crosshairColor.g, crosshairColor.b, 0f), i);

            yield return null;
        }
    }
}
