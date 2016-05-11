using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// 游戏结束界面
/// </summary>
public class GameOverWin : MonoBehaviour {	
	
	public Text scoreText;

	public delegate void pressRDelegate ();
	public pressRDelegate pressRDelegateHandle;
		
	public void show(bool active){
		this.gameObject.SetActive (active);
	}
	
	public void setScore(int score){
		scoreText.text = score.ToString ();
	}

	public void pressR(){
		if (pressRDelegateHandle != null) {
			pressRDelegateHandle();
		}
	}
}
