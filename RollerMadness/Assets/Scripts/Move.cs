using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   private Vector3 movement;
   [SerializeField] private float speed=8f;
    [SerializeField] private GameObject deadEffect;

    private Rigidbody rigidbody;
    private timemanager timeManager;

    // Start is called before the first frame update
    void Start()
    {

      rigidbody =GetComponent<Rigidbody>();
        timeManager = FindObjectOfType<timemanager>();
  
    }

    // Update is called once per frame
    void Update()
    {
        if(timeManager.gameover==false && timeManager.gameFinished==false )
        {
            MoveThePlayer();

        }
        if(timeManager.gameover || timeManager.gameFinished)
        {
            rigidbody.isKinematic = true;
            
        }
    }
    private void MoveThePlayer()
    {
                float  x= Input.GetAxis("Horizontal") * speed * Time.deltaTime;
           float  z= Input.GetAxis("Vertical") * speed * Time.deltaTime;     
  movement=new Vector3(x,0f,z);
      // transform.position += movement;    bunu kaldırmamızın sebebi rigidbody ile hareket edecek olmamız. Gereksizzz
      rigidbody.AddForce(movement);

    }
    private void OnDisable()
    {
        Instantiate(deadEffect, transform.position, transform.rotation);
    }
}
