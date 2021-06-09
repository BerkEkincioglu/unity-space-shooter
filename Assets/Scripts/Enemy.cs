using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 4.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float randomX = Random.Range(-9.0f, 9.0f);
        float axisY = 11;
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -1.5f)
        {
            transform.Translate(new Vector3(randomX, axisY, 0));
        }
    }
}
