using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject ground_Top, groundMid, bridge, spikes;



    public int minPlatformSize = 1;
    public int maxPlatformSize = 10;
    public int maxHazardSize = 3;
    public int maxHeight = 3;
    public int maxDrop = -3;

    public int platforms = 100;

    [Range(0.01f, 1f)]
    public float hazardChance = 0.5f;

    [Range(0.01f, 1f)]
    public float bridgeChance = 0.1f;

    [Range(0.01f, 1f)]
    public float spikeChance = 0.5f;


    private int blockNum = 1;
    private int blockHeight;
    private bool isHazard;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ground_Top, new Vector2(0, 0), Quaternion.identity);

        for (int plat = 1; plat < platforms; plat++)
        {
            // prevents recurrence of hezer 
            if (isHazard == true)
            {
                isHazard = false;
            }
            else
            {
                if (Random.value < hazardChance)
                {
                    isHazard = true;
                }
                else
                {
                    isHazard = false;
                }
            }



            if (isHazard == true)
            {
                int hazardSize = Mathf.RoundToInt(Random.Range(1, maxHazardSize));

                if (Random.value < spikeChance)
                {
                    // generate spike traps
                    for (int tiles = 0; tiles < hazardSize; tiles++)
                    {
                        Instantiate(spikes, new Vector2(blockNum, (blockHeight) - 2), Quaternion.identity);

                        for (int gndMid = 1; gndMid < 5; gndMid++)
                        {
                            Instantiate(groundMid, new Vector2(blockNum, (blockHeight - gndMid) - 2), Quaternion.identity);

                        }
                        blockNum++;
                    }

                }
                else
                {
                    // holes in the ground
                    blockNum += hazardSize;
                }


            }
            else if (Random.value < bridgeChance)
            {
                // bridge generation
                int platformSize = Mathf.RoundToInt(Random.Range(minPlatformSize, maxPlatformSize));
                blockHeight = blockHeight + Random.Range(maxDrop, maxHeight);

                for (int tiles = 0; tiles < platformSize; tiles++)
                {
                    if (tiles == 0 || tiles == platformSize - 1)
                    {
                        Instantiate(ground_Top, new Vector2(blockNum, blockHeight), Quaternion.identity);

                        for (int gndMid = 1; gndMid < 5; gndMid++)
                        {
                            Instantiate(groundMid, new Vector2(blockNum, blockHeight - gndMid), Quaternion.identity);

                        }

                        blockNum++;

                    }
                    else
                    {
                        Instantiate(bridge, new Vector2(blockNum, blockHeight), Quaternion.identity);
                        blockNum++;
                    }
                }

            }


            else
            {

                bool isEnemyPlatform = false;
                //platform generation
                int platformSize = Mathf.RoundToInt(Random.Range(minPlatformSize, maxPlatformSize));
                blockHeight = blockHeight + Random.Range(maxDrop, maxHeight);

                // enemy generating
                if (platformSize >= 3)
                {
                    if (Random.value < 0.3f)
                    {
                        GetComponent<EnemyPlacement>().PlaceEnemy(new Vector2(blockNum + 1, blockHeight));
                        isEnemyPlatform = true;
                    }
                }

                for (int tiles = 0; tiles < platformSize; tiles++)
                {
                    Instantiate(ground_Top, new Vector2(blockNum, blockHeight), Quaternion.identity);

                    for (int gndMid = 1; gndMid < 5; gndMid++)
                    {
                        Instantiate(groundMid, new Vector2(blockNum, blockHeight - gndMid), Quaternion.identity);

                    }
                    // object placement
                    if (tiles > 0 && tiles < platformSize - 1)
                    {
                        if (Random.value < 0.2f)
                        {
                            GetComponent<ObjectPlacement>().PlaceObjects(new Vector2(blockNum, blockHeight), isEnemyPlatform);
                        }
                    }

                    blockNum++;
                }
            }



        }
    }

}
