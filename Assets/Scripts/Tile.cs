using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Tuple<int, int> Position;
    SlideManager SM;
    public delegate void OnClick();
    public static event OnClick onTile;

    private void OnEnable()
    {
        Tile.onTile += SlideTile;
    }
    private void OnDisable()
    {
        Tile.onTile += SlideTile;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void SetSM(SlideManager newSM)
    {
        SM = newSM;
    }

    public void AssignPosition()
    {
        //Debug.Log(SM.name);
        Position = SM.GetIndex(transform.gameObject);
        //Debug.Log(transform.gameObject.name + Position.Item1 + Position.Item2);
    }

    public void OnMouseDown()
    {
        SlideTile();
    }

    public void SlideTile()
    {
        int row = Position.Item1; //0 to 2
        int column = Position.Item2; // 0 to 2

        if (row + 1 < SM.slidePuzzle.GetLength(0) && SM.slidePuzzle[row+1, column] is null)
        {
            SlideDown(row, column);
        }
        if (column + 1 < SM.slidePuzzle.GetLength(1) && SM.slidePuzzle[row, column + 1] is null)
        {
            SlideRight(row, column);
        }
        if (row - 1 >= 0 && SM.slidePuzzle[row - 1, column] is null)
        {
            SlideUp(row, column);
        }
        if (column - 1 >= 0 && SM.slidePuzzle[row, column - 1] is null)
        {
            SlideLeft(row, column);
        }
        if(SM.shuffled)
        {
            //Debug.Log("Checking...");
            SM.isSolved();
        }
    }
    public void SlideDown(int row, int column)
    {
        SM.slidePuzzle[row, column] = null;
        SM.slidePuzzle[row + 1, column] = transform.gameObject;
        Position = Tuple.Create(row + 1, column);
        transform.position += new Vector3(0, -2, 0);
    }
    public void SlideRight(int row, int column)
    {
        SM.slidePuzzle[row, column] = null;
        SM.slidePuzzle[row, column + 1] = transform.gameObject;
        Position = Tuple.Create(row, column + 1);
        transform.position += new Vector3(2, 0, 0);
    }
    public void SlideUp(int row, int column)
    {
        SM.slidePuzzle[row, column] = null;
        SM.slidePuzzle[row - 1, column] = transform.gameObject;
        Position = Tuple.Create(row - 1, column);
        transform.position += new Vector3(0, 2, 0);
    }

    public void SlideLeft(int row, int column)
    {
        SM.slidePuzzle[row, column] = null;
        SM.slidePuzzle[row, column - 1] = transform.gameObject;
        Position = Tuple.Create(row, column - 1);
        transform.position += new Vector3(-2, 0, 0);
    }
}