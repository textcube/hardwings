using UnityEngine;
using System.Collections;
//using PathologicalGames;

public class Pillar : MonoBehaviour {
    public float speed = 2f;
    public GameManager gameManager;
    public bool ok = false;

    //public SpawnPool pool;

	void Start () {
	}

    void SetOk()
    {
        ok = true;
        gameManager.AddScore();
    }
	
	void Update () {
        if (gameManager.isGameOver) return;
        Vector3 pos = transform.position;
        if (!ok && pos.x < -3f) SetOk();
        if (pos.x < -5f)
        {
            //pool.Despawn(transform);
            Destroy(gameObject);
        }
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + 5f * Vector3.left, step);
        //float step = speed * Time.deltaTime;
        transform.position += Vector3.left * Time.deltaTime * speed;
	}
}
