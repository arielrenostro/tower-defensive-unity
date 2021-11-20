using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BMWSpawner : MonoBehaviour {

	public Transform spawnPoint;
    
    public GameObject bmw;

	public int Cost = 750;


	public void SpawnBmw ()
	{
		if (PlayerStats.Money < Cost)
		{
			Debug.Log("Not enough money to build that!");
			return;
		}
		if(GameObject.FindGameObjectsWithTag("BMW").Length == 0){
			PlayerStats.Money -= Cost;

        //Debug.Log("BMW");
		
		Instantiate(bmw, spawnPoint.position, spawnPoint.rotation);
		}
		
	}

}
