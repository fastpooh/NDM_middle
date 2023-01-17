using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGen : MonoBehaviour
{
    public GameObject wall;

    void Start()
    {
        generateTerrain();
    }

    void generateTerrain()
    {
        int cols = 9;
        int rows = 5;

        for(int x = -9; x<cols; x++)
        {
            for(int z = -5; z<rows; z++)
            {
                float y = 0;
                GameObject newBlock = GameObject.Instantiate(wall);
                newBlock.transform.position = new Vector3(x, y, z);
            }
        }
    }
}
