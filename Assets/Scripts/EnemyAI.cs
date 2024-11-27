using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	public Transform player;
	public float movementSpeed = 5f;
	public float chaseDistance = 50f;
	public float rotationSpeed = 5f;

	private Rigidbody rb;
	private Vector3 targetDirection;
	private bool isChasing = false;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		if (rb == null)
		{
			Debug.LogError("Rigidbody component is missing!");
		}

		if (player == null)
		{
			GameObject playerObject = GameObject.FindWithTag("Player");
			if (playerObject != null)
			{
				player = playerObject.transform;
			}
			else
			{
				Debug.LogError("Object with tag 'Player' not found!");
			}
		}
	}

	void FixedUpdate()
	{
		if (player == null) return;

		float distanceToPlayer = Vector3.Distance(transform.position, player.position);

		if (distanceToPlayer <= chaseDistance)
		{
			isChasing = true;

			// Calculate direction towards the player
			targetDirection = (player.position - transform.position).normalized;

			// Rotate towards the player
			Quaternion lookRotation = Quaternion.LookRotation(new Vector3(targetDirection.x, 0, targetDirection.z));
			transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.fixedDeltaTime);

			// Move towards the player
			Vector3 newPosition = transform.position + targetDirection * movementSpeed * Time.fixedDeltaTime;
			rb.MovePosition(newPosition);
		}
		else
		{
			isChasing = false;
		}
	}
}
