using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float camerafollowspeed=5f;   //kamera takibi hızı
  

    private Vector3 offsetVector;

    // Start is called before the first frame update
    void Start()
    {
       // offsetVector=transform.position - target.position;  //target kamera-player mesafesi
     offsetVector= CalculateOffSet(target);
    }

    // Update is called once per frame
    void FixedUpdate() //fixedupdate move scriptindeki updatesinden sonra çalışması icin eklendi. Aynı anda calıstıgında titreme olur
    {
     if(target !=null)
        {
            MoveTheCamera();
        }
      
    
    }
    private void MoveTheCamera()
    {
    Vector3 targetToMove = target.position+offsetVector;
        transform.position = Vector3.Lerp(transform.position,targetToMove,camerafollowspeed*Time.deltaTime);    
        transform.LookAt(target.transform.position);

    }
    private  Vector3 CalculateOffSet(Transform newTarget)
    {
        return transform.position - newTarget.position;  //target kamera-player mesafesi


      
    }
}
