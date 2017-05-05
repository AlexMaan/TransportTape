using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

    public float destroyT;

	void Start () {
        Destroy(gameObject, destroyT);
	}
	
	
}
