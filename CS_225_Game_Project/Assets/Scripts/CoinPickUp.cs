using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public GameManager _gm;
    public int money = 0;

    void Start()
    {
        _gm = GameObject.Find("_GameManager").GetComponent<GameManager>();

    }

    private void Update()
    {
        if (gameObject.tag == "Coin")
        {
            ICoin coin = new BasicCoin();
            money = coin.GetWorth();
        }
        if (gameObject.tag == "Gold")
        {
            ICoin coin = new BasicCoin();
            coin = new Gold(coin);
            money = coin.GetWorth();
        }
        if (gameObject.tag == "Diomand")
        {
            ICoin coin = new BasicCoin();
            coin = new Diomand(coin);
            money = coin.GetWorth();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player has: "+money);
            _gm.coins += money;
            Destroy(gameObject);
        }
    }
}
