using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    private float _speed = 8.0f;
    private bool _isEnemyLaser = false;
    //private float ad = 30.0f;
    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update(){

        if(!_isEnemyLaser)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
        
    }
    void MoveUp()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        //GameObject tripleShot = GameObject.Find("Triple_Shot");

        if (transform.position.y >= 14)
        {
            if (transform.parent)
            {
                Destroy(transform.parent.gameObject);
            }
             Destroy(this.gameObject);
        }

    }
    void MoveDown()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            if (transform.parent)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }


    }

    public void AssignEnemyLaser()
    {
        _isEnemyLaser = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && _isEnemyLaser)
        {
            Player player = collision.GetComponent<Player>();
            if (player)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
    }

}
    //public float getAD()
    //{
    //    return ad;
    //}

