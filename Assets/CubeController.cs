using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
	//キューブの移動速度
	private float speed = -0.2f;
	//消滅位置
	private float deadLine = -10;

	//AudioSourceを格納するための変数を宣言
	private	AudioSource	audioSource;
	//効果音を格納するための変数を宣言
	public	AudioClip	sound;			


	// Use this for initialization
	void Start () {
		// AudioSorceコンポーネントを取得し、変数に代入.
		audioSource	= gameObject.GetComponent< AudioSource >();
		// 鳴らす音(変数)を格納.
		audioSource.clip = sound;		
				

		
	}
	
	// Update is called once per frame
	void Update () {
		//キューブを移動させる
		transform.Translate(this.speed,0,0);

		//画面外に出たら破棄する
		if (transform.position.x < this.deadLine) {
			Destroy (gameObject);
		}
	}
	//衝突時に呼び出される関数
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "groundTag" || other.gameObject.tag == "cubeTag") {
			
			audioSource.Play ();		// 音を鳴らす.
		}
	}
}
