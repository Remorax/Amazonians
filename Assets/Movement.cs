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
    public GameObject cutter;
    public Enemy1Motion e1;
    public Enemy2Motion e2;
    public CutterMotion c;
    public ButtonFunction boss;
    public Renderer axe;
    public Renderer boss_r1;
    public Renderer boss_r2;
    public Renderer boss_r3;
    public Renderer boss_r4;
    public Renderer tiger_r;
    public Renderer cutter_r1;
    public Renderer cutter_r2;
    public Animator anm_elephant;
    public bool onElephant=false;
    public int level=0;
    private bool level1comp=false;
    public videoplay VideoPlayer;
    public videoplay VideoPlayer1;
    public videoplay VideoPlayer2;
    public videoplay VideoPlayer3;
    public videoplay VideoPlayer4;


    // Use this for initialization
    void Start () {
        axe.enabled = false;
        boss_r1.enabled = false;
        boss_r2.enabled = false;
        boss_r3.enabled = false;
        boss_r4.enabled = false;
        tiger_r.enabled = false;
        //cutter_r1.enabled = false;
        //cutter_r2.enabled = false;
        level1comp=false;
        onElephant = false;
    	originalHeight = transform.position.y;
        Weapon.parent = CameraPos;
        Weapon.position = CameraPos.position + CameraPos.forward + CameraPos.right - CameraPos.up * 1.5f;
        Weapon.rotation = CameraPos.rotation;
        //VideoPlayer = FindObjectOfType<videoplay>();
        StartCoroutine(VideoPlayer.PlayVideo("vid1"));
//        StartCoroutine(VideoPlayer1.PlayVideo("Mission1"));
        //elephant = GameObject.Find("Elephant");
    }
    void OnCollisionEnter(Collision collision)
    {
    }

    //Update is called once per frame
    void Update () {
        if(PauseMenu.GameIsPaused)
        {
            return;
        }
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
                if (level == 0)
                {
                        level += 1;
                    //cutter_r1.enabled = true;
                    //cutter_r2.enabled = true;
                   // Debug.Log("Here2");
                    c.flg_update = true;
                    c.s_time=Time.time;
                }
            }
        }
        else if (Input.GetKeyDown("r") && onElephant)
        {
            onElephant = false;
            anm_elephant.enabled = false;
            transform.position = elephant.transform.position - 15 * Vector3.forward + 15 * Vector3.right;
            if (!level1comp)
            {
                level = 0;
                c.animator.runtimeAnimatorController = anim_idle;
                transform.position = new Vector3(122.3f, 16.3f, 181.5f);
                elephant.transform.position = new Vector3(110.9f, 25.2f, 200f);
                cutter.transform.position = new Vector3(120.8f, 30.5f, 245f);
                c.flg_update = false;
                elephant.SetActive(true);
                cutter.SetActive(true);
            }
        }
        if (level==1)
        {
            c.flg_update = true;
            if(Vector3.Distance(elephant.transform.position, cutter.transform.position)<=25 && !level1comp)
            {
                //VideoPlayer = FindObjectOfType<videoplay>();

                c.s_time = Time.time;
                level1comp = true;
                level += 1;
/*                axe.enabled = true;
                boss_r1.enabled = true;
                boss_r2.enabled = true;
                boss_r3.enabled = true;
                boss_r4.enabled = true;
                tiger_r.enabled = true;*/
                e1.gameObject.SetActive(true);
                e2.gameObject.SetActive(true);
                e1.transform.position = e1.start_pos;
                e1.transform.Rotate(Vector3.up, 180);
                e1.do_walk = 1;
                e2.transform.position = e2.start_pos;
                e2.transform.Rotate(Vector3.up, 180);
                e2.do_walk = 1;

                elephant.SetActive(false);
                cutter.SetActive(false);
                c.flg_update = false;
                transform.position = new Vector3(211.75f, 21.51f, 255.9f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                CameraPos.position = transform.position + transform.forward * 2 + Vector3.up * 5;
                CameraPos.rotation = transform.rotation;
                onElephant = false;
                if (Vector3.Angle(transform.up, Vector3.up) > 60.0f)
                {
                    transform.up = Vector3.up;
                }
                //VideoPlayer = FindObjectOfType<videoplay>();
                //StartCoroutine(VideoPlayer2.PlayVideo("Mission1Completed"));
                StartCoroutine(VideoPlayer3.PlayVideo("vid2"));
            }
        }
        if (level == 2 && !VideoPlayer3.videoPlayer.isPlaying)
        {
            if (Vector3.Angle(e1.gameObject.transform.up, Vector3.up) > 60.0f)
            {
                e1.gameObject.transform.up = Vector3.up;
            }
            if (Vector3.Angle(e2.gameObject.transform.up, Vector3.up) > 60.0f)
            {
                e2.gameObject.transform.up = Vector3.up;
            }

            if (!e1.gameObject.activeSelf && !e2.gameObject.activeSelf)
            {
                axe.enabled = true;
                boss_r1.enabled = true;
                boss_r2.enabled = true;
                boss_r3.enabled = true;
                boss_r4.enabled = true;
                tiger_r.enabled = true;
                // AT game end call StartCoroutine(VideoPlayer4.PlayVideo("TheEND"));
            }
            if (e1.gameObject.activeSelf && e1.do_walk > 2 && Vector3.Distance(transform.position, e1.transform.position) <= 25)
            {
                Debug.Log("You got caught");
                transform.position = new Vector3(211.75f, 21.51f, 255.9f);
                if (!e2.gameObject.activeSelf)
                {
                    e2.gameObject.SetActive(true);
                    e2.transform.position = e2.start_pos;
                    //e2.transform.Rotate(Vector3.up, 180);
                    e2.do_walk = 1;
                }
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (e2.gameObject.activeSelf && e2.do_walk > 2 && Vector3.Distance(transform.position, e2.transform.position) <= 25)
            {
                Debug.Log("You got caught");
                transform.position = new Vector3(211.75f, 21.51f, 255.9f);
                if (!e1.gameObject.activeSelf)
                {
                    e1.gameObject.SetActive(true);
                    e1.transform.position = e1.start_pos;
                    e1.transform.Rotate(Vector3.up, 180);
                    e1.do_walk = 1;
                }
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetKeyDown("q"))
            {
                if (e1.do_walk <= 2 && Vector3.Distance(transform.position, e1.transform.position) <= 10)
                {
                    e1.gameObject.SetActive(false);
                }
                else if (e2.do_walk <= 2 && Vector3.Distance(transform.position, e2.transform.position) <= 10)
                {
                    e2.gameObject.SetActive(false);
                }
            }
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