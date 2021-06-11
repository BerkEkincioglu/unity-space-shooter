using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 4.0f;
    //private float hp = 100.0f;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float randomX = Random.Range(-3.0f, 3.0f);

        float axisY = 11;
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -1.5f)
        {
            transform.Translate(new Vector3(randomX, axisY, 0));
        }
       
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            Player player = other.transform.GetComponent<Player>();

            if(player)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }
    }
}
