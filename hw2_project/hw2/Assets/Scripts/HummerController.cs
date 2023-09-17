using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cs294_137.hw2;

public class HummerController : MonoBehaviour {

	public GameObject particle;
	public AudioClip hitSE;
    private Camera arCamera;


	AudioSource audio;

	void Start () {
		this.audio = GetComponent<AudioSource> ();	
        arCamera = FindObjectOfType<ARCamera>().GetComponent<Camera>();
	}

	IEnumerator Hit(Vector3 target)
	{
		// Hummer Down		
		transform.position = new Vector3(target.x, 0, target.z);

		// Impact
		Instantiate (this.particle, transform.position, Quaternion.identity);

		arCamera.GetComponent<CameraController>().Shake();

		this.audio.PlayOneShot (this.hitSE);

		yield return new WaitForSeconds (0.1f);

		// Hummer Up
		for (int i = 0; i < 6; i++) 
		{
			transform.Translate (0, 0, 1.0f);
			yield return null;
		}
	}

	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = arCamera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100)) 
			{
				GameObject mole = hit.collider.gameObject;
				if(mole){
                    bool isHit = mole.GetComponent<MoleController> ().Hit ();
                    if (isHit)
                    {
                        StartCoroutine (Hit (mole.transform.position));
                        ScoreManager.score += 10;
                    }
                }
				
			}
		}
	}
}
