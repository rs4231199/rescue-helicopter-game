using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float scale = 8;

    void Update()
    {
        Vector2 motionAngle = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float mod = Mathf.Clamp01(motionAngle.magnitude);
        motionAngle.Normalize();
        motionAngle = Time.deltaTime * motionAngle * scale * mod;
        transform.Translate(motionAngle, Space.World);
    }
}
