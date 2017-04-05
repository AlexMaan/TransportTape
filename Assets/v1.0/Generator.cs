using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public GameObject prefab;
    BaseTape baseTape;
    //public float tapeYMin;
    //public float tapeYMax;
    public float placePeriod;

	void Start (){
        baseTape = FindObjectOfType<BaseTape>();
        StartCoroutine("PlaceItemPeriod");
	}
	
    IEnumerator PlaceItemPeriod (){
        while (true){
            PlaceItem();
            yield return new WaitForSeconds(placePeriod * (1 / TapeManager.tapeSpeed));
        }             
    }

     GameObject PlaceItem(){
        for (int i = 0; i < 5; i++){
            float offset = Random.Range(-0.4f, 0.4f);
            Instantiate(prefab, new Vector3(transform.position.x + offset * 2, (i * 1.7f + offset) - 3.3f, transform.position.z), Quaternion.identity, baseTape.transform);
        }                
        return null;
    }

}
