using UnityEngine;

public class EndTrigger : MonoBehaviour
{
	void OnTriggerEnter(Collider other) => FindObjectOfType<GameManager>().CompleteLevel();
}
