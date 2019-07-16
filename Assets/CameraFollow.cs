using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField] GameObject player;
    public float cameraSpeed = 0.5f;
	// Use this for initialization
	void Start ()
    {
		
	}
    private void LateUpdate()
    {
        float poX = Mathf.Lerp(transform.position.x, player.transform.position.x
            , Time.deltaTime * cameraSpeed);
        float posY = Mathf.Lerp(transform.position.y, player.transform.position.y
            , Time.deltaTime * cameraSpeed);
        transform.position = new Vector3(poX, posY, transform.position.z);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
