using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMW : MonoBehaviour
{
    
    //public Transform endPoint;
    private Transform target;
    private int wavepointIndex = Waypoints.points.Length - 2;
    private int nextWavepointIndex = Waypoints.points.Length -3;
    public GameObject deathEffect;

    void Start()
	{
        
		target = Waypoints.points[wavepointIndex];
		Vector3 dir = target.position - transform.position;
		Vector3 newDirection = Vector3.RotateTowards(transform.forward, dir, 360, 0.0f);
		transform.rotation = Quaternion.LookRotation(newDirection);
	}
	

	void Update ()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * 15 * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 5f)
		{
            updateRotation();
        }

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
        
		}

        
		//updateRotation();
        
		
	}

    void GetNextWaypoint()
	{
		if (wavepointIndex == 0 )
		{

			Destroy(gameObject);
            GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
    		Destroy(effect, 5f);

			return;
		}

		wavepointIndex--;
        nextWavepointIndex--;
		target = Waypoints.points[wavepointIndex];
		
	}

    void updateRotation(){
        if(nextWavepointIndex != -1){
        Transform rotationTarget = Waypoints.points[nextWavepointIndex];
        Vector3 dir = rotationTarget.position - transform.position;
		Vector3 newDirection = Vector3.RotateTowards(transform.forward, dir, 0.03f, 0.0f);
		transform.rotation = Quaternion.LookRotation(newDirection);
		}
    }

	void OnCollisionEnter(Collision collision){
		Debug.Log("TAG " + collision.gameObject.tag);

		if(collision.gameObject.tag == "Enemy"){
			Enemy sc = collision.gameObject.GetComponent<Enemy>();
			
            GameObject effect = (GameObject)Instantiate(sc.deathEffect, transform.position, Quaternion.identity);
    		Destroy(effect, 5f);

			Destroy(collision.gameObject);
		}
	}
}
