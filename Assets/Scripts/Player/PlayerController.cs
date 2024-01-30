using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Lerp")]
    public Transform target;
    public float learpSpeed = 1f;

    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndline = "EndLine";

    public GameObject startScreen;
    public GameObject endScreen;

    //private
    private bool _canRun = false;
    private Vector3 _pos;






    void Update()
    {
        if (!_canRun) { return; }

        _pos = target.position;

        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

  
       


        transform.position = Vector3.Lerp(transform.position, _pos, learpSpeed * Time.deltaTime);


        transform.Translate(transform.forward * speed *Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
      
        if(other.transform.tag == tagToCheckEndline)
        {
            _canRun = false;
            endScreen.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagToCheckEnemy)
        {
            _canRun = false;
            endScreen.SetActive(true);
        }
    }


    public void StartToRun()
    {
        _canRun = true;
        startScreen.SetActive(false);
    }

}
