using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private DeadAndRestart deadAndRestart;

	//private GameObject destroyPoint;

	void Start(){
		this.deadAndRestart = FindObjectOfType<DeadAndRestart> ();
		//this.destroyPoint =  GameObject.Find ("DestroyPoint");
	}

	/// <summary>
	/// method ini dipanggil jika kedua collider(player dan obstacle) bertemu dan
	/// isTrigger dalam keadaan false
	/// akan memindahkan kita ke layar dead menu
	/// </summary>
	/// <param name="other">Other.</param>
	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Player") {
			deadAndRestart.RestartGame ();
		}
	}

	/*
	void Update () {
		this.destroyObject ();
	}
	
	public void destroyObject(){
		if (transform.position.x < destroyPoint.transform.position.x) {
			Destroy (gameObject);	
		}
	}*/
}
