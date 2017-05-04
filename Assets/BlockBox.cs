using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBox : MonoBehaviour {

    public Sprite[] sprites;
    public SpriteRenderer spriteRen;
    public Animator animator;
    public int boxType;
    public float durability;
    public float boxZoffset;

    void Awake() {
        transform.position += new Vector3(0, 0, boxZoffset);
        boxType = Random.Range(0f, 1f) < 0.8f ? 1 : 2;
        spriteRen.sprite = sprites[boxType - 1];
        durability *= boxType;
    }

    void OnMouseDown() {
        durability--;
        if (CheckDurability()) DestroyBox();
        animator.SetTrigger("tap");
    }

    bool CheckDurability() {
        bool crack;
        crack = durability > 0 ? false : true;        
        return crack;
    }

    void DestroyBox() {
        Destroy(gameObject);
    }
}
