using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Delay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        
        yield return new WaitForSeconds(37.50f);
        SceneManager.LoadScene("MainMenu");
    }
}
