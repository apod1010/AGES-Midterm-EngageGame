using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour 
{
    [SerializeField]
    GameObject shield;
    [SerializeField]
    GameObject Player;
    [SerializeField]

    public AudioSource shieldAudio;

    private Player controllingPlayer_UseProperty;





    public float rotateSpeed = 40f;
    public float rotateIncrease = 10f;



    public Player ControllingPlayer
    {
        get { return controllingPlayer_UseProperty; }
        set
        {
            controllingPlayer_UseProperty = value;
            //UpdatePlayerIndexLabelText();
        }
    }

    private string FasterShieldName
    {
        get
        {
            return "Faster" + ControllingPlayer.PlayerNumber;
        }
    }

    private string SlowerShieldName
    {
        get
        {
            return "Slower" + ControllingPlayer.PlayerNumber;
        }
    }

    private void Start()
    {

    }

    private void Update()
    {
        shield.transform.RotateAround(Player.transform.position, Vector3.down, rotateSpeed * Time.deltaTime);
        
        if (Input.GetButtonDown(FasterShieldName))
        {
            rotateSpeed = rotateSpeed + rotateIncrease;
        }

        if (Input.GetButtonDown(SlowerShieldName))
        {
            rotateSpeed = rotateSpeed - rotateIncrease;
        }
    }

    private void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.tag == "Bullet")
        {

            Destroy(col.gameObject);
            shieldAudio.Play();
        }
    }
}
