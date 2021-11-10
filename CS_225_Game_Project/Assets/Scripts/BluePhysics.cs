using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePhysics : IPlayerPhysics
{
    public PlayerController playerC;

    public void Jump()
    {
        //Debug.Log("jump");
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
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
        playerC.moveSpeed = 14;

        // get the input axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // calculate a direction relative to where the player is facing
        Vector3 dir = (playerC.transform.forward * z + playerC.transform.right * x) * playerC.moveSpeed;
        dir.y = playerC.rig.velocity.y;

        // set as velocity
        playerC.rig.velocity = dir;
    }
    public void SetColor()
    {
        //Debug.Log("color");
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
        playerC.mat.color = Color.blue;
    }
    public void Strength()
    {
        Debug.Log("strength");
    }
}
