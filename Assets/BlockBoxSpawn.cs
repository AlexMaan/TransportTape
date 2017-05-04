using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBoxSpawn : MonoBehaviour {

    public GameObject boxPrefab;
    public float probability;

    void Awake() {
        if (Random.Range(0f, 1f) < probability) Instantiate(boxPrefab, transform.position,Quaternion.identity,transform.parent.transform.parent.transform);
    }
}
