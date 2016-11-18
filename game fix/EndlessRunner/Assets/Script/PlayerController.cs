using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float jumpForce;
	public float jumpHoldTime;
	private float jumpHoldTimeCounter;

	public float moveSpeed;
	public float speedMultiplier;
	public float jarakTempuh;
	private float nambahJarak;

	private Rigidbody2D myRigidBody;

	public bool grounded;
	public bool slide;
	public LayerMask whatIsGround;

	private Collider2D myCollider;
	private Animator myAnimator;

	private BoxCollider2D boxCol;
	private Vector3 ukuranAwal;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> ();

		nambahJarak = jarakTempuh;
		jumpHoldTimeCounter = jumpHoldTime;

		boxCol = GetComponent<BoxCollider2D>();
		ukuranAwal = boxCol.size;
	}
		
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);
		if (transform.position.x > nambahJarak && moveSpeed < 30) {
			this.speed ();
		}

		myRigidBody.velocity = new Vector2 (moveSpeed,myRigidBody.velocity.y);

		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Space)) {
			if (grounded == true) {
				this.jump ();
			}
		}

		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.Space)) {
			if (jumpHoldTimeCounter > 0) {
				this.jumpHold ();
			}
		}
		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.Space)) {
			this.jumpRelease ();
		}

		if (Input.GetKey ("down")) {
				boxCol.size = new Vector3 (0.5f, 0.5f, 0);
				slide = true;
		} else {
			boxCol.size = ukuranAwal;
			slide = false;
		}
		myAnimator.SetFloat ("Speed", myRigidBody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
		myAnimator.SetBool ("Slide", slide);
	}

	/// <summary>
	/// mengatur kecepatan karakter
	/// </summary>
	void speed(){
		moveSpeed = moveSpeed * speedMultiplier;
		nambahJarak += jarakTempuh;
		jarakTempuh = jarakTempuh * speedMultiplier;
	}

	/// <summary>
	/// mengatur cara karakter melompat
	/// </summary>
	private void jump(){
		myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
		jumpHoldTimeCounter=jumpHoldTime;
	}

	/// <summary>
	/// mengatur lama melompat jika tombol di tahan
	/// </summary>
	void jumpHold(){
		myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
		jumpHoldTimeCounter -= Time.deltaTime;
	}

	/// <summary>
	/// mengatur agar tidak dapat melompat lagi jika tombol di lepas
	/// </summary>
	void jumpRelease(){
		jumpHoldTimeCounter = 0;
	}

	/// <summary>
	/// method ini bekerja seperti method start , tetapi digunakan saat merestart game dalam dead menu
	/// </summary>
	public void setToStart(){
		this.moveSpeed = 10;
		this.jarakTempuh = 35;
		this.boxCol.size = ukuranAwal;
		this.Start();
	}
}
