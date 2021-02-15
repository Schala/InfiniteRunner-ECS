using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody playerRB;
	public float speed;
	public float strafeSpeed = 200f;
	public float jumpStrength;
	public Vector3 centerOfMass;
	bool canJump = true;

	void Start() => GetComponent<Rigidbody>().centerOfMass = centerOfMass;

	void Update()
	{
		Keyboard keyboard = Keyboard.current;
		if (keyboard == null) return;
		if (!keyboard.spaceKey.isPressed || !canJump) return;

		playerRB.AddForce(0, jumpStrength, 0, ForceMode.Impulse);
		canJump = false;
	}

	void FixedUpdate()
    {
		Keyboard keyboard = Keyboard.current;
		if (keyboard == null) return;

        playerRB.AddForce(0, 0, speed * Time.deltaTime);

		if (keyboard.aKey.isPressed) playerRB.AddForce(-strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		if (keyboard.dKey.isPressed) playerRB.AddForce(strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

		if (playerRB.position.y < -1f) FindObjectOfType<GameManager>().EndGame();
    }

	void OnCollisionEnter(Collision other)
	{
		canJump = true;
		
		if (other.collider.tag == "Obstacle")
		{
			enabled = false;
			FindObjectOfType<GameManager>().GetComponent<AudioSource>().Stop();
			GetComponent<AudioSource>().Play(); 
			FindObjectOfType<GameManager>().EndGame();
		}
	}
}
