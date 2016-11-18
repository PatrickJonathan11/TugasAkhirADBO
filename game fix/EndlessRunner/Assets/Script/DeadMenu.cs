using UnityEngine;
using System.Collections;

public class DeadMenu : MonoBehaviour {

	public string mainMenu;
	/// <summary>
	/// method ini akan ditampilkan pada saat DeadMenu diSet menjadi Active
	/// akan di tampilkan dalam bentuk button dan akan
	/// memanggil method reset dari DeadAndRestart class
	/// </summary>
	public void restartGame(){
		FindObjectOfType<DeadAndRestart> ().reset();
	}
	/// <summary>
	/// method ini akan ditampilkan pada saat DeadMenu diSet menjadi Active
	/// akan di tampilkan dalam bentuk button dan akan
	/// kembali ke menu utama
	/// </summary>
	public void quitToMain(){
		Application.LoadLevel (mainMenu);
	}
}
