using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 4.0f;
    private Player _player;
    //private float hp = 100.0f;

    private Animator _animator;

    

    // Start is called before the first frame update
    void Start(){
        _player =  GameObject.Find("Player").GetComponent<Player>();
        if(_player == null)
        {
            Debug.Log("Player is null");
        }
        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.Log("Animator is null");
        }
    }

    // Update is called once per frame
    void Update(){
        float randomX = Random.Range(-3.0f, 3.0f);

        float axisY = 11;
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -1.5f){
            transform.Translate(new Vector3(randomX, axisY, 0));
            
        }
       
    }

    
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){

            Player player = other.transform.GetComponent<Player>();

            if(player){
                player.Damage();
            }
            _animator.SetTrigger("OnEnemyDeath");
            _speed = 0;
            GetComponent<AudioSource>().Play();
            Destroy(this.gameObject,2.8f);

        }
        if(other.tag == "Laser"){
            Destroy(other.gameObject);
            if (_player)
            {
                _player.AddScore();
            }
            _animator.SetTrigger("OnEnemyDeath");
            _speed = 0;
            GetComponent<AudioSource>().Play();
            Destroy(this.gameObject,2.8f);

        }
    }
}
