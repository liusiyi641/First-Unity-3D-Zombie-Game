
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Test_Player_Controller : MonoBehaviour
{
	public static int t;
	public static int x;
	public GameObject Niubi_Zombie;
	public GameObject Zombie;
    // Use this for initialization
	public Text bullets_number;
    void Start()
    {
		t = 0;
		x = 0;
    }

    void FixedUpdate()
    {
		bullets_number.text = PlayerShooting.bullets.ToString ();
		transform.localEulerAngles = new Vector3 (0.0f, transform.localEulerAngles.y, 0.0f);
        float moveHorizontal = -Input.GetAxis("Vertical");
        float moveVertical = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
        float angle_Y = Mathf.Asin(moveHorizontal / Mathf.Sqrt(Mathf.Pow(moveHorizontal, 2) + Mathf.Pow(moveVertical, 2)));
        if (moveVertical < 0)
        {
            if (moveHorizontal > 0)
            {
                angle_Y = Mathf.PI - angle_Y;
            }
            else
            {
                angle_Y = -Mathf.PI - angle_Y;
            }
        }
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            transform.localEulerAngles = new Vector3(0.0f, (180 / Mathf.PI) * angle_Y, 0.0f);
        }
        transform.position += movement * Time.deltaTime * 5;
		if (t > 0){
			t = 0;
			Instantiate(Niubi_Zombie, transform.position + new Vector3(5.0f, 5.0f, 5.0f), Quaternion.identity);
		}
		if (x > 0) {
			x = 0;
			Instantiate (Zombie, transform.position + new Vector3 (5f, 5f, 5f), Quaternion.identity);
		}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pick_up")
        {
            other.gameObject.SetActive(false);
            //surprise();
			Box.surprise();
        }
    }

/*    void surprise()
    {
        float random_number;
        random_number = Random.value;

        //Debug.Log(random_number);
        if (0.2 >= random_number)
        {
            Debug.Log("Heavy_weapon_bullet");
            bullets += 3;
        }
        if (0.4 >= random_number && random_number > 0.2)
        {
            Debug.Log("First_aid");
        }
        if (0.6 >= random_number && random_number > 0.4)
        {
            Debug.Log("Empty");
        }
        if (0.8 >= random_number && random_number > 0.6)
        {
            Debug.Log("Regular zombies");
        }
        if (1.0 >= random_number && random_number > 0.8)
        {
            Debug.Log("NiuBi Jiangshi(not telling) and a bit bullets");
        }
    }*/
}