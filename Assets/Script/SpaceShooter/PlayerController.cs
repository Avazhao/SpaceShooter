using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	/// <summary>
	/// 飞船移动速度
	/// </summary>
	public float speed = 1f;
	/// <summary>
	/// 飞船倾斜角度
	/// </summary>
	public float tlit = 0f;
	/// <summary>
	/// 子弹发射间隔
	/// </summary>
	public float shootRate = 0;
	/// <summary>
	/// 子弹
	/// </summary>
	public GameObject bolt;
	/// <summary>
	/// 发射出的子弹存放地方
	/// </summary>
	public Transform BoltGrid;

	/// <summary>
	/// 上次发射子弹的时间
	/// </summary>
	private float lastBoltTime = 0;


	private Vector3 vel = Vector3.zero;
	private Rigidbody rig;
	public Baundry bau;



	// Use this for initialization
	void Start () {
	
		rig = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButton ("Fire1") && Time.time > lastBoltTime + shootRate) {
			lastBoltTime = Time.time;
			GameObject go = Instantiate(bolt,BoltGrid.position,BoltGrid.rotation) as GameObject; 
			go.transform.SetParent(BoltGrid);
		}
	}

	void FixedUpdate(){
		vel.x = Input.GetAxis("Horizontal");
		vel.z = Input.GetAxis("Vertical");
		vel.y = 0.0f;

		//移动飞船
		rig.velocity = vel * speed;
		//倾斜飞船
		rig.rotation = Quaternion.Euler (0, 0, vel.x * tlit);
		//限制飞船移动的位置
		rig.position = new Vector3 (Mathf.Clamp (rig.position.x, bau.XMin, bau.XMax), 0, Mathf.Clamp (rig.position.z, bau.YMin, bau.YMax));
	}
}

/// <summary>
/// 飞船移动边界
/// </summary>
[System.Serializable]
public class Baundry
{
	public float XMin,XMax,YMin,YMax;
}
