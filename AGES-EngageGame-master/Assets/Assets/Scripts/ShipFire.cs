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
    //public Transform bulletSpawn2;

    void Update()
    {


        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        //transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);

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

    //void Fire2()
    //{
    //    var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn2.position, bulletSpawn.rotation);

    //    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * BulletSpeed;

    //    Destroy(bullet, 2.0f);
    //}
}
