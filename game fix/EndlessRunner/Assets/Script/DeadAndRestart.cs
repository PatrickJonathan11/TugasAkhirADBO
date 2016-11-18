using UnityEngine;
using System.Collections;

public class DeadAndRestart : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public PlayerController thePlayer;
	private Vector3 playerStartPoint;

	private ObstacleController obsController;

	private Destroyer[] list;

	public DeadMenu deadMenuScreen;

	// Use this for initialization
	/// <summary>
	/// method ini akan menyimpan letak awal platform dan player;
	/// </summary>
	void Start () {
		platformStartPoint = new Vector2(13.84f,-4.4f);
		playerStartPoint = thePlayer.transform.position;

		this.obsController = FindObjectOfType<ObstacleController> ();
	}
	/// <summary>
	/// method ini akan menghilankan player saat mati sehingga tidak ada dalam platform
	/// dan saat bersamaan akan memanggil tampilan dari DeadMenu
	/// </summary>
	public void RestartGame(){
		thePlayer.gameObject.SetActive (false);
		deadMenuScreen.gameObject.SetActive(true);

	}
	/// <summary>
	/// saat dipanggil akan DeadMenu akan ditutup dan akan mengulang semua arena dari awal
	/// 
	/// </summary>
	public void reset(){
		deadMenuScreen.gameObject.SetActive(false);
		list = FindObjectsOfType<Destroyer> ();
		int i;
		for(i = 0; i< list.Length; i++){
			Destroy(list[i].gameObject);
		}
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		obsController.reStart ();
		thePlayer.setToStart ();
		thePlayer.gameObject.SetActive (true);
	}
}
