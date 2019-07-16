using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public enum weaponType
    {
        PISTOL,
        AK47,
        RPG,
        MINIGUN,
        COUNT
    }
    public weaponType type;
    public float weaponDamage;
    public float weaponCadency;
    public int ammunition;
    public BULLET bulletPrefab;
    public Sprite image;

    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
