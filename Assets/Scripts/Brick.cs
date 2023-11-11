using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public Transform explosion;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        Instantiate(explosion, collision.transform.position, collision.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
