using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 2f, -4.5f);
    public Vector3 camOffsetTwo = new Vector3(0f, 1f, .5f);

    [Header("Look Sensitivity")]
    public float sensX;
    public float sensY;

    [Header("Clamping")]
    public float minY;
    public float maxY;

    private float rotX;
    private float rotY;

    private Transform target;
    private int camMode;

    private bool dead = false;

    void Start()
    {
        // lock the cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {

        // get the mouse movement inputs
        rotX += Input.GetAxis("Mouse X") * sensX;
        rotY += Input.GetAxis("Mouse Y") * sensY;

        //clamp the vertical rotation
        rotY = Mathf.Clamp(rotY, minY, maxY);
        if (!dead)
        {
            // first or third perspective
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (camMode == 1)
                {
                    camMode = 0;
                }
                else
                {
                    camMode += 1;
                }
            }
            if (camMode == 0)
            {
                this.transform.position = target.TransformPoint(camOffset);
                this.transform.LookAt(target);
            }
            if (camMode == 1)
            {
                this.transform.position = target.TransformPoint(camOffsetTwo);
            }
        }

        if (!dead)
        {
            // rotate camera vertically
            transform.localRotation = Quaternion.Euler(-rotY, 0, 0);

            // rotate player horizontally
            transform.parent.rotation = Quaternion.Euler(0, rotX, 0);
        }
    }
}
