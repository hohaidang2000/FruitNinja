using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruits : MonoBehaviour
{
    [SerializeField] private List<GameObject> _fruits;
	[SerializeField] public Transform[] spawnPoints;
	// Start is called before the first frame update
	public float minDelay = .1f;
	public float maxDelay = 1f;
	float height;
	float width;

	void Start()
	{
		float height = Camera.main.orthographicSize * 2.0f;
		float width = height * Screen.width / Screen.height;
		StartCoroutine(Spawn());
	}

	IEnumerator Spawn()
	{
		while (true)
		{
			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);
			int spawnIndex = Random.Range(0, spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIndex];
			int i = Random.Range(0, _fruits.Count);
			float ran = Random.RandomRange(-width, width);
			GameObject spawnedFruit = Instantiate(_fruits[i], spawnPoint.transform.position,spawnPoint.rotation);
			spawnedFruit.AddComponent<BoxCollider>();
			spawnedFruit.AddComponent<Rigidbody>();
			spawnedFruit.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.up * 850);
			

			Destroy(spawnedFruit, 5f);
		}
	}

}
