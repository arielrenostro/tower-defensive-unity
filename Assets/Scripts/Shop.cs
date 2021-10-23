using UnityEngine;

public class Shop : MonoBehaviour {

	public TurretBlueprint vaso;
	public TurretBlueprint clerigo;
	public TurretBlueprint laser;

	BuildManager buildManager;
	BMWSpawner BMWSpawner;
	void Start ()
	{
		buildManager = BuildManager.instance;
	}

	public void SelectVaso ()
	{
		Debug.Log("Standard Turret Selected");
		buildManager.SelectTurretToBuild(vaso);
	}

	public void SelectClerigo()
	{
		Debug.Log("Missile Launcher Selected");
		buildManager.SelectTurretToBuild(clerigo);
	}

	public void SelectLaser()
	{
		Debug.Log("Laser Beamer Selected");
		buildManager.SelectTurretToBuild(laser);
	}

	//public void spawnBMW(){
	//	BMWSpawner.SpawnBmw();
	//}

}
