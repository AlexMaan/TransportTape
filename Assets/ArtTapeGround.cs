using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtTapeGround : MonoBehaviour {

    public Vector3 endPos;
    public Vector3 startPos;


    void Start () {
		
	}
	
	void Update () {
		if(transform.position.x <= endPos.x) {
            transform.position = startPos;
        }
	}
}
