using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class StickController : MonoBehaviour {

	// Use this for initialization
	public int GunDamageAmount = 5;
	public int NiuBiDamageAmount = 200;
	public float used_distancee;
	public float GunAllowedRange = 15.0f;
	public float NiuBiAllowedRange = 30.0f;
	public GameObject Gun, NiuBi;
	public static int bullets = 0;
	public AudioClip AC1;
	public AudioClip AC2;
	public AudioClip AC3;
	public AudioClip AC4;
	public AudioClip AC5;
	public AudioClip AC6;
	public Text GunType;
	public LineRenderer laserLine;
	public float keep_time = 0.1f;
	public float cold_time = 0f;


	void Start () {
		laserLine = GetComponent<LineRenderer>();
		NiuBi.SetActive(false);
		Gun.SetActive(true);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		Vector3 moveVec = new Vector3 (CrossPlatformInputManager.GetAxis ("Horizontal"), 0, CrossPlatformInputManager.GetAxis ("Vertical")) * moveForce;
//		mybody.AddForce (moveVec);
		{
			float moveHorizontal = -CrossPlatformInputManager.GetAxis("Vertical");
			float moveVertical = CrossPlatformInputManager.GetAxis("Horizontal");
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
			transform.position += movement * Time.deltaTime * 10;
		}

		if (laserLine.enabled) {
			keep_time -= Time.deltaTime;
			if (keep_time <= 0) {
				laserLine.enabled = false;
				keep_time = 0.1f;
			}
		}


		if (CrossPlatformInputManager.GetButton("Change"))
		{ 
			Debug.Log("hello");
			if (Gun.activeSelf)
			{
				Gun.SetActive(false);
				NiuBi.SetActive(true);
				GunType.text = "Laser";
			}
			else
			{
				Gun.SetActive(true);
				NiuBi.SetActive(false);
				GunType.text = "Hand Gun";
			}
			//Gun.SetActive(true);
			//NiuBi.SetActive(false);
		}

		if (CrossPlatformInputManager.GetButton("Shoot") && cold_time <= 0) {   
			if (Gun.activeSelf) {
				AudioSource.PlayClipAtPoint (AC1, transform.localPosition);
				RaycastHit Shot;
				if (Physics.Raycast (Gun.transform.position, transform.TransformDirection (Vector3.forward), out Shot, GunAllowedRange)) {
					Shot.transform.SendMessage ("DeductPoints", GunDamageAmount, SendMessageOptions.DontRequireReceiver);
					laserLine.SetPosition (0, transform.position);
					laserLine.SetPosition (1, Shot.point);
					laserLine.enabled = true;
				} else {
					laserLine.SetPosition (0, transform.position);
					laserLine.SetPosition (1, transform.forward * 200 + transform.position);
					laserLine.enabled = true;
				}
			}

			if (NiuBi.activeSelf) {
			//else{
				if (PlayerShooting.bullets > 0) {
					AudioSource.PlayClipAtPoint (AC4, transform.localPosition);
					PlayerShooting.bullets -= 1;
					RaycastHit[] Shot = Physics.RaycastAll (NiuBi.transform.position, transform.TransformDirection (Vector3.forward), NiuBiAllowedRange); 
					if (Shot.Length != 0) {
						for (int i = 0; i < Shot.Length; i++) {
							Shot [i].collider.SendMessage ("DeductPoints", NiuBiDamageAmount, SendMessageOptions.DontRequireReceiver);
						}
					}
					laserLine.SetPosition (0, transform.position);
					laserLine.SetPosition (1, transform.forward * 200 + transform.position);
					laserLine.enabled = true;
				} else {
					AudioSource.PlayClipAtPoint (AC5, transform.localPosition);
				}
			}
			cold_time = 0.5f;
		} else {
			cold_time -= Time.deltaTime;
		}




	}
}
