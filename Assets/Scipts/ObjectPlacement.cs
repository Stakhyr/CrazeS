using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    public GameObject mushroomRed, boxCrate, rock, singRight, plantPurle, bush;
    // Start is called before the first frame update
    
    public void PlaceObjects(Vector2 cords, bool isEnemy) 
    {
        float rnd = Random.value;

        if (rnd < 0.2f) 
        {
            if (isEnemy == false)
            {
                Instantiate(boxCrate, new Vector3(cords.x, cords.y + 1, 1), Quaternion.identity);
            }
            else 
            {
                Instantiate(rock, new Vector3(cords.x, cords.y + 1, 1), Quaternion.identity);

            }
        }

        if (rnd >= 0.2f && rnd<0.3f)
        {
            Instantiate(singRight, new Vector3(cords.x, cords.y + 1, 1), Quaternion.identity);
        }

        if (rnd >= 0.3f && rnd< 0.5f)
        {
            Instantiate(rock, new Vector3(cords.x, cords.y + 1.33f, 1), Quaternion.identity);
        }

        if (rnd >= 0.5f && rnd < 0.7f)
        {
            Instantiate(plantPurle, new Vector3(cords.x, cords.y + 1.33f, 1), Quaternion.identity);
        }

        if (rnd >= 0.7f && rnd<0.85f)
        {
            Instantiate(bush, new Vector3(cords.x, cords.y + 1.38f, 1), Quaternion.identity);
        }

        if (rnd >= 0.79f)
        {
            Instantiate(mushroomRed, new Vector3(cords.x, cords.y + 1.24f, 1), Quaternion.identity);
        }
    }
}
