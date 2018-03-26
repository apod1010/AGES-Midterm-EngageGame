using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFire : MonoBehaviour {

    [SerializeField]
    public float BulletSpeed = 6;

    [SerializeField]
    public float BulletCoolDown = 2f;
    private float NextFire;

    [HideInInspector]
    public bool canFire = true;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;


    void Update()
    {


        if (Input.GetButtonDown("Fire1") && canFire && Time.time > NextFire)
        {
            NextFire = Time.time + BulletCoolDown;
            Fire();
        }
    }

    void Fire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);



        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * BulletSpeed;

        Destroy(bullet, 2.0f);
    }

}
