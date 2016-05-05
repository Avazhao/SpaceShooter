using UnityEngine;
using System.Collections;

public class Trouble : MonoBehaviour {

	public float speed;

	public int score;

	public GameObject BoltExplore;
	public GameObject PlayerExplore;

	public delegate void AddScoreDelegate(int score);
	public AddScoreDelegate AddScoreDelegateHandle;

	public delegate void GameOverDelegate();
	public GameOverDelegate GameOverDelegateHandle;

	// Use this for initialization
	void Start () {

		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * speed;
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Baundry") {
			return;
		}


		Instantiate (BoltExplore, transform.position, transform.rotation);

		Destroy (this.gameObject);
		Destroy (col.gameObject,0.01f);

		if (col.gameObject.tag == "Player") {
			Debug.Log (gameObject.GetInstanceID ());
			Instantiate (PlayerExplore, transform.position, transform.rotation);
			gameOver ();
		} else {
			addScore (score);
		}

	}

	public void addScore(int scro){
		if (AddScoreDelegateHandle != null) {
			AddScoreDelegateHandle(scro);
		}
	}

	public void gameOver(){
		if (GameOverDelegateHandle != null) {
			GameOverDelegateHandle();
		}
	}
}
