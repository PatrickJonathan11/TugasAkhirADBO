using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {
	public GameObject thePlatform;
	public Transform generationPoint;

	private float platformWidth;

	// Use this for initialization
	/// <summary>
	/// method ini seperti constructor untuk menentukan collider platform dan posisinya. 
	/// </summary>
	void Start () {
		platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;
		transform.position = new Vector3 (platformWidth-8.11f,thePlatform.transform.position.y,transform.position.z);
	}

	// Update is called once per frame
	/// <summary>
	/// method ini akan memanggil method generate jika sudah memenuhi syarat generationPoint
	/// </summary>
	void Update () {
		if (transform.position.x <= generationPoint.position.x) {
			this.generate ();
		}
	}

	//method untuk menambah platform secara terus menerus
	/// <summary>
	/// method ini digunakan untuk menambah platform/meng-kloning platform secara terus-menerus 
	/// </summary>
	void generate(){
		transform.position = new Vector3 (transform.position.x + platformWidth, transform.position.y, transform.position.z);

		Instantiate (thePlatform, transform.position, transform.rotation);
	}


}
