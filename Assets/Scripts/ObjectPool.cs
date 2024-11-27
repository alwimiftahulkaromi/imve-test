using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	public GameObject objectPrefab;
	public int initialPoolSize = 20;

	private Queue<GameObject> pool = new Queue<GameObject>();

	void Start()
	{
		for (int i = 0; i < initialPoolSize; i++)
		{
			GameObject obj = Instantiate(objectPrefab, transform);
			obj.SetActive(false);
			pool.Enqueue(obj);
		}
	}

	public GameObject GetObject(Vector3 position)
	{
		GameObject obj;
		if (pool.Count > 0)
		{
			obj = pool.Dequeue();
		}
		else
		{
			obj = Instantiate(objectPrefab, transform);
		}

		obj.transform.position = position;
		obj.SetActive(true);
		return obj;
	}

	public void ReturnObject(GameObject obj)
	{
		obj.SetActive(false);
		obj.transform.SetParent(transform);
		pool.Enqueue(obj);
	}
}
