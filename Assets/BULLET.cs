using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BULLET: MonoBehaviour
{
    public Vector2 dirVector;
    public float speed;
    public float damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += new Vector3(dirVector.x * speed, dirVector.y * speed);
	}

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().damageReceived(damage);
            Destroy(gameObject);
        }
    }
    
}
