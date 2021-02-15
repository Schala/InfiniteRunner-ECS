using UnityEngine;

public class AcornBehavior : MonoBehaviour
{
	public Rigidbody acornRigidbody;
	public float lifetime;

	void OnCollisionEnter(Collision other)
	{
		GetComponent<AudioSource>().pitch = Random.value;
		GetComponent<AudioSource>().Play();
		acornRigidbody.AddForce(0, Random.value * 10, 0, ForceMode.Impulse);
	}

	void Start() => Destroy(gameObject, lifetime);
}
