using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombParam : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public GoodParam goodParam;

    void Start () {
        spriteRenderer.color = Color.grey;
        goodParam.ColorIndex = 0;
        
    }
}
