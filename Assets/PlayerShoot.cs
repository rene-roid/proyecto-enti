using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] public GameObject Bullet;
    [SerializeField] public float weaponSpeed;
    float timer = 0.0f;
    [SerializeField] public float timeBetweenShooting = 1.0f;

    public int ammunition = 0;
    public bool isPistol = false;

    [SerializeField] weaponInventory inventory;
	// Use this for initialization
	void Start ()
    {
        inventory = GetComponent<weaponInventory>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0) && timer >= timeBetweenShooting && (ammunition > 0 || isPistol))
        {
            inventory.shootWeapon();
            ammunition--;
            GameObject bullet = Instantiate(Bullet,transform.position,
                Quaternion.identity);

            bullet.GetComponent<BULLET>().dirVector = (new Vector2(
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y) - 
            new Vector2(gameObject.transform.position.x, 
            gameObject.transform.position.y)).normalized;

            //bullet.GetComponent<BULLET>().damage = 1000.0f;
            Bullet.GetComponent<BULLET>().speed = weaponSpeed;

            Destroy(bullet, 5.0f);

            timer = 0.0f;
        }
        timer += Time.deltaTime;
	}
}
