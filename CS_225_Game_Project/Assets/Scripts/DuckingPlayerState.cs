
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckingPlayerState : IPlayerState
{
    PlayerController mPlayer;
    Rigidbody rb;
    Vector3 changeScale;
    public void Enter(PlayerController player)
    {
        rb = player.GetComponent<Rigidbody>();
        player.currentState = this;

        changeScale = new Vector3((float)0.5, (float)0.25, (float)0.5);
        rb.transform.localScale += changeScale;
    }
    public void Execute(PlayerController player)
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            changeScale = new Vector3(1, 1, 1);
            rb.transform.localScale = changeScale;
            StandingPlayerState STANDstate = new StandingPlayerState();
            STANDstate.Enter(player);
        }
    }
}