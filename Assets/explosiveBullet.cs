using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiveBullet : BULLET {

    [SerializeField]
    float explosionRadius = 1.0f;
    public float explosionStrength = 5.0f;

    void AddExplosionForce(Rigidbody2D body, float explosionForce,Vector3 explosionPosition, float explosionRadius)
    {
        Vector3 dir = (body.transform.position - explosionPosition);
        float wearoff = 1 - (dir.magnitude / explosionRadius);
        body.AddForce(-dir.normalized * explosionForce * wearoff);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Player")
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

            foreach(Collider2D col in cols)
            {
                if(col.gameObject != gameObject)
                {
                    if(col.GetComponent<Rigidbody2D>() != null)
                    {
                        AddExplosionForce(col.gameObject.GetComponent<Rigidbody2D>(),
                            explosionStrength, transform.position, explosionRadius);

                        if (col.gameObject.tag == "Enemy")
                        {
                            col.gameObject.GetComponent<Enemy>().damageReceived(damage);
                        }
                    }

                    
                }
            }
        }
        base.OnTriggerEnter2D(other);
    }
	
}
