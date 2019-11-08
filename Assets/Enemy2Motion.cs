using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Motion : MonoBehaviour
{


    public float movementSpeed = 5.0f;
    public Animator animator;
    public RuntimeAnimatorController anim_idle;
    public RuntimeAnimatorController anim_walk;
    public RuntimeAnimatorController anim_jump;
    public float hold_for = 5.0f;
    public float max_dist = 40.0f;
    public int do_walk = 1;
    public Vector3 start_pos;
    private float s_time;
    private Vector3 targetAngles;
    // Start is called before the first frame update
    void Start()
    {
        animator.runtimeAnimatorController = anim_walk;
        start_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (do_walk == 1)
        {
            // Forward
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
            if (Vector3.Distance(transform.position, start_pos) >= max_dist)
            {
                animator.runtimeAnimatorController = anim_idle;
                do_walk = 2;
                s_time = Time.time;
            }
        }
        else if (do_walk == 2)
        {
            // Halt
            float cur_time = Time.time;
            if (cur_time - s_time >= hold_for)
            {
                animator.runtimeAnimatorController = anim_walk;
                do_walk = 3;
                //targetAngles = transform.eulerAngles + 180f * Vector3.up;
                //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 1* Time.deltaTime);
                transform.Rotate(Vector3.up, 180);
            }

        }
        else if (do_walk == 3)
        {
            // Stop
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
            if (Vector3.Distance(transform.position, start_pos) <= 5.0)
            {
                animator.runtimeAnimatorController = anim_idle;
                do_walk = 4;
                s_time = Time.time;
            }

        }
        else if (do_walk == 4)
        {
            // Halt
            float cur_time = Time.time;
            if (cur_time - s_time >= hold_for)
            {
                animator.runtimeAnimatorController = anim_walk;
                do_walk = 1;
                //targetAngles = transform.eulerAngles + 180f * Vector3.up;
                //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 1* Time.deltaTime);
                transform.Rotate(Vector3.up, 180);
            }
        }
    }
}
