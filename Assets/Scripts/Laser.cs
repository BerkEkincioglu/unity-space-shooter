using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    private float _speed = 8.0f;
    //private float ad = 30.0f;
    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        //GameObject tripleShot = GameObject.Find("Triple_Shot");

        if (transform.position.y >= 14){
            if (transform.parent){
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);

        }

        
    }

}
    //public float getAD()
    //{
    //    return ad;
    //}

