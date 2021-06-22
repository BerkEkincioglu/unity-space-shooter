using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 4.0f;
    private Player _player;
    //private float hp = 100.0f;

    private Animator _animator;
    [SerializeField]
    private GameObject _enemyLasers;
    private float _fireRate = 3.0f;
    private float _canFire = -1.0f;

   
    
    

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
        CalculateMovement();

        if(Time.time > _canFire)
        {
            _fireRate = Random.Range(3f, 7f);
            _canFire = Time.time + _fireRate;
           GameObject enemyLaser = Instantiate(_enemyLasers, transform.position, Quaternion.identity);
            Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();
            for(int i = 0; i < lasers.Length; i++)
            {
                lasers[i].AssignEnemyLaser();
            }
        }
    }

    void CalculateMovement()
    {
        float randomX = Random.Range(-3.0f, 3.0f);

        float axisY = 11;
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -1.5f)
        {
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
            Destroy(GetComponent<Collider2D>());

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
            Destroy(GetComponent<Collider2D>());

            Destroy(this.gameObject,2.8f);

        }
    }

   
}
