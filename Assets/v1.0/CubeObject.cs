using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObject : MonoBehaviour {

    TextMesh textMesh;
    public string[] objLabels;
    public Color[] objColors;
    
    void Awake(){
        textMesh = GetComponent<TextMesh>();
        textMesh.text = objLabels[Random.Range(0, objLabels.Length)];
        textMesh.color = objColors[Random.Range(0, objColors.Length)];
        transform.localScale *= Random.Range(1f, 2f);
    }

    //void OnMouseDown(){
    //    print("cliked");

    //    if (GameManager.lastClickedObj != null && GameManager.lastClickedObj != this && GameManager.lastClickedObj.textMesh.text == this.textMesh.text ){
    //        if (GameManager.lastClickedObj.textMesh.color == this.textMesh.color) GameManager.points += 3;
    //        else GameManager.points++;
    //        Destroy(GameManager.lastClickedObj.gameObject);
    //        Destroy(gameObject);                       
    //    }
    //    else GameManager.lastClickedObj = this;
    //}

}
