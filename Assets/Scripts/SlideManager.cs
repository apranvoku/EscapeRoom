using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideManager : MonoBehaviour
{
    public GameObject First;
    public GameObject Second;
    public GameObject Third;

    public GameObject Fourth;
    public GameObject Fifth;
    public GameObject Sixth;

    public GameObject Seventh;
    public GameObject Eighth;

    public GameObject[,] slidePuzzle;
    public GameObject[,] solution;

    public bool shuffled = false;
    public bool solved = false;
    public int shuffles = 20;
    // Start is called before the first frame update
    void Start()
    {
        slidePuzzle = new GameObject[,]
        {
            {First, Second, Third},
            {Fourth, Fifth, Sixth },
            {Seventh, Eighth, null }
        };

        solution = new GameObject[,]
        {
            {First, Second, Third},
            {Fourth, Fifth, Sixth },
            {Seventh, Eighth, null }
        };

        foreach (Transform child in transform)
        {
            child.GetComponent<Tile>().SetSM(transform.GetComponent<SlideManager>());
            child.GetComponent<Tile>().AssignPosition();
        }
        for (int x = 0; x < shuffles; x++)
        {
            Shuffle();
        }
        shuffled = true;
    }

    public void isSolved()
    {
        for (int i = 0; i < slidePuzzle.GetLength(0); i++)
        {
            for (int j = 0; j < slidePuzzle.GetLength(1); j++)
            {
                int childIndex = i * 3 + j; //Ex: 3rd row 1st column is child number 7. Remember 0 <= i <= 2 & 0<= j <= 2.
                if(childIndex == 8) //There is no child index 8, SInce there are 8 tiles indexed from 0 - 7 So we're done.
                {
                    Debug.Log("Good job!");
                    solved = true;
                    return;
                }
                else if (slidePuzzle[i, j] == transform.GetChild(childIndex).gameObject)
                {
                    //Debug.Log("Child: " + childIndex + " is correctly at row column: " + i + ", " + j);
                    continue;
                }
                else
                {
                    return;
                }
            }
        }


    }

    public void Shuffle() //Attempt to shuffle random tiles.
    {
        int random = UnityEngine.Random.Range(0, 8);
        transform.GetChild(random).GetComponent<Tile>().SlideTile();
    }

    public Tuple<int, int> GetIndex(GameObject searchItem)
    {
        for(int i = 0; i < slidePuzzle.GetLength(0); i++)
        { 
            for(int j = 0; j < slidePuzzle.GetLength(1); j++)
            {
                if(slidePuzzle[i,j].name == searchItem.name)
                {
                    return Tuple.Create(i, j);
                }
            }
        }
        Debug.Log("Not Found");
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
