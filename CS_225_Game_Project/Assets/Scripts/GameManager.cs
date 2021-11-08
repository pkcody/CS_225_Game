using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    
    private PlayerController m_purplePlayer;
    private PlayerController m_bluePlayer;

    public GameManager instance;

    private SceneManager sceneManager;

    void Awake()
    {
        sceneManager = GameObject.Find("_SceneManager").GetComponent<SceneManager>();
        //player = new PlayerController();

        if(sceneManager.selection == "Purple")
        {
            PurpleButton();
        }
        else
        {
            BlueButton();
        }
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
}
