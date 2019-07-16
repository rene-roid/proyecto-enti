using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    [SerializeField] public float actualLife;
    [SerializeField] float lifeAmount = 100;
    [SerializeField] float speed = 0.1f;
    [SerializeField] float pushMagnitude = 50.0f;

    [SerializeField] public Transform player;
    [SerializeField] Image lifeBar;

    public void damageReceived(float damageValue)
    {
        actualLife -= damageValue;
        lifeBar.fillAmount = actualLife / lifeAmount;
        if(actualLife <= 0)
        {
            SpawnManager.instance.removeEnemy(this);
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start ()
    {
        actualLife = lifeAmount;
	}

    void Update()
    {
        Vector3 dirVector = (player.transform.position - transform.position).normalized;
        //Vector3 dirVector = new Vector3(dirVector.x, 0.0f, dirVector.Z);
        if (GetComponent<Rigidbody2D>().velocity.magnitude > 0.0f)
        {
            GetComponent<Rigidbody2D>().AddForce(-GetComponent<Rigidbody2D>().velocity);
        }
        transform.position += dirVector  *speed;
    }
    // Update is called once per frame
    
    private void CollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            Vector2 pushVector = (collision.gameObject.transform.position -
                transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(pushVector
                * pushMagnitude, ForceMode2D.Impulse);
        }
    }
}
