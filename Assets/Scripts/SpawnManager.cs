using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[Header("Spawn Settings")]
	public GameObject enemyPrefab;
	public GameObject obstaclePrefab;
	public Transform player;
	public Transform enemyParent;
	public Transform obstacleParent;
	public Vector2 groundSize = new Vector2(99, 99);
	public int initialObstacleCount = 10;
	public float spawnInterval = 5f;
	public float minDistanceFromPlayer = 10f;
	public float obstacleSize = 2f;
	public float fixedYPosition = 1f;
	public ObjectPool enemyPool;

	private List<Vector3> obstaclePositions = new List<Vector3>();

	private void Start()
	{
		if (enemyParent == null)
		{
			GameObject enemyParentObject = new GameObject("Enemies");
			enemyParent = enemyParentObject.transform;
		}

		if (obstacleParent == null)
		{
			GameObject obstacleParentObject = new GameObject("Obstacles");
			obstacleParent = obstacleParentObject.transform;
		}
		for (int i = 0; i < initialObstacleCount; i++)
		{
			SpawnObstacle();
		}

		InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval);
	}

	private void SpawnEnemy()
	{
		Vector3 spawnPosition;

		do
		{
			spawnPosition = GetRandomSpawnPosition();
		}
		while (!IsPositionValid(spawnPosition));

		GameObject enemy = enemyPool.GetObject(spawnPosition);

		if (enemy != null)
		{
			enemy.transform.position = new Vector3(spawnPosition.x, fixedYPosition, spawnPosition.z);
			enemy.transform.rotation = Quaternion.identity;
			enemy.transform.parent = enemyParent;

			enemy.SetActive(true);
		}
		else
		{
			Debug.LogWarning("Pool kehabisan objek!");
		}
	}

	private void SpawnObstacle()
	{
		Vector3 spawnPosition;

		do
		{
			spawnPosition = GetRandomSpawnPosition();
		}
		while (Vector3.Distance(spawnPosition, player.position) < minDistanceFromPlayer ||
			   !IsPositionValid(spawnPosition));

		GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
		obstacle.transform.position = new Vector3(spawnPosition.x, fixedYPosition, spawnPosition.z);
		obstacle.transform.parent = obstacleParent;

		obstaclePositions.Add(spawnPosition);
	}

	private Vector3 GetRandomSpawnPosition()
	{
		float x = Random.Range(-groundSize.x / 2, groundSize.x / 2);
		float z = Random.Range(-groundSize.y / 2, groundSize.y / 2);
		float y = 0;

		return new Vector3(x, 0, z);
	}

	private bool IsPositionValid(Vector3 position)
	{
		Collider[] colliders = Physics.OverlapBox(position, Vector3.one * (obstacleSize / 2));
		foreach (var collider in colliders)
		{
			if (collider.CompareTag("Obstacle"))
			{
				return false;
			}
		}
		return true;
	}
}
