using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{

    public float min_rot_Z = -55f;
    public float max_rot_Z = 55f;
    public float rotSpeed = 50f;

    private float rotAngle;
    private bool rotRight;
    private bool canRot;

    public float moveSpeed = 3f;
    private float initialMoveSpeed;

    public float min_Y = -2.5f;
    private float initial_Y;

    private bool moveDown;

    private RopeRenderer ropeRenderer;

    void Awake()
    {
        ropeRenderer = GetComponent<RopeRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        initial_Y = transform.position.y;
        initialMoveSpeed = moveSpeed;
        canRot = true;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        GetInput();
        MoveRope();
    }

    void MoveRope()
    {
        if (canRot)
            return;
        else
        {
            Vector3 temp = transform.position;
            if (moveDown)
            {
                temp -= transform.up * Time.deltaTime * moveSpeed;
            }
            else
            {
                temp += transform.up * Time.deltaTime * moveSpeed;
            }
            transform.position = temp;

            if (temp.y <= min_Y)
            {
                moveDown = false;
            }
            if (temp.y >= initial_Y)
            {
                canRot = true;
                ropeRenderer.RenderLine(temp, false);
                moveSpeed = initialMoveSpeed; 
            }
            ropeRenderer.RenderLine(transform.position, true);
        }
    }

    void Rotate()
    {
        if (!canRot)
            return;
        if (rotRight)
            rotAngle += rotSpeed * Time.deltaTime;
        else
            rotAngle -= rotSpeed * Time.deltaTime;

        transform.rotation = Quaternion.AngleAxis(rotAngle, Vector3.forward);
        if (rotAngle >= max_rot_Z)
            rotRight = false;
        else if (rotAngle <= min_rot_Z)
            rotRight = true;

    }

    void GetInput()
    {
        if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            if (canRot)
            {
                canRot = false;
                moveDown = true;
            }
        }
    }
}
