using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicButton : MonoBehaviour
{
    // Start is called before the first frame update
     public void toggle() {
		GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().toggle();
     }
}
