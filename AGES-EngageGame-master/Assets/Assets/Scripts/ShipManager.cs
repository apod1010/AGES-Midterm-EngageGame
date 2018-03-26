using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour {

    public GameObject Instance;

    private ShipController controller;

    public void Setup()
    {
        controller = Instance.GetComponent<ShipController>();
    }

    public void DisableControl()
    {
        controller.enabled = false;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
