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
    public IPlayerState currentState; // object composition

    [Header("Strategy&Composition")]
    public IPlayerPhysics myPhysics; // object composition

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
            //Debug.Log("tryjump");
            Jump();
        }
    }

    public void Move()
    {
        myPhysics.Speed();
    }

    public void Jump()
    {
        myPhysics.Jump(); 
        //Debug.Log("after"); 
    }

    public void SetColor()
    {
        myPhysics.SetColor();
    }
}
