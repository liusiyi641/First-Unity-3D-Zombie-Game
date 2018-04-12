using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public float CreatTime;
    float Pseudo_Time = 1f;
    public GameObject Smart_Ghost;
    public GameObject Stupid_Ghost;
    public GameObject SpownPoint;
    public float Pseudo_Number = 0.6f;
    float random_number;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Pseudo_Time -= Time.deltaTime;
        if (Pseudo_Time <= 0)
        {
            Pseudo_Time = CreatTime;
            float distance = Random.Range(0, 2);
            float angle = Random.Range(0, 2 * Mathf.PI);
            float dx = distance * Mathf.Cos(angle);
            float dz = distance * Mathf.Sin(angle);
            Vector3 New_Ghost = SpownPoint.transform.position + new Vector3(dx, 0.0f, dz);
            random_number = Random.value;
            if (random_number > Pseudo_Number)
            {
                Instantiate(Smart_Ghost, New_Ghost, Quaternion.identity);
            }
            else
            {
                Instantiate(Stupid_Ghost, New_Ghost, Quaternion.identity);
            }
        }
    }
}
