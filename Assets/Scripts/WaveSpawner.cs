using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAlive = 0;
	public static int EnemiesSpawnPending = 0;

	public GameObject[] enemies;

	public Transform spawnPoint;

	public int maxWaves = 8;

	public float timeBetweenWaves = 5f;

	public Text waveCountdownText;

	public GameManager gameManager;

	private IEnumerator coroutine;
	private float countdown = 10f;
	private System.Random random = new System.Random();

	void Update ()
	{
		if (EnemiesAlive > 0 || EnemiesSpawnPending > 0)
		{
			return;
		}

		if (PlayerStats.Rounds >= 5)
		{
			gameManager.WinLevel();
			this.enabled = false;
		}

		if (countdown <= 0f)
		{
			this.coroutine = SpawnWave();
			StartCoroutine(this.coroutine);
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	void OnDestroy()
	{
		StopCoroutine(this.coroutine);
		PlayerStats.Rounds = 0;
		WaveSpawner.EnemiesAlive = 0;
		WaveSpawner.EnemiesSpawnPending = 0;
		this.countdown = 5f;
	}

	IEnumerator SpawnWave ()
	{
		PlayerStats.Rounds++;

		int enemiesAmount = PlayerStats.Rounds * (4 ^ 2);
		EnemiesSpawnPending = enemiesAmount;

		float rate = (-0.7057142857143f * (float) PlayerStats.Rounds) + 3.2857142857143f;

		for (int i = 0; i < enemiesAmount; i++)
		{
			GameObject enemy = this.determinateEnemy();
			SpawnEnemy(enemy);
			yield return new WaitForSecondsRealtime(rate);
		}
	}

	void SpawnEnemy (GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
		EnemiesSpawnPending--;
	}

	int randomBetween(int min, int max)
    {
		double diff = (double) (1 + max - min);
		return min + (int) (diff * this.random.NextDouble());
    }

	GameObject determinateEnemy()
    {
		int max;
		if (PlayerStats.Rounds == 1)
        {
			max = 0;
        } else if (PlayerStats.Rounds == 2)
        {
			max = 1;
        } else
        {
			max = this.enemies.Length - 1;
		}
		int idx = this.randomBetween(0, max);
		return this.enemies[idx];
    }
}
