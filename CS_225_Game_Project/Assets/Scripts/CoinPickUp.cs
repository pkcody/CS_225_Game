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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log(money);
        }
    }
}
