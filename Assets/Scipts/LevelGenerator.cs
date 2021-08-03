using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 50f;
    [SerializeField] private Transform levelStart;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Character character;
    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelStart.Find("EndPosition").position;

    }

    //private void start()
    //{
    //    spawnlevelpart();
    //}
    private void Update()
    {
        if(Vector3.Distance(character.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART) 
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart() 
    {
        int rand = UnityEngine.Random.Range(0, levelPartList.Count);
        Transform chosenLevelPart = levelPartList[rand];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, CalculatePartPosition(lastEndPosition));
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

    private Vector3 CalculatePartPosition(Vector3 lastEndPosition) 
    {
        Vector3 newPosition = new Vector3(lastEndPosition.x+UnityEngine.Random.Range(5,8), lastEndPosition.y + UnityEngine.Random.Range(0, 2), lastEndPosition.z);
        return newPosition;
    }

 
}
