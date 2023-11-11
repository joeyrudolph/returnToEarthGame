using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string rightKey = "right";
    public string leftKey = "left";
    public string fireKey = "space";

    public bool _readyToFire = false;
    public GameObject _fakeBall;
    public Ball _ball;
    public Image[] _Lives;
    public int _livesRemaining = 5;
    public GameOver _gameOver;

    // Start is called before the first frame update
    void Start()
    {
        if (_readyToFire)
            _fakeBall.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //check control
        if (Input.GetKey(rightKey))
        {
            transform.Translate(new Vector2(0.1f, 0f));
        }

        else if (Input.GetKey(leftKey))
        {
            transform.Translate(new Vector2(-0.1f, 0f));
        }

        else if (Input.GetKey(fireKey))
        {
            if (_readyToFire)
                FireBall();
        }
    }

    void FireBall()
    {
        _readyToFire = false;
        _fakeBall.SetActive(false);

        Ball newBall = Instantiate(_ball, _fakeBall.transform.position, Quaternion.identity);

        float angle;
        if (transform.position.x < 0.0f)
            angle = Mathf.Deg2Rad * Random.Range(-30, 30);
        else
            angle = Mathf.Deg2Rad * Random.Range(150, 210);
        
        Vector2 force = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        newBall.GetComponent<Rigidbody2D>().AddForce(force * 1.0f);
    } 

    public void LoseALive()
    {
        // reduce lives by 1
        _livesRemaining--;

        // hide a heart image
        _Lives[_livesRemaining].enabled = false;

        // reset ball position
        _readyToFire = true;
        _fakeBall.SetActive(true);

        // check game over
        if (_livesRemaining == 0) {
            Debug.Log("Game Over");
            _gameOver.SetUp();
        }

    }
}