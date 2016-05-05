using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	/// <summary>
	/// 子弹飞行速度
	/// </summary>
	public float speed = 1;
	private Rigidbody rig;
	
	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody> ();
		rig.velocity = transform.forward * speed;
	}
	

}
