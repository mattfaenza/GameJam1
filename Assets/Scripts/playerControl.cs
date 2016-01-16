using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    public Vector3 playerSize;
    // Use this for initialization
    void Start () {
        playerSize = GetComponent<Renderer>().bounds.size;
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (playerSize.x > other.bounds.size.x)
            {
                other.gameObject.SetActive(false);
            }
            //other.gameObject.SetActive(false);
        }
    }
}