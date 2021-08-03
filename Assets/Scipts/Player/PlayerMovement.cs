using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
	[SerializeField] Animator playerAnim;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	// Update is called once per frame
	void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		playerAnim.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			playerAnim.SetBool("isJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
			playerAnim.Play("PlayerSlashing");
		}
        if (Input.GetButtonDown("Test")) 
		{
			playerAnim.Play("Player_Sliding");
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	public void OnLanding() 
	{
		playerAnim.SetBool("isJumping", false);
	}
}