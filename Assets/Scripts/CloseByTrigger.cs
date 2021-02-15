using UnityEngine;

public class CloseByTrigger : MonoBehaviour
{
	public AudioSource gameManagerAudio;
	void Start()
	{
		Time.timeScale = 1f;
		Time.fixedDeltaTime = Time.timeScale * .02f;
		gameManagerAudio.pitch = 1f;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Obstacle") return;
		Time.timeScale = 0.3f;
		Time.fixedDeltaTime = Time.timeScale * .02f;
		gameManagerAudio.pitch = 0.3f;
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag != "Obstacle") return;
		Time.timeScale = 1f;
		Time.fixedDeltaTime = Time.timeScale * .02f;
		gameManagerAudio.pitch = 1f;
	}
}
