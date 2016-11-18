using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {
	
	[SerializeField]private GameObject[] obstacle = new GameObject[2];
	private int i;
	private Vector2 posNow;
	private Vector2 posNowBabi;

	// Use this for initialization
	void Start () {
		this.posNow = new Vector2 (Random.Range(20,31),-3.6f);
		this.transform.position = new Vector2(this.posNow.x-15f,this.transform.position.y);
		i = Random.Range (0, obstacle.Length);
		if (i == 0) {
			Instantiate (obstacle [i], posNow, Quaternion.identity);
		} else {
			this.posNowBabi = new Vector2 (posNow.x,Random.Range(-2.44f,0.4f));
			Instantiate (obstacle [i], posNowBabi, Quaternion.identity);
		}
	}

	/// <summary>
	/// method ini akan dipanggil jika karakter menyentuh collider maka 
	/// akan memanggil method CreateObstacle
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Character") {
			CreateObstacle ();
		}
	}

	/// <summary>
	/// method ini akan membuat sebuah obstacle baru (babi/api)
	/// tergantung pada nilai i
	/// </summary>
	void CreateObstacle(){
		this.posNow += Vector2.right * Random.Range(20,31);
		this.posNowBabi = new Vector2(this.posNow.x, Random.Range (-2.44f,0.4f));
		//Debug.Log (posNowBabi.y);
		this.transform.position = new Vector2(posNow.x-15f,this.transform.position.y);
		i = Random.Range (0, obstacle.Length);
		if (i == 0) {
			Instantiate (obstacle [i], posNow, Quaternion.identity);
		} else {
			Instantiate (obstacle [i], posNowBabi, Quaternion.identity);
		}
	}


	public void reStart(){
		this.Start ();
	}
}
