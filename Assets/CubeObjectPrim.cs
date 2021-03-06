﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObjectPrim : MonoBehaviour {

    public GameObject prefab;
    SpriteRenderer spriteRenderer;
    public Sprite[] objForms;
    public Color[] objColors;
    int biggness = 1;
    GameObject tape;

    void Awake()
    {
        tape = GameObject.FindGameObjectWithTag("Tape");
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = objForms[Random.Range(0, objForms.Length)];
        spriteRenderer.color = objColors[Random.Range(0, objColors.Length)];
        if (Random.Range(1, 11) > 8) {
            transform.localScale *= 1.5f; //(int)Random.Range(1, 3);
            biggness = 2;
        }
    }

    void OnMouseDown()
    {
        print("cliked");

        if (GameManager.lastClickedObj != null && GameManager.lastClickedObj != this && GameManager.lastClickedObj.spriteRenderer.sprite == this.spriteRenderer.sprite)
        {
            if (GameManager.lastClickedObj.spriteRenderer.color == this.spriteRenderer.color ){
                if (GameManager.lastClickedObj.biggness == this.biggness) {
                    PowerBar.powerBarValue += 2 * biggness; GameManager.points += 2 * biggness;
                    GrowUpInstance(); }
                else { PowerBar.powerBarValue += 2; GameManager.points += 2; }
            }
            else { PowerBar.powerBarValue++; GameManager.points ++; }
                Destroy(GameManager.lastClickedObj.gameObject);
            Destroy(gameObject);
        }
        if (GameManager.lastClickedObj != null && GameManager.lastClickedObj != this && GameManager.lastClickedObj.spriteRenderer.color == this.spriteRenderer.color && GameManager.lastClickedObj.spriteRenderer.sprite != this.spriteRenderer.sprite)
        {
            PowerBar.powerBarValue ++;
            GameManager.points++;
            Destroy(GameManager.lastClickedObj.gameObject);
            Destroy(gameObject);
        }
        else GameManager.lastClickedObj = this;
    }

    void GrowUpInstance() {
        if (biggness != 3) {
            CubeObjectPrim biggerCube = Instantiate(prefab, gameObject.transform.position, Quaternion.identity, tape.transform).GetComponent<CubeObjectPrim>();
            biggerCube.gameObject.transform.localScale = new Vector3(1, 1, 1);
            biggerCube.spriteRenderer.color = this.spriteRenderer.color;
            biggerCube.spriteRenderer.sprite = this.spriteRenderer.sprite;
            switch (biggness) {
                case 1:
                    biggerCube.gameObject.transform.localScale *= 1.5f;
                    biggerCube.biggness = 2;
                    break;
                case 2:
                    biggerCube.gameObject.transform.localScale *= 2f;
                    biggerCube.biggness = 3;
                    break;                
                default:
                    break;
            }
        }
    }

}
