using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float movementSpeed, jumpSpeed, currJumpingSpeed=0;
    public float originalHeight;
    public bool isJump = false, isFall = false;
    public float gravity = 20.0f;

    // Use this for initialization
    void Start () {
    	originalHeight = transform.position.y;
    }

    //Update is called once per frame
    void Update () {
    	// Debug.Log("Yes emtering", Input.GetKey ("w"));
        if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey ("w")) {
            transform.position += transform.TransformDirection (Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
        }   else if (Input.GetKey ("w") && !Input.GetKey (KeyCode.LeftShift)) {
            transform.position += transform.TransformDirection (Vector3.forward) * Time.deltaTime * movementSpeed;
        }   else if (Input.GetKey ("s")) {
            transform.position -= transform.TransformDirection (Vector3.forward) * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey (KeyCode.Space)) {
        	isJump = true;
            currJumpingSpeed = jumpSpeed;
            Debug.Log("origHeight: " + originalHeight);
        }

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

        if (Input.GetKey ("a") && !Input.GetKey ("d")) {
                transform.position += transform.TransformDirection (Vector3.left) * Time.deltaTime * movementSpeed;
            } else if (Input.GetKey ("d") && !Input.GetKey ("a")) {
                transform.position -= transform.TransformDirection (Vector3.left) * Time.deltaTime * movementSpeed;
            }
        }
}