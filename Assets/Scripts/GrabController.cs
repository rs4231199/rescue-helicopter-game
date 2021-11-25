using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GrabController : MonoBehaviour
{
	public Transform grabDetect;
	public Transform boxHolder;
	public float rayDist; 
	public GameObject Square;

	Vector3 pos;
	public int used =  0;
	public bool positionSet = false;

	public LayerMask layerMask;
	public GameObject Panel;

	void Start() {
		ScoreValue.scoreValue = used;
	}
	
	void Update()
	{
		RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, transform.localScale,rayDist, layerMask);
        if(grabCheck.collider != null && grabCheck.collider.tag == "Box") {
			if(Input.GetKey(KeyCode.P)) {
				if(boxHolder.childCount == 0) {
					if(positionSet == false) {
						pos = grabCheck.collider.gameObject.transform.position;
						positionSet = true;
					}
					grabCheck.collider.gameObject.transform.parent = boxHolder;
					grabCheck.collider.gameObject.transform.position = boxHolder.position;
				}
			}
			else { 
				grabCheck.collider.gameObject.transform.parent = null;
			}

			if (Input.GetKeyUp(KeyCode.P))
			{
				Instantiate(grabCheck.collider.gameObject, pos, new Quaternion(0, 0, 0, 1));
				positionSet = false;
				grabCheck.collider.gameObject.tag = "Dropped";
				grabCheck.collider.gameObject.layer = 6;
                used++;
				ScoreValue.scoreValue = used;
				
				if(isCovered()) {
					string level = SceneManager.GetActiveScene().name;
					PlayerPrefs.SetInt("BestScore" + level[5], Math.Min(PlayerPrefs.GetInt("BestScore" + level[5], 10000),  used));
					PlayerPrefs.Save();
					Panel.SetActive(true);
				}
			}

		}
	}

	public bool isCovered() {
		for (float x = 0.0f; x <= 9.0f; x += 0.1f) {
			for (float y = 3.0f; y >= -1.0f; y -= 0.1f) {
				Vector2 top_right_corner = new Vector2(x, y);
				Vector2 bottom_left_corner = new Vector2(x + 0.1f, y + 0.1f);                
				Collider2D[] results = new Collider2D[1000];
				int colliderCount = Physics2D.OverlapAreaNonAlloc(top_right_corner, bottom_left_corner, results);
                if(colliderCount == 0) continue;
				bool foundFire = false, foundWater = false;
				foreach (Collider2D result in results)
				{
					if(colliderCount-- == 0) break;
					if(result.gameObject.name == "Fire")
						foundFire = true;
					if(result.gameObject.tag == "Dropped")
						foundWater = true;
				}
				if(foundFire == true && foundWater == false) {
					return false;
				}

			}
		}
		return true;
	}
}