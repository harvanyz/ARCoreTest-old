using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube1BehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        //transform.Rotate(0, 1, 0, Space.Self);
    }
}
