using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Vector3 rotation ;
	// Use this for initialization
	void Start () {
		rotation = new Vector3 (0, 0, -60);
	}
	
	// Update is called once per frame
	void Update () {
	
		gameObject.transform.Rotate (rotation * Time.deltaTime,Space.World);
	}
}
