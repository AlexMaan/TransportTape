using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombParam : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public GoodParam goodParam;
    //float z;
    //public float baseLine;
    //public float reposK;

    void Start () {
        //spriteRenderer.color = Color.black;
        spriteRenderer.color = Color.white;
        goodParam.ColorIndex = 6;

        //z = transform.position.z;
        //z += (baseLine + transform.position.y) * reposK;
        //transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
}
