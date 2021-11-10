using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text coinText;
    public Text healthText;

    public GameManager _gm;

    private void Awake()
    {
        _gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
    }
    private void FixedUpdate()
    {
        coinText.text = "<b>Coins:</b> " + _gm.coins;
        healthText.text = "<b>Health:</b> " + _gm.health;
    }
}
