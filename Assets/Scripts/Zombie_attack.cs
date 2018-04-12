using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_attack : MonoBehaviour
{
    int Zombie_hunt = 3;
    float atrack_time = 0;
    public AudioClip AC;
	public GameObject Player;

    // Use this for initialization
    void Update()
    {
		if (atrack_time <= 0 && Vector3.Distance(transform.position, Player.transform.position) <= 2)
		{
			Player.SendMessage("TakeDamage", Zombie_hunt);
			atrack_time = 2;
			AudioSource.PlayClipAtPoint(AC, transform.localPosition);
		}
		else
		{
			atrack_time -= Time.deltaTime;
		}

    }

    // Update is called once per frame
}
