using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    Color original;
    // Start is called before the first frame update
    void Start()
    {
        original = transform.GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        OnSelectPiece();
    }

    public void OnSelectPiece()
    {
        StartCoroutine(GlowRed());
        ChessPuzzle.SelectedPiece = transform.gameObject;
        transform.parent.GetComponent<ChessPuzzle>().StateMachine();
    }

    public IEnumerator GlowRed()
    {
        for (float i = 0; i < 1; i+= Time.deltaTime*2)
        {
            transform.GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, i);
            if(transform.childCount > 0)
            {
                transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, i);
            }
            yield return null;
        }
        for (float i = 1; i > 0; i -= Time.deltaTime*2)
        {
            transform.GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, i);
            if (transform.childCount > 0)
            {
                transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, i);
            }
            yield return null;
        }
    }
}
