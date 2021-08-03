using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlacement : MonoBehaviour
{
    public GameObject saw, purpleMucus;

    [Range(0.1f, 1)]
    public float enemyRatio = 0.5f;
    // Start is called before the first frame update
   public void PlaceEnemy(Vector2 cords) 
    {
        float rnd = Random.value;
        if (rnd < enemyRatio) 
        {
            Instantiate(saw, new Vector3(cords.x, cords.y + 1.7f, -1), Quaternion.identity);
        }
        else 
        {
            Instantiate(purpleMucus, new Vector3(cords.x, cords.y + 1.7f, -1), Quaternion.identity);

        }
    }
}
