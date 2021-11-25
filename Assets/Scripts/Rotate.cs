using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public LayerMask layerMask;
    
    private Camera CameraVar;
    private Vector3 PositionOfScreen;
    private Collider2D ColliderVar;
    private float Delta;

    // Start is called before the first frame update
    private void Start()
    {
        CameraVar = Camera.main;
        ColliderVar = GetComponent<Collider2D>();   
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 mousePos = CameraVar.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0) == true) {
            if(ColliderVar == Physics2D.OverlapPoint(mousePos, layerMask) && ColliderVar.tag == "Box") {
                PositionOfScreen = CameraVar.WorldToScreenPoint(transform.position);
                Vector3 vec3 = Input.mousePosition - PositionOfScreen;
                Delta = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x))*Mathf.Rad2Deg;
            }
        }
        if(Input.GetMouseButton(0) == true) {
            if(ColliderVar == Physics2D.OverlapPoint(mousePos, layerMask)  && ColliderVar.tag == "Box") {
                 Vector3 vec3 = Input.mousePosition - PositionOfScreen;
                 float angle = Mathf.Atan2(vec3.y, vec3.x)*Mathf.Rad2Deg;
                 transform.eulerAngles = new Vector3(0, 0, angle + Delta);
            }
        }
    }
}