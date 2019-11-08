using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterMotion : MonoBehaviour
{


    public float movementSpeed = 5.0f;
    public Animator animator;
    public RuntimeAnimatorController anim_idle;
    public RuntimeAnimatorController anim_walk;
    public RuntimeAnimatorController anim_jump;
    public float hold_for = 1.0f;
    public float max_dist = 40.0f;
    public int do_walk = 1;
    public Vector3 start_pos;
    public float s_time;
    public bool flg_update = false;
    private Vector3 targetAngles;
    // Start is called before the first frame update
    void Start()
    {
        animator.runtimeAnimatorController = anim_idle;
        start_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Angle(transform.up, Vector3.up) > 60.0f)
        {
            transform.up = Vector3.up;
        }
        if (flg_update)
        {
            //Debug.Log("Here");
            if (do_walk == 1)
            {
                // Forward
                animator.runtimeAnimatorController = anim_walk;
                transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
            }
            else if (do_walk == 2)
            {
                // Halt
                float cur_time = Time.time;
                if (cur_time - s_time >= hold_for)
                {
                    animator.runtimeAnimatorController = anim_walk;
                    do_walk = 1;
                    //targetAngles = transform.eulerAngles + 180f * Vector3.up;
                    //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 1* Time.deltaTime);
                    //transform.Rotate(Vector3.up, 180);
                }
            }
        }
    }
}
