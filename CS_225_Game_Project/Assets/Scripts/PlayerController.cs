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
    public Material mat;

    [Header ("State")]
    public IPlayerState currentState;

    [Header("Strategy&Composition")]
    public IPlayerPhysics myPhysics;



    public void SetPhysics(IPlayerPhysics setPhysics)
    {
        myPhysics = setPhysics;
    }
    public void SetMesh(IPlayerPhysics setMesh)
    {
        myPhysics = setMesh;
    }
    public void Awake()
    {
        currentState = new StandingPlayerState();
        mat = this.GetComponent<Renderer>().material;
       
    }

    public void Start()
    {
        SetColor();
    }

    void Update()
    {
        currentState.Execute(this);

        Move();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("tryjump");
            Jump();
        }
    }

    public void Move()
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

    public void Jump()
    {
        myPhysics.Jump(); //bad
        Debug.Log("after"); // is getting called
    }

    public void SetColor()
    {
        myPhysics.SetColor();
    }
}
