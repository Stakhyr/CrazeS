using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPicker : MonoBehaviour
{
    public int coinsCount = 0;

    [SerializeField] TextMeshProUGUI textCoins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Coin") 
        {
            coinsCount+=1;
            textCoins.text = coinsCount.ToString();

            Destroy(collision.gameObject);
        }
    }


}
