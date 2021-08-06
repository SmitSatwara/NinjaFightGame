using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinScript : MonoBehaviour
{
    public float coinCollected = 0;
    public TextMeshProUGUI textCoin;

    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            coinCollected++;

            audioSource.Play();

            textCoin.text ="x " +coinCollected.ToString();
            Destroy(collision.gameObject);
        }
    }
}
