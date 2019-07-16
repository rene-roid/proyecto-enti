using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    Transform[] spawnPositions;

    [SerializeField]
    bool isAreaEnambled = false;
    bool spawn = true;
    

    float timer;
    [SerializeField]
    float timeBetweenSpawns = 1.0f;
    [SerializeField] List<Enemy> enemies;
    [SerializeField] int maxSpawns = 10;


    public static SpawnManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    // Use this for initialization
    void Start ()
    {
        enemies = new List<Enemy>();
	}
    public void removeEnemy(Enemy en)
    {
        enemies.Remove(en);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (timer >= timeBetweenSpawns && maxSpawns > enemies.Count && spawn)
        {
            int spawnID = Random.Range(0, spawnPositions.Length);
            GameObject enemy = Instantiate(enemyPrefab, spawnPositions[spawnID].position,
                Quaternion.identity);
            enemy.GetComponent<Enemy>().player = player;
            enemies.Add(enemy.GetComponent<Enemy>());
            timer = 0.0f;
        }
        timer += Time.deltaTime;

        if (!isAreaEnambled) spawn = true;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && isAreaEnambled)
        {
            spawn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"& isAreaEnambled)
        {
            spawn = false;
            foreach(Enemy en in enemies)
            {
                Destroy(en.gameObject);
            }
            enemies.Clear();
            //enemies.ForEach((Enemy
        }
    }
}
