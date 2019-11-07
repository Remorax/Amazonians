using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

 
    public float movementSpeed, jumpSpeed, currJumpingSpeed=0;
    public float originalHeight;
    public bool isJump = false, isFall = false;
    public float gravity = 20.0f;
    public Transform CameraPos;
    public float horizontalSpeed;
    public float verticalSpeed;
    public Transform Weapon;
    public Animator animator;
    public RuntimeAnimatorController anim_idle;
    public RuntimeAnimatorController anim_walk;
    public RuntimeAnimatorController anim_jump;
    public GameObject elephant;
    public Animator anm_elephant;
    public bool onElephant=false;


    // Use this for initialization
    void Start () {
        onElephant = false;
    	originalHeight = transform.position.y;
        Weapon.parent = CameraPos;
        Weapon.position = CameraPos.position + CameraPos.forward + CameraPos.right - CameraPos.up * 1.5f;
        Weapon.rotation = CameraPos.rotation;
        //elephant = GameObject.Find("Elephant");
    }
    void OnCollisionEnter(Collision collision)
    {
    }

    //Update is called once per frame
    void Update () {
        // Debug.Log("Yes emtering", Input.GetKey ("w"));
        if (Input.GetKeyDown("r") && !onElephant)
        {
            float dist = Vector3.Distance(elephant.transform.position, transform.position);
            //Debug.Log(dist);
            if(dist<=20.0f)
            {
                onElephant = true;
                transform.position = elephant.transform.position-1000*Vector3.forward;
                anm_elephant.enabled = true;
                anm_elephant.speed = 0.03f;
                CameraPos.position = elephant.transform.position + Vector3.up * 5 + Vector3.forward * (-5.0f);
                CameraPos.rotation = elephant.transform.rotation;
            }
        }
        else if (Input.GetKeyDown("r") && onElephant)
        {
            onElephant = false;
            anm_elephant.enabled = false;
            transform.position = elephant.transform.position - 15 * Vector3.forward + 15 * Vector3.right;
        }
        if (!onElephant)
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
            {
                animator.runtimeAnimatorController = anim_walk;
                transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
            }
            else if (Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift))
            {
                animator.runtimeAnimatorController = anim_walk;
                transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
            }
            else if (Input.GetKey("s"))
            {
                animator.runtimeAnimatorController = anim_walk;
                transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
            }
            else if (!Input.GetKey(KeyCode.Space))
            {
                animator.runtimeAnimatorController = anim_idle;
                //animator.runtimeAnimatorController = Resources.Load("Assets/Kevin Iglesias/Basic Motions Pack/AnimationControllers/BasicMotions@Idle.controller") as RuntimeAnimatorController;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                animator.runtimeAnimatorController = anim_jump;
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
                transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
            }
            else if (Input.GetKey("d") && !Input.GetKey("a"))
            {
                transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
            }
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");

            transform.Rotate(0, h, 0);
            CameraPos.position = transform.position + transform.forward * 2 + Vector3.up * 5;
            CameraPos.rotation = transform.rotation;
            //Weapon.position = transform.position + transform.forward * 4 + Vector3.up * 2.5f + Vector3.right * 2.0f;
            //Quaternion q = Quaternion.AngleAxis(-20f, transform.up);
            //Weapon.rotation = q*transform.rotation;
            if (Vector3.Angle(transform.up, Vector3.up) > 60.0f)
            {
                transform.up = Vector3.up;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
            {
                //anm.enabled = true;
                anm_elephant.speed = 1.0f;
                elephant.transform.position += elephant.transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
            }
            else if (Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift))
            {
                //anm.enabled = true;
                anm_elephant.speed = 1.0f;
                elephant.transform.position += elephant.transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
            }
            else if (Input.GetKey("s"))
            {
                //anm.enabled = true;
                anm_elephant.speed = 1.0f;
                elephant.transform.position -= elephant.transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                //anm.enabled = true;
                anm_elephant.speed = 1.0f;
                currJumpingSpeed = jumpSpeed;
                elephant.transform.position += elephant.transform.TransformDirection(Vector3.up) * Time.deltaTime * currJumpingSpeed;
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
                anm_elephant.speed = 1.0f;
                elephant.transform.position += elephant.transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
            }
            else if (Input.GetKey("d") && !Input.GetKey("a"))
            {
                //anm.enabled = true;
                anm_elephant.speed = 1.0f;
                elephant.transform.position -= elephant.transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
            }
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");

            elephant.transform.Rotate(0, h, 0);
            CameraPos.position = elephant.transform.position + Vector3.up * 5 + Vector3.forward * (-5.0f);
            CameraPos.rotation = elephant.transform.rotation;
            //Weapon.position = transform.position + transform.forward * 4 + Vector3.up * 2.5f + Vector3.right * 2.0f;
            //Quaternion q = Quaternion.AngleAxis(-20f, transform.up);
            //Weapon.rotation = q*transform.rotation;
            if (Vector3.Angle(elephant.transform.up, Vector3.up) > 60.0f)
            {
                elephant.transform.up = Vector3.up;
            }
        }
        //CameraPos.Rotate(v, h, 0);
    }
}