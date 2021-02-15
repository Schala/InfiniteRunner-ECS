using UnityEngine;

public class CorridorGeneration : MonoBehaviour
{
	public GameObject[] selection;

    void Start()
    {
		System.Random prng = new System.Random(gameObject.GetInstanceID());
		Vector3 pos = transform.position;
		int rnd = prng.Next(0, selection.Length);
		GameObject corridor = selection[rnd];

		switch (rnd)
		{
			case 0:
			{
				pos.x += 1.85f;
				pos.y = 3.414253f;
			}
			break;
			case 1:
			{
				pos.x += 10f;
				pos.y = 7.962384f;
			}
			break;
			case 2:
			{
				pos.y = 2.597691f;
			}
			break;
			case 3:
			{
				pos.x = -5f;
				pos.y = -2.511385f;
			}
			break;
		}
        Instantiate(selection[rnd], pos, Quaternion.identity);
    }
}
