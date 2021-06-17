using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Vector3 Dest = new Vector3(0, 0, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Animator>().Play("JUMP00");

        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Animator>().SetBool("IsBack", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            GetComponent<Animator>().SetBool("IsBack", false);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Animator>().SetBool("IsFront", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            GetComponent<Animator>().SetBool("IsFront", false);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("IsFront", true);
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("IsFront", false);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("IsFront", true);
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("IsFront", false);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
        //if (Input.GetKey(KeyCode.A))
        //{
            
        //    transform.eulerAngles = Vector3.RotateTowards(transform.eulerAngles, new Vector3(0, 90, 0), 0, Time.deltaTime * 100);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{

        //    transform.eulerAngles = Vector3.RotateTowards(transform.eulerAngles, new Vector3(0, 180, 0), 0, Time.deltaTime * 100);
        //}

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

                Dest = hit.point;
            }
        }

        Vector3 prevPos = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, Dest, Time.deltaTime);
        transform.forward = (Dest - transform.position).normalized;

        if (Time.deltaTime >= (Dest - transform.position).magnitude)
        {
            GetComponent<Animator>().SetBool("IsFront", false);
            Dest = Vector3.zero;
        }
        else
        {
            GetComponent<Animator>().SetBool("IsFront", true);
        }

        if (GetComponent<Animator>().GetBool("IsBack"))
        {
            transform.position -= transform.forward * Time.deltaTime;
        }
        else if (GetComponent<Animator>().GetBool("IsFront"))
        {
            transform.position += transform.forward * Time.deltaTime;
        }
    }
}
