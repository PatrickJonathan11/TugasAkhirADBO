using UnityEngine;
using System.Collections;

public class DeadMenu : MonoBehaviour {

	public string mainMenu;

	public void restartGame(){
		FindObjectOfType<DeadAndRestart> ().reset();
	}

	public void quitToMain(){
		Application.LoadLevel (mainMenu);
	}
}
