using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryManager : MonoBehaviour
{
    public List<int> memoryList;
    public int memoryLength;    
    public int memoryCap;
    public int currentPointer;
    public GameObject mirror;
    public bool clickable;
    // Start is called before the first frame update
    void Start()
    {
        clickable = true;
        currentPointer = 0;
        memoryLength = 1;
        memoryCap = 5;
        GenerateMemoryList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMemoryList()
    {
        memoryList.Clear();
        for(int i = 0; i < memoryLength; i++)
        {
            memoryList.Add(Random.Range(0, 9));
        }
        GlowTiles();
    }

    public void SubmitPress(int tileIndex)
    {
        if (clickable)
        {
            if (tileIndex == memoryList[currentPointer])
            {
                StartCoroutine(BlueGlow(tileIndex));
                currentPointer += 1;
                //Debug.Log(currentPointer);
                //Debug.Log(memoryList.Count);
                if (currentPointer == memoryList.Count)
                {
                    clickable = false;
                    if (memoryLength == memoryCap)
                    {
                        mirror.GetComponent<BoxCollider>().enabled = false;
                        StartCoroutine(GlowGreen());
                        //Success!
                    }
                    else
                    {
                        memoryLength += 1;
                        GenerateMemoryList();
                        currentPointer = 0;
                    }

                }
            }
            else
            {
                currentPointer = 0;
                clickable = false;
                StartCoroutine(GlowRed());
            }
        }

    }

    public void GlowTiles()
    {
        StartCoroutine(TileGlow());
    }

    public IEnumerator BlueGlow(int tileIndex)
    {
        Color original = Color.white;
        for (float x = 0; x < 1; x += Time.deltaTime * 2)
        {
            transform.GetChild(tileIndex).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.blue, x);
            yield return null;
        }
        for (float x = 1; x > 0; x -= Time.deltaTime * 2)
        {
            transform.GetChild(tileIndex).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.blue, x);
            yield return null;
        }
    }

    public IEnumerator TileGlow()
    {
        yield return new WaitForSeconds(1f);
        
        Color original = Color.white;
        for(int i = 0; i < memoryLength; i++)
        {
            for (float x = 0; x < 1; x += Time.deltaTime * 3)
            {
                transform.GetChild(memoryList[i]).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.yellow, x);
                yield return null;
            }
            for (float x = 1; x > 0; x -= Time.deltaTime * 3)
            {
                transform.GetChild(memoryList[i]).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.yellow, x);
                yield return null;
            }
        }
        clickable = true;
    }

    public IEnumerator GlowGreen()
    {
        Color original = Color.white;
        for (float x = 0; x < 1; x += Time.deltaTime * 2)
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            transform.GetChild(2).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            transform.GetChild(3).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            transform.GetChild(4).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            transform.GetChild(5).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            transform.GetChild(6).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            transform.GetChild(7).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            transform.GetChild(8).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            yield return null;
        }
        for (float x = 1; x > 0; x -= Time.deltaTime * 2)
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            transform.GetChild(2).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            transform.GetChild(3).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            transform.GetChild(4).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            transform.GetChild(5).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            transform.GetChild(6).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            transform.GetChild(7).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            transform.GetChild(8).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.green, x);
            yield return null;
        }
    }

    public IEnumerator GlowRed()
    {
        Color original = Color.white;
        for (float x = 0; x < 1; x += Time.deltaTime * 2)
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            transform.GetChild(2).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            transform.GetChild(3).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            transform.GetChild(4).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            transform.GetChild(5).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            transform.GetChild(6).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            transform.GetChild(7).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            transform.GetChild(8).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            yield return null;
        }
        for (float x = 1; x > 0; x -= Time.deltaTime * 2)
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            transform.GetChild(2).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            transform.GetChild(3).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            transform.GetChild(4).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            transform.GetChild(5).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            transform.GetChild(6).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            transform.GetChild(7).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            transform.GetChild(8).GetComponent<MeshRenderer>().material.color = Color.Lerp(original, Color.red, x);
            yield return null;
        }
        GlowTiles();
    }
}
