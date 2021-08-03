using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PieceGeneration : MonoBehaviour
{
    [SerializeField] int minWidth = 2;
    [SerializeField] int maxWidth = 20;

    [SerializeField] Transform groundTile;
    [SerializeField] public Transform endPosition;
    

    GameObject p;

    public Transform levelPartTransform;
    // Start is called before the first frame update
    void Start()
    {
    }

    //public void Generate()
    //{
    //    int width = Random.Range(minWidth, maxWidth);
    //    for (int x=0; x < width; x++) 
    //    {
           
    //         Instantiate(groundTile, new Vector2(x, 0), Quaternion.identity);
    //        if (x == width - 1)
    //        {
    //            Instantiate(endLevelPosition, new Vector2(x, 0), Quaternion.identity);
    //        }
    //    }

       
    //}

    public Transform Generate(Vector3 spawnPosition) 
    {
        int width = Random.Range(minWidth, maxWidth);
        for (int x = 0; x < width; x++)
        {

            levelPartTransform = Instantiate(groundTile, new Vector3(spawnPosition.x + x, 0, 0), Quaternion.identity);
            if (x == width - 1)
            {
                levelPartTransform = Instantiate(endPosition, new Vector3(spawnPosition.x + x, 0, 0), Quaternion.identity);
            }
        }

        return levelPartTransform;
        //return Instantiate(groundTile, new Vector3(spawnPosition.x + 10, 0, 0), Quaternion.identity);
    }

    
}
