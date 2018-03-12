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
    float rotateSpeed = 20f;



    private void Start()
    {

    }

    private void Update()
    {
        shield.transform.RotateAround(Player.transform.position, Vector3.down, rotateSpeed * Time.deltaTime);
    }
}
