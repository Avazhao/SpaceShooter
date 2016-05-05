using UnityEngine;
using System.Collections;

public class DestroyByBaundry : MonoBehaviour {

	/// <summary>
	/// 对象退出盒子之后自动销毁
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerExit(Collider col){
		Destroy (col.gameObject);
		
	}
}
