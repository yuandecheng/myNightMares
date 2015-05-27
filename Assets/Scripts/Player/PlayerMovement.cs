 using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidBody;

    int floorMask;
    float camRayLength = 100f; 

	Vector2 direct;

    void Awake ()
    {
    	floorMask = LayerMask.GetMask ("Floor");
    	anim = GetComponent<Animator>();
    	playerRigidBody = GetComponent<Rigidbody>();
    }

	void OnEnable ()
	{
		EasyJoystick.On_JoystickMove += On_JoystickMove;
		EasyJoystick.On_JoystickTouchUp += On_JoystickTouchUp;
	}

	public void On_JoystickMove (MovingJoystick move)
	{
		direct = move.joystickAxis;
	}

	public void On_JoystickTouchUp (MovingJoystick move)
	{
		direct = Vector2.zero;
	}

    void FixedUpdate ()
    {
    	//float h = Input.GetAxisRaw ("Horizontal");
    	//float v = Input.GetAxisRaw ("Vertical");

    	Move (direct.x, direct.y);
    	Turning ();
    	Animating (direct.x, direct.y);
    }

    void Move (float h, float v)
    {
    	movement.Set (h, 0f, v);

    	movement = movement.normalized * speed * Time.deltaTime;

    	playerRigidBody.MovePosition (transform.position + movement);
    }

    void Turning ()
    {
//    	Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
//
//    	RaycastHit floorHit;
//
//    	if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
//    	{
//    		Vector3 playerToMouse = floorHit.point - transform.position;
//    		playerToMouse.y = 0f;
//
//    		Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
//    		playerRigidBody.MoveRotation (newRotation);
//    	}

		Vector3 playerToMouse = new Vector3(direct.x, 0f, direct.y);

		if(playerToMouse != Vector3.zero)
		{
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidBody.MoveRotation (newRotation);
		}
	}
	
	void Animating (float h, float v)
    {
    	bool walking = h != 0f || v != 0f;
    	anim.SetBool ("isWalking", walking); 
    }
}
