using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantMove : MonoBehaviour
{


    public float movementSpeed, jumpSpeed, currJumpingSpeed = 0;
    public float originalHeight;
    public bool isJump = false, isFall = false;
    public float gravity = 20.0f;
    public Transform CameraPos;
    public float horizontalSpeed;
    public float verticalSpeed;
    public Animator anm;


    // Use this for initialization
    void Start()
    {
        originalHeight = transform.position.y;
    }

    void OnCollisionEnter(Collision collision)
    {
    }

    //Update is called once per frame
    void Update()
    {
        //anm.enabled = true;
        anm.speed = 0.03f;
        // Debug.Log("Yes emtering", Input.GetKey ("w"));
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
        {
            //anm.enabled = true;
            anm.speed = 1.0f;
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
        }
        else if (Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift))
        {
            //anm.enabled = true;
            anm.speed = 1.0f;
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey("s"))
        {
            //anm.enabled = true;
            anm.speed = 1.0f;
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            //anm.enabled = true;
            anm.speed = 1.0f;
            currJumpingSpeed = jumpSpeed;
            transform.position += transform.TransformDirection(Vector3.up) * Time.deltaTime * currJumpingSpeed;
            //            currJumpingSpeed -= gravity * Time.deltaTime;
            //            Debug.Log("origHeight: " + originalHeight);
        }
        /*
                if (isFall) {
                    transform.position += transform.TransformDirection (Vector3.down) * Time.deltaTime * currJumpingSpeed;
                    currJumpingSpeed += gravity * Time.deltaTime;
                    if (transform.position.y <= originalHeight){
                        isFall = false;
                    }
                }

                if (isJump) {
                    transform.position += transform.TransformDirection (Vector3.up) * Time.deltaTime * currJumpingSpeed;
                    currJumpingSpeed -= gravity * Time.deltaTime;
                    if (currJumpingSpeed <= 0) {
                        isFall = true;
                        isJump = false;
                    } 
                }
                */
        if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            //anm.enabled = true;
            anm.speed = 1.0f;
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            //anm.enabled = true;
            anm.speed = 1.0f;
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(v, h, 0);
        CameraPos.position = transform.position + Vector3.up * 5 + Vector3.forward*(-5.0f);
        CameraPos.rotation = transform.rotation;
        //Weapon.position = transform.position + transform.forward * 4 + Vector3.up * 2.5f + Vector3.right * 2.0f;
        //Quaternion q = Quaternion.AngleAxis(-20f, transform.up);
        //Weapon.rotation = q*transform.rotation;
        if (Vector3.Angle(transform.up, Vector3.up) > 60.0f)
        {
            transform.up = Vector3.up;
        }
        //CameraPos.Rotate(v, h, 0);
    }

}
