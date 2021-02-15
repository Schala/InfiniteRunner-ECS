using UnityEngine;

public class ThingSpawner : MonoBehaviour
{
	public float frequency;
	public GameObject prefab;
	float startFrequency;

	void Start() => startFrequency = frequency;

	void Update()
    {
        if (frequency > 0f)
			frequency -= Time.deltaTime;
		else
		{
			Instantiate(prefab, transform.position, Random.rotation);
			frequency = startFrequency;
		}
    }
}
