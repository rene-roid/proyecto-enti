using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerShoot))]
public class weaponInventory : MonoBehaviour
{
    public Weapon[] weaponArray = new Weapon[(int)Weapon.weaponType.COUNT];
    int actualWeapon = 0;
    PlayerShoot player;
    public GameObject canvas;
    // Use this for initialization
    void Start ()
    {
        player = GetComponent<PlayerShoot>();
        player.Bullet = weaponArray[actualWeapon].bulletPrefab.gameObject;
      
        player.Bullet.GetComponent<BULLET>().damage =
            weaponArray[actualWeapon].weaponDamage;
        player.timeBetweenShooting = weaponArray[actualWeapon].weaponCadency;
        player.ammunition = weaponArray[actualWeapon].ammunition;
        player.isPistol = true;
	}
	
    public void shootWeapon()
    {
        if (weaponArray[actualWeapon].ammunition > 0)
        weaponArray[actualWeapon].ammunition--;

        canvas.GetComponentInChildren<Text>().text = weaponArray[actualWeapon].ammunition.ToString();
    }
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            actualWeapon++;
            actualWeapon = (actualWeapon % weaponArray.Length);

            player.Bullet = weaponArray[actualWeapon].bulletPrefab.gameObject;
            player.Bullet.GetComponent<BULLET>().damage =
                weaponArray[actualWeapon].weaponDamage;

            player.timeBetweenShooting = weaponArray[actualWeapon].weaponCadency;
            player.ammunition = weaponArray[actualWeapon].ammunition;

            canvas.GetComponentInChildren<Text>().text = weaponArray[actualWeapon].ammunition.ToString();
            canvas.GetComponentInChildren<Image>().sprite = weaponArray[actualWeapon].image;

            if (actualWeapon == (int)Weapon.weaponType.PISTOL){
                player.isPistol = true;
            }

            else
            {
                player.isPistol = false;
            }

        }
	}
}
