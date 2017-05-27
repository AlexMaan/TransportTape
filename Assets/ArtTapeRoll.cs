using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtTapeRoll : MonoBehaviour {

    public float angle;

	void Update () {
        transform.Rotate(0, 0, angle * TapeManager.tapeSpeed * Time.deltaTime);
	}
}
