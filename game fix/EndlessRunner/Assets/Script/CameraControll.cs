﻿
using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {
	public PlayerController thePlayer;

	private Vector3 lastPlayerPosition;
	private float distanceToMove;

	/// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		lastPlayerPosition = thePlayer.transform.position;
	}
	
	/// <summary>
	///  method ini akan membuat kamera mengikuti gerakan player saat bergerak dan akan tetap stibil di tengah
	///  walaupun player melompat
	/// </summary>
	void Update () {
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);

		lastPlayerPosition = thePlayer.transform.position;
	}
}
