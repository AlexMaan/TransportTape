using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCellGenPos : MonoBehaviour {

    void Start() {
        //if (PlayerPrefs.HasKey("setupRowPosition")) transform.position.Set(0, float.Parse(PlayerPrefs.GetString("setupRowPosition")), 0);
        switch (CellGenerator.genMode) {
            case 1:
                Vector3 pos1 = new Vector3(0, -2.5f, 0);
                transform.position = pos1;
                break;
            case 2:
                Vector3 pos2 = new Vector3(0, -1, 0);
                transform.position = pos2;
                break;
            case 3:
                Vector3 pos3 = new Vector3(0, 0, 0);
                transform.position = pos3;
                break;
            case 4:                
                goto case 3;
            default:
                break;               
        }
    }
}
