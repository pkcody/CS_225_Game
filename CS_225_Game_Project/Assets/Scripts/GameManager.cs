using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public GameManager instance;
    private SceneManager sceneManager;

    private bool playerAlive;

    [Header("Info")]
    public int coins;
    public int health;

    void Awake()
    {
        coins = 0;
        health = 100;
        playerAlive = true;

        sceneManager = GameObject.Find("_SceneManager").GetComponent<SceneManager>();

        if(sceneManager.selection == "Purple")
        {
            PurpleButton();
        }
        else
        {
            BlueButton();
        }
    }

    private void Update()
    {
        if (health <= 0)
            playerAlive = false;

        if (coins >= 200)
            WinGame();

        if (!playerAlive)
            EndGame();
    }

    public void PurpleButton()
    {
        IPlayerPhysics purplePhysics = new PurplePhysics();
        player.SetPhysics(purplePhysics);
        player.SetMesh(purplePhysics);
    }

    public void BlueButton()
    {
        IPlayerPhysics bluePhysics = new BluePhysics();
        player.SetPhysics(bluePhysics);
        player.SetMesh(bluePhysics);
    }

    public void EndGame()
    {
        sceneManager.GameOverScene();
    }

    public void WinGame()
    {
        sceneManager.GameOverScene();
    }
}
