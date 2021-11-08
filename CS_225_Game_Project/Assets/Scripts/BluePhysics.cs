using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePhysics : IPlayerPhysics
{
    public PlayerController playerC;

    public void Jump()
    {
        Debug.Log("jump");
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
        playerC.jumpForce = 5;

        // create a ray facing down
        Ray ray = new Ray(playerC.transform.position, Vector3.down);

        // shoot the raycast
        if (Physics.Raycast(ray, 1.5f))
            playerC.rig.AddForce(Vector3.up * playerC.jumpForce, ForceMode.Impulse);
    }

    public void Speed()
    {
        Debug.Log("speed");
    }
    public void SetColor()
    {
        Debug.Log("color");
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
        playerC.mat.color = Color.red;
    }
    public void Strength()
    {
        Debug.Log("strenght");
    }
}
