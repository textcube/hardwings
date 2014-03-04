using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
    public float speed;
    Player player;

	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	void Update () {
        float dist = player.pos * speed;
        if (player.pos < 0f) dist += 32f;
        dist -= ((int)dist / 32) * 32;

        Vector3 pos = transform.position;
        transform.position = new Vector3(dist * -1, pos.y, pos.z);
	}
}
