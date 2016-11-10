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
	public LayerMask whatIsGround;

	private Collider2D myCollider;

	private Animator myAnimator;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();

		myCollider = GetComponent<Collider2D> ();

		myAnimator = GetComponent<Animator> ();

		nambahJarak = jarakTempuh;

		jumpHoldTimeCounter = jumpHoldTime;
	}

	//mengatur kecepatan karakter
	void speed(){
		moveSpeed = moveSpeed * speedMultiplier;
		nambahJarak += jarakTempuh;
		jarakTempuh = jarakTempuh * speedMultiplier;
	}

	//mengatur cara karakter melompat
	void jump(){
		myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
		jumpHoldTimeCounter=jumpHoldTime;
	}

	//mengatur lama melompat jika tombol di tahan
	void jumpHold(){
		myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
		jumpHoldTimeCounter -= Time.deltaTime;
	}

	//mengatur agar tidak dapat melompat lagi jika tombol di lepas
	void jumpRelease(){
		jumpHoldTimeCounter = 0;
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
		myAnimator.SetFloat ("Speed", myRigidBody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
	}

}
