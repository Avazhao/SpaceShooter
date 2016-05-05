using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] tro;
	public int count;
	public Vector3 pos;
	public GameObject troGrid;
	public float waitTime;
	public float waitSecond;

	public GamingWin win_gaming;
	public GameOverWin win_gameOver;

	public GameObject player;

	private int score = 0;

	private bool gaming = false;



	// Use this for initialization
	void Start () {
		win_gameOver.pressRDelegateHandle = GameStart;
        Reset();
        GameState(true);
        StartCoroutine(RandomTrouble());

    }

	void Update(){
		if (!gaming&&Input.GetKeyDown(KeyCode.R)) {
			GameStart();
            
        }
	}

	/// <summary>
	/// 随机生成障碍
	/// </summary>
	/// <returns>The trouble.</returns>
	IEnumerator RandomTrouble(){
		yield return new WaitForSeconds (waitTime);
		while(true) {
			for(int i=0;i<count&&gaming;i++){
		    	GameObject go = Instantiate(tro[Random.Range(0,tro.Length)],new Vector3(Random.Range(-pos.x,pos.x),pos.y,pos.z),Quaternion.identity) as GameObject;
			//Debug.Log(go.GetInstanceID());
		    	Trouble to = go.GetComponent<Trouble>();
		    	to.AddScoreDelegateHandle = AddScoreDelegateHandle;
		    	to.GameOverDelegateHandle = GameOver;
		    	go.transform.SetParent(troGrid.transform);
				yield return new WaitForSeconds (waitSecond);
			}
			yield return new WaitForSeconds (waitTime);
		}
	}

	public void AddScoreDelegateHandle(int add){
		score += add;
		updateScore ();
	}

	private void updateScore(){
		win_gaming.updateScore (score);
	}

	private void Reset(){
		score = 0;
		updateScore ();
        win_gameOver.show(false);

        win_gaming.show(true);
        win_gaming.updateScore(score);

    }

	/// <summary>
	/// 游戏状态
	/// </summary>
	/// <param name="start">If set to <c>true</c> start.</param>
	private void GameState(bool start){
		gaming = start;
	}

	/// <summary>
	/// 游戏结束
	/// </summary>
	private void GameOver(){
		StartCoroutine (PlayIdleAnimations ());


	}

	IEnumerator PlayIdleAnimations(){
		yield return new WaitForSeconds (1);
       
        clearTro ();
		GameState (false);
		win_gaming.show (false);
		win_gameOver.show (true);
		win_gameOver.setScore (score);
		Debug.Log (score);
		//Time.timeScale = 0;
	}

	/// <summary>
	/// 游戏开始
	/// </summary>
	private void GameStart(){
		//Time.timeScale = 1;                
        Application.LoadLevel("SpaceShooter");
        Reset();
        GameState (true);
		StartCoroutine (RandomTrouble ());
		//Instantiate (player);
    }

	/// <summary>
	/// 清除剩余的障碍物
	/// </summary>
	private void clearTro(){
		Trouble[] tro = troGrid.GetComponentsInChildren<Trouble> ();
		for (int i=0; i<tro.Length; i++) {
			Destroy(tro[i].gameObject);
		}
	}
}
