using UnityEngine;
using System.Collections;
/// <summary>
/// 定时自我摧毁
/// </summary>
public class DestroyBySelf : MonoBehaviour {

	public float time;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, time);
	}

}
