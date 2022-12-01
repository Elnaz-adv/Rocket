using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillaor : MonoBehaviour
{
    Vector3 startingPoint;
    [SerializeField] Vector3 movingVector;
    float movingFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position;
        Debug.Log(transform.position);
        
    }

    // Update is called once per frame
    void Update()

    {
        if (period <= Mathf.Epsilon){return;}
        float sinRaw = Mathf.Sin(2*Mathf.PI* Time.time/period);
        movingFactor = (sinRaw +1)/2;   // Factor valu  between 0 and 1
        Vector3 offset = movingVector * movingFactor ;
        transform.position = startingPoint + offset;


    }
}
