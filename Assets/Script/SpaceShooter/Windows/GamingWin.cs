using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// 游戏过程分数显示界面
/// </summary>
public class GamingWin : MonoBehaviour {
	
	public Text scoreText;

	public void show(bool active){
		this.gameObject.SetActive (active);
	}

	public void updateScore(int score){
		scoreText.text = score.ToString ();
	}
}

