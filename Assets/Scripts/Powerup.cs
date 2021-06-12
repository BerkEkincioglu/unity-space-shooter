using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int _powerupID;
    // ID for powerups
    // 0 = triple shot
    // 1 = speed up
    // 2 = shields

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < 0.01)
        {
            Destroy(this.gameObject);
        }
       

    }
    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player"){
            Player player = other.transform.GetComponent<Player>();
            if(player)
            {
                switch(_powerupID) {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedUpActive();
                        break;
                    case 2:
                        player.ShieldActive();
                        break;
                    default:
                        Debug.Log("Defaul");
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }    
}
