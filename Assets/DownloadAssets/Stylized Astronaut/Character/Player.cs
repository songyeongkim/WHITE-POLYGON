using UnityEngine;
using System.Collections;

public class Player : CComponent {

	private Animator anim;
	private CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;
	private Rigidbody rigidbody;

	public float speed = 600.0f;
	public float turnSpeed = 400.0f;
	public float gravity = 20.0f;
	public bool canMove = false;


	public override void Start () {

		controller = GetComponent <CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
		rigidbody = GetComponent<Rigidbody>();
	}

	public override void Update (){

		//충돌 시 밀림 및 떨림 방지
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;

		if (canMove)
        {
			if (Input.GetAxis("Vertical") != 0)
			{
				anim.SetInteger("AnimationPar", 1);
			}
			else
			{
				anim.SetInteger("AnimationPar", 0);
			}

			moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;


			float h = Input.GetAxisRaw("Horizontal");
			float v = Input.GetAxisRaw("Vertical");

			Walk(h, v);
			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			moveDirection.y -= gravity * Time.deltaTime;
		}	
	}

	public void Walk(float h, float v)
    {
		transform.position += transform.forward * v * speed * Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
		if (other.tag == "AreaBlock")
			canMove = false;
    }

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "AreaBlock")
			canMove = true;
	}
}
