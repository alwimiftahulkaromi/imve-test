using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			GameManager.instance.GameOver();
		}
	}

	private void FixedUpdate()
	{
		if (gameObject.transform.position.y < -5)
		{
			GameManager.instance.GameOver();
		}
	}
}
