using UnityEngine;
using System.Collections;

public class Troubles : GameActor {

    public float rotateSpeed;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rotateSpeed;
	}
	
}
