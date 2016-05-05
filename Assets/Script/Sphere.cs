using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sphere : MonoBehaviour {

	public int speed = 1;
	public Text tex;

	private Vector3 vect = Vector3.zero;
	private int score = 0;


	// Use this for initialization
	void Start () {
	
		tex.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		vect.x = Input.GetAxis ("Horizontal");
		vect.z = Input.GetAxis ("Vertical");
		gameObject.transform.Translate (vect * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Pick Up") {
			col.gameObject.SetActive(false);
			setScore();
		}
	}

	private void setScore(){
		score++;
		tex.text = score.ToString ();
	}
}
