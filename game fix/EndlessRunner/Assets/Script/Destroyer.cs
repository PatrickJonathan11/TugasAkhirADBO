using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
	public GameObject platformDestroy;
	// Use this for initialization
	/// <summary>
	/// method akan mencari DestrokyPoint, jika ditemukan maka method akan menghancurkan gameObject pada 
	/// DestroyPoint
	/// </summary>
	void Start () {
		platformDestroy = GameObject.Find ("DestroyPoint");
	}

	// Update is called once per frame
	/// <summary>
	/// method ini sebagai syarat,jika dipenuhi maka akan menghancurkan gameObject
	/// </summary>
	void Update () {
		if (transform.position.x < platformDestroy.transform.position.x) {
			Destroy (gameObject);	
		}
	}
}
