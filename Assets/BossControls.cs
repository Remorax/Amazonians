using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControls : MonoBehaviour
{
    public GameObject BossGun, Boss;
    public GameObject Soldier;
    public BossGun weapon;
    public Renderer boss_r1;
    public Renderer boss_r2;
    public Renderer boss_r3;
    public Renderer boss_r4;
    public float health = 500f;
    public int frame = 0;
    public videoplay VideoPlayer4;

    //// Start is called before the first frame update
    void Start()
    {
        BossGun.transform.position = Boss.transform.position + 3.5f*Vector3.up + 1.5f*Vector3.right + 0.5f*Vector3.forward;
        BossGun.transform.rotation = Boss.transform.rotation;
        BossGun.transform.parent = Boss.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!boss_r1.enabled)
            return;
        Vector3 relativePos = Soldier.transform.position - Boss.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        if (frame % 20 == 0)
            Boss.transform.rotation = rotation;
        if (frame % 10 == 0)
            weapon.Shoot();

        frame += 1;
        if (Vector3.Angle(transform.up, Vector3.up) > 60.0f)
        {
            transform.up = Vector3.up;
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.LogWarning("Boss damage" + health);
        if (health <= 0f)
        {
            Debug.LogWarning("Boss dead");
            boss_r1.enabled = false;
            boss_r2.enabled = false;
            boss_r3.enabled = false;

            boss_r4.enabled = false;
            StartCoroutine(VideoPlayer4.PlayVideo("TheEND"));
        }
    }
}
