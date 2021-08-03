//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LevelGeneration : MonoBehaviour
//{
//    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;
//    [SerializeField] private Transform levelPart_Start;
//    [SerializeField] private  PieceGeneration part;
//    [SerializeField] private Character character;

//    private Vector3 lastEndPosition;

//    private void Awake() 
//    {
//        lastEndPosition = levelPart_Start.Find("EndPosition").position;

//        int startingSpawnLevelParts = 5;
//        for(int i = 0; i < startingSpawnLevelParts; i++) 
//        {
//            SpawnLevelPart();
//        }
//    }

//    private void Update()
//    {
//        if (Vector3.Distance(character.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART) 
//        {
//            SpawnLevelPart();
//        }
//    }

//    private void SpawnLevelPart()
//    {
//        Transform lastLevelPartTransform = part.Generate(lastEndPosition);
//        lastEndPosition = lastLevelPartTransform.transform.Find("EndPosition(Clone)").position;
//    }
//}
