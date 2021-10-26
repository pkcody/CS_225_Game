using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed;
    public float jumpForce;

    [Header("Components")]
    public Rigidbody rig;
    public MeshRenderer mr;

    [Header ("StateAndCopy")]
    public IPlayerState currentState;


    void Awake()
    {
        currentState = new StandingPlayerState();
    }

    void Update()
    {
        currentState.Execute(this);

        Move();

        if (Input.GetKeyDown(KeyCode.Space))
            TryJump();
    }

    void Move()
    {
        // get the input axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // calculate a direction relative to where the player is facing
        Vector3 dir = (transform.forward * z + transform.right * x) * moveSpeed;
        dir.y = rig.velocity.y;

        // set as velocity
        rig.velocity = dir;
    }

    void TryJump()
    {
        // create a ray facing down
        Ray ray = new Ray(transform.position, Vector3.down);

        // shoot the raycast
        if (Physics.Raycast(ray, 1.5f))
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
