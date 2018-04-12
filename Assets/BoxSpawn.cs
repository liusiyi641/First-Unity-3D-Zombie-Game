using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn : MonoBehaviour
{
    public GameObject Box;
    float time = 0;

    public float respawning_time = 3f;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(time);
        if (Time.fixedTime - time > respawning_time){
            Box.SetActive(true);
            time = Time.fixedTime;
        }
    }
}
