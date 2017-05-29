using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombParam : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public GoodParam goodParam;

    void Start () {
        //spriteRenderer.color = Color.black;
        spriteRenderer.color = Color.white;
        goodParam.ColorIndex = 6;
        
    }
}
