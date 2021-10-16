using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BMWSpawner : MonoBehaviour {

	public Transform spawnPoint;
    
    public GameObject bmw;
    
	


	public void SpawnBmw ()
	{
        Debug.Log("BMW");
		Instantiate(bmw, spawnPoint.position, spawnPoint.rotation);
	}

}
