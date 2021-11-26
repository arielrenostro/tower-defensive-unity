using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject ui;

	public SceneFader sceneFader;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			Toggle();
		}
	}

	public void Toggle ()
	{
		ui.SetActive(!ui.activeSelf);

		if (ui.activeSelf)
		{
			Time.timeScale = 0f;
		} else
		{
			Time.timeScale = 1f;
		}
	}

	public void Retry ()
	{
		Time.timeScale = 1f;
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

}
