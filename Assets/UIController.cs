using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
	//ゲームオーバーテキスト
	private GameObject gameoverText;
	//走行距離テキスト
	private GameObject runlengthText;
	//走った距離
	private float len = 0;
	//走る速度
	private float speed = 0.03f;
	//ゲームオーバーの判定
	private bool isGameOver = false;

	// Use this for initialization
	void Start () {
		//シーンビューからオブジェクトの実体を検索する
		this.gameoverText = GameObject.Find("GameOverText");
		this.runlengthText = GameObject.Find ("RunLength");

	}
	
	// Update is called once per frame
	void Update () {
		if (this.isGameOver == false) {
			//走った距離を更新する
			this.len += this.speed;

			//走った距離を表示する
			this.runlengthText.GetComponent<Text> ().text = "Distance: "
			+ len.ToString ("F2") + "m";
		}
		//ゲームオーバーになった場合
		if (this.isGameOver) {
			//クリックされたらシーンをロードする
			if (Input.GetMouseButtonDown (0)) {
				//GameSceneを読み込む
				SceneManager.LoadScene ("GameScene");
			}
		}
		
	}
	public void GameOver(){
		//ゲームオーバーになった時に、画面上にゲームオーバーを表示する
		this.gameoverText.GetComponent<Text> ().text = "GameOver";
		this.isGameOver = true;
	}
}
