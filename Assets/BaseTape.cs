using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTape : MonoBehaviour {

    public Vector3 translateVector;


	void Update () {
        translateVector = new Vector3(GameManager.tapeSpeed*Time.deltaTime, 0, 0);
        transform.Translate(translateVector);
	}
}
