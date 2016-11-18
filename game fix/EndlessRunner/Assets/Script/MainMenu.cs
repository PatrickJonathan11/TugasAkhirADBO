using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public string playScene;

	/// <summary>
	/// method play jika dijalankan akan memasukki permainan dan mulai bermain
	/// </summary>
	public void play(){
		Application.LoadLevel (playScene);
	}

	/// <summary>
	/// method quit digunakan jika kita sudah ingin berhenti bermain dan
	/// menutup aplikasi
	/// </summary>
	public void quit(){
		Application.Quit ();
	}

}
