using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermyHealth : MonoBehaviour {

    public int EnemyHealth = 10;
    public AudioClip AC;

    void DeductPoints(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }

    void Update()
    {
        if (EnemyHealth <= 0)
        {
            AudioSource.PlayClipAtPoint(AC, transform.localPosition);
            Destroy(gameObject);
        }
    }
}
