using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stupid_Zombie_Movement : MonoBehaviour
{
    public GameObject player;
    private Vector3 direction;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        direction = (player.transform.position - transform.position).normalized;
        float angle_Y = Mathf.Asin(direction.x / Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.z, 2)));
        if (direction.z < 0)
        {
            if (direction.x > 0)
            {
                angle_Y = Mathf.PI - angle_Y;
            }
            else
            {
                angle_Y = -Mathf.PI - angle_Y;
            }
        }
        transform.localEulerAngles = new Vector3(0.0f, (180 / Mathf.PI) * angle_Y, 0.0f);
        GetComponent<CharacterController>().Move(direction * Time.deltaTime * 4);
    }
}
