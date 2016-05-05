using UnityEngine;
using System.Collections;

/// <summary>
/// 控制背景移动
/// </summary>
public class BGScroll : MonoBehaviour {

	public float speed;
	public float sizes;

	private Vector3 pos;
	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float mewPos = Mathf.Repeat (speed * Time.time, sizes);
		transform.position = pos + Vector3.forward * mewPos;
	}
}
