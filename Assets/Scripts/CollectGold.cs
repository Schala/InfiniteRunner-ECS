using UnityEngine;

public class CollectGold : MonoBehaviour
{
	public float speed;
	void Update() => transform.Rotate(Vector3.forward, speed * Time.deltaTime);
	void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Player") return;
		FindObjectOfType<GameManager>().IncreaseScore();
		Destroy(gameObject);
	}
}
