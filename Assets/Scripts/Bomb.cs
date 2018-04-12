using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public GameObject bomb;
    public float power = 10.0f;
    public float radius = 5.0f;
    public int BombHealth = 10;
    public Vector3 pos;
    public AudioClip AC;





    // Use this for initialization
    void Start () {
        pos = transform.localPosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(pos != transform.localPosition)
        {

            AudioSource.PlayClipAtPoint(AC, transform.localPosition);
            pos = transform.localPosition;
        }
		if (BombHealth < 0)
        {
            Detonate();
            Destroy(bomb);
        }
    }

    void Detonate()
    {
        Vector3 ExplosionPosition = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(ExplosionPosition, radius);
        foreach (Collider hit in colliders)
        {
			hit.transform.SendMessage("DeductPoints", power, SendMessageOptions.DontRequireReceiver);
        }
    }

    void DeductPoints(int DamageAmount)
    {
        Debug.Log(BombHealth);
        BombHealth -= DamageAmount;
    }
}
