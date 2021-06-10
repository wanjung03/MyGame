using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Speed = 10;
    public GameObject bullet = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * Speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += -Vector3.forward * Time.deltaTime * Speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * Speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += -Vector3.right * Time.deltaTime * Speed;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.eulerAngles += new Vector3(0, 1, 0) * Time.deltaTime * Speed;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.eulerAngles -= new Vector3(0, 1, 0) * Time.deltaTime * Speed;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * Time.deltaTime * Speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= Vector3.up * Time.deltaTime * Speed;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = GameObject.Instantiate(bullet);
            newBullet.transform.position = transform.position;
        }
    }
}
