using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Rook1;
    public GameObject Rook2;
    public GameObject Rook3;
    public GameObject Rook4;
    public GameObject MatingSquare;
    public GameObject DoorArch;
    public static GameObject SelectedPiece;

    public static int Move;

    void Start()
    {
        Move = 1;
    }

    public void StateMachine()
    {
        if(Move == 1 && SelectedPiece.name == "Rook1")
        {
            Move = 2;
            Debug.Log("State 2");
        }
        if (Move == 2 && SelectedPiece.name == "Rook3")
        {
            Move = 3;
            StartCoroutine(RookTake());
            Debug.Log("State 3");
        }
        if (Move == 3 && SelectedPiece.name == "Rook2")
        {
            Move = 4;
            Debug.Log("State 4");
        }
        if (Move == 4 && SelectedPiece.name == "MatingSquare")
        {
            StartCoroutine(RookMate());
            DoorArch.GetComponent<DoorOpen>().OpenDoors();
            Debug.Log("Chess Solved");
            //OpenDoor
        }
    }

    public IEnumerator RookTake()
    {
        Color originalCol = Rook3.GetComponent<MeshRenderer>().material.color;
        Vector3 initialPos = Rook1.transform.position;
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            Rook1.transform.position = Vector3.Lerp(initialPos, Rook3.transform.position, i);
            Rook3.GetComponent<MeshRenderer>().material.color = new Color(originalCol.r, originalCol.g, originalCol.b, 1f - i);
            Rook3.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = new Color(originalCol.r, originalCol.g, originalCol.b, 1f - i);
            yield return null;
        }
        Destroy(Rook3);
        StartCoroutine(RookRecapture());
    }

    public IEnumerator RookMate()
    {
        Vector3 initialPos = Rook2.transform.position;
        for(float i = 0; i < 1; i += Time.deltaTime)
        {
            Rook2.transform.position = Vector3.Lerp(initialPos, MatingSquare.transform.position, i);
            yield return null;
        }
    }

    public IEnumerator RookRecapture()
    {
        Color originalCol = Rook1.GetComponent<MeshRenderer>().material.color;
        Vector3 initialPos = Rook4.transform.position;
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            Rook4.transform.position = Vector3.Lerp(initialPos, Rook3.transform.position, i);
            Rook1.GetComponent<MeshRenderer>().material.color = new Color(originalCol.r, originalCol.g, originalCol.b, 1f - i);
            Rook1.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = new Color(originalCol.r, originalCol.g, originalCol.b, 1f - i);
            yield return null;
        }
        Destroy(Rook1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
