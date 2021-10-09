using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int wavepointIndex = 0;

	private Enemy enemy;

	void Start()
	{
		enemy = GetComponent<Enemy>();

		target = Waypoints.points[0];
		Vector3 dir = target.position - transform.position;
		Vector3 newDirection = Vector3.RotateTowards(transform.forward, dir, 360, 0.0f);
		transform.rotation = Quaternion.LookRotation(newDirection);
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

		enemy.speed = enemy.startSpeed;
		dir = target.position - transform.position;
		Vector3 newDirection = Vector3.RotateTowards(transform.forward, dir, 0.01f, 0.0f);
		transform.rotation = Quaternion.LookRotation(newDirection);
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
		
	}

	void EndPath()
	{
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}

}
