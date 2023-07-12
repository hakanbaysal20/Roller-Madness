using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    
    [SerializeField] private float speed=3f;
    [SerializeField] private float stopDistance = 1;
    [SerializeField] private GameObject deadEffect;

    private Transform target;
   
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
       



    }

    // Update is called once per frame
    void Update()
    {
      

       
     if(target != null)
        {
            
            transform.LookAt(target);
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > stopDistance)
            {

                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }

        



    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Destroy(collision.gameObject);
            timemanager timeManager = FindObjectOfType<timemanager>();
            timeManager.gameover = true;
        }
    }
    private void OnDisable()
    {
        Instantiate(deadEffect, transform.position, transform.rotation);
    }
}
