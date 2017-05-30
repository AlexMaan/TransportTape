using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtGoodSpritePos : MonoBehaviour {

    public float baseLine;
    public float reposK;
    float z;
    Vector3 v;

    void Awake() {
        if (Random.Range(0f, 1f) > 0.5f) transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        z = transform.position.z;
        z += (baseLine + transform.position.y) * reposK;
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
}
