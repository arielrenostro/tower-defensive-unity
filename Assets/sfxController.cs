using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("achaInimigo1", 0.0f,1.0f);
        InvokeRepeating("achaInimigo2", 0.5f,1.0f);
        InvokeRepeating("achaInimigo3", 1.0f,1.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void achaInimigo1(){
        GameObject temp = GameObject.Find("R.P.S");
        if(temp == null){
            //Debug.Log("NÃO ACHOU rps");
            foreach (Transform child in transform)
            {
                if(child.name == "regador"){
                    child.GetComponent<AudioSource>().Stop();
                }
  
            }
        }
         

        //GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Enemy");   
        //foreach (GameObject inimigo in inimigos){

            //Debug.Log(inimigo);
        //}
    }

    void achaInimigo2(){
        GameObject temp= GameObject.Find("Carroca");
        GameObject temp2= GameObject.Find("Carroca(Clone)");
        if(temp == null && temp2 == null){
             //Debug.Log("NÃO ACHOU carroca");
            foreach (Transform child in transform)
            {
                if(child.name == "carroca"){
                    child.GetComponent<AudioSource>().Stop();
                }
                 if(child.name == "agua"){
                    child.GetComponent<AudioSource>().Stop();
                } 
  
            }
        }
         
    }

    void achaInimigo3(){
        GameObject temp= GameObject.Find("B.C.B.C.C");
        GameObject temp2= GameObject.Find("B.C.B.C.C(Clone)");

        if(temp == null && temp2 == null){
            //Debug.Log("NÃO ACHOU barco");
            foreach (Transform child in transform)
            {
                if(child.name == "barco"){
                    child.GetComponent<AudioSource>().Stop();
                }
  
            }
        }
         
    }




    
}
