using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string mainMenu;
	public GameObject pauseMenu;

	public void pauseGame(){
		pauseMenu.SetActive (true);
		Time.timeScale = 0f;
	}

	public void resumeGame(){
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
	}

	/// <summary>
	/// method ini akan ditampilkan pada saat DeadMenu diSet menjadi Active
	/// akan di tampilkan dalam bentuk button dan akan
	/// memanggil method reset dari DeadAndRestart class
	/// </summary>
	public void restartGame(){
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		FindObjectOfType<DeadAndRestart> ().reset();
	}
	/// <summary>
	/// method ini akan ditampilkan pada saat DeadMenu diSet menjadi Active
	/// akan di tampilkan dalam bentuk button dan akan
	/// kembali ke menu utama
	/// </summary>
	public void quitToMain(){
		Time.timeScale = 1f;
		Application.LoadLevel (mainMenu);
	}
}
