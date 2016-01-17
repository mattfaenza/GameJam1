using UnityEngine;
using System.Collections;

public class enemyControl : MonoBehaviour {

	private Rigidbody rb;
	public float speed = 10f;
	public Vector3 enemySize;
	public Vector3 direction;

	// Use this for initialization
	void Start () {
		enemySize = GetComponent<Renderer>().bounds.size;
		direction = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f));
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (enemySize.x > other.bounds.size.x)
			{
				other.gameObject.SetActive(false);
			}
		}
		if (other.gameObject.CompareTag("Wall"))
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position, direction, out hit)) {
				direction = Vector3.Reflect (direction, hit.normal);
				direction.y = 0;
			}
		}
	}

	void Update() {
		transform.position += direction * speed * Time.deltaTime;
		Debug.Log (transform.position);
	}
}
