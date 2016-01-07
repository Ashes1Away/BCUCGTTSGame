using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed;
	bool grounded = false;
	bool jump = false;
	public int maxJumpHeight;
	int currentJumpHeight;
	Vector2 translation;
	public int gravity;

	// Use this for initialization
	void Start () {
		currentJumpHeight = maxJumpHeight;
	}
	
	// Update is called once per frame
	void Update (){
		#region movement
		translation = new Vector2(0,translation.y);
		translation.x = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		//translation.y = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		#endregion movement

		#region jump
		if(Input.GetButtonDown("Jump") && grounded)
		{
			jump = true;
		}
		if(jump)
		{
			translation.y += currentJumpHeight;
			currentJumpHeight--;
			if(currentJumpHeight < -maxJumpHeight)
			{
				jump = false;
			}
		}
		#endregion jump
		translation.y -= gravity * Time.deltaTime;
		transform.Translate (translation);

	}

	#region Grounded status
	void OnTriggerEnter2D()
	{
		grounded = true;
	}
	
	void OnTriggerStay2D()
	{
		grounded = true;
	}
	
	void OnTriggerExit2D()
	{
		grounded = false;
	}
	#endregion Grounded status
}
