using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 7.0f;
    [SerializeField]
    private GameObject _laserPrefabs;
    // Start is called before the first frame update
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        //if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire) // cooldown
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireLaser();
        }
    }

    void FireLaser()
    {

        Vector3 laserPosition = new Vector3(transform.position.x, transform.position.y + .8f, 0);
        nextFire = Time.time + fireRate;
        Instantiate(_laserPrefabs, laserPosition, Quaternion.identity);
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);   
        //transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);

        //transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime);

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        //if (transform.position.y >= 0)
        //{
        //    transform.position = new Vector3(transform.position.x, 0, 0);
        //}else if(transform.position.y < 0)
        //{
        //    transform.position = new Vector3(transform.position.x, 0, 0);
        //}

        //if (transform.position.x >= 11)
        //{
        //    transform.position = new Vector3(-11, transform.position.y, 0);

        //} else
        //{
        //    transform.position = new Vector3(11, transform.position.y, 0);
        //}
        if(transform.position.x < -10) {
            transform.position = new Vector3(10,transform.position.y,0);
        }
        if (transform.position.x > 10) {
            transform.position = new Vector3(-10, transform.position.y, 0);
        }


        if (transform.position.y < 0) {
            transform.position = new Vector3(transform.position.x,0, 0);
        }
        if (transform.position.y >= 0) {

            transform.position = new Vector3(transform.position.x, 0, 0);
        }


    }
}
