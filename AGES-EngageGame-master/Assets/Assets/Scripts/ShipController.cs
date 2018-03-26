using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public float speed = 1f;
    public float rotationSpeed = 30f;
    //public bool activeControls;

    private new Rigidbody rigidbody;

    public AudioSource fire;

    [SerializeField]
    private int debugPlayerNumberOverride = 0;

    private Player controllingPlayer_UseProperty;

    [SerializeField]
    public float BulletSpeed = 6;

    [SerializeField]
    public float BulletCoolDown = 2f;
    private float NextFire;

    [HideInInspector]
    public bool canFire = true;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public Player ControllingPlayer
    {
        get { return controllingPlayer_UseProperty; }
        set
        {
            controllingPlayer_UseProperty = value;
            //UpdatePlayerIndexLabelText();
        }
    }


    //public void activateControls()
    //{
    //    if (Input.GetButton("Start"))
    //        activeControls = true;
    //}

    private float HorizontalInput
    {
        get { return Input.GetAxis(HorizontalInputName); }
    }

    private float VerticalInput
    {
        get { return Input.GetAxis(VerticalInputName); }
    }

    // You must configure the Unity Input Manager
    // to have an axis for each control for each supported player.
    // Begin numbering at 1, as Unity numbers "joysticks" beginning at 1.
    // "Joystick" means gamepad in real life...
    private string HorizontalInputName
    {
        get
        {
            return "Horizontal" + ControllingPlayer.PlayerNumber;
        }
    }

    private string VerticalInputName
    {
        get
        {
            return "Vertical" + ControllingPlayer.PlayerNumber;
        }
    }
    private string FireInputName
    {
        get
        {
            return "Fire" + ControllingPlayer.PlayerNumber;
        }
    }


    //private void UpdatePlayerIndexLabelText()
    //{
    //    playerNumberLabel.text = ControllingPlayer.PlayerNumber.ToString();
    //}

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

#if UNITY_EDITOR
        if (debugPlayerNumberOverride > 0)
        {
            ControllingPlayer = new Player(debugPlayerNumberOverride);
        }
#endif
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //activeControls = false;
    }

    void Update()
    {
        if (Input.GetButtonDown(FireInputName) && canFire && Time.time > NextFire)
        {
            NextFire = Time.time + BulletCoolDown;
            Fire();
        }
        //if (activeControls = true)
        HandleMovement();
    }

    void Fire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        fire.Play();

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * BulletSpeed;

        Destroy(bullet, 2.0f);
    }

    private void HandleMovement()
    {
        float rotation = Input.GetAxis(HorizontalInputName) * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);



        float v = Input.GetAxis(VerticalInputName) * speed * Time.deltaTime;

        transform.localPosition += transform.forward * v;

        Vector3 FORWARD = transform.TransformDirection(Vector3.forward);

        transform.localPosition += FORWARD * v;
    }
}
