using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelCreator : MonoBehaviour
{

    [SerializeField]
    private Transform endPosition;

    [SerializeField]
    private Transform levelPart;

    void Start()
    {
        GenerateX();

    }

    void Update()
    {
        
    }

    /// <summary>
    /// Return endposition of current platform
    /// </summary>
    /// <param name="part"></param>
    /// <returns></returns>
    Vector3 GetPosition(Transform part) 
    {
        int childIndex = part.childCount - 1;
        Transform endChild = part.GetChild(childIndex);
        return endChild.transform.position;
    }

    void GenerateX() 
    {
        Vector3 posf = new Vector2(endPosition.position.x, endPosition.position.y);
        for (int i = 0; i < 50; i++)
        {
            posf.x = Random.Range(1f, 5f) + posf.x;
            posf.y = Random.Range(-1f, 3f);
            Transform levelPartTransform = Instantiate(levelPart, posf, Quaternion.identity);
            posf = GetPosition(levelPartTransform);

            if (i == 4)
            {
                var g = levelPart.GetChild(6);
                Debug.Log(g.position.x);
                Transform mapEnd = Instantiate(endPosition, posf, Quaternion.identity);
            }
        }
    }
}
