using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovePipe : MonoBehaviour
{
   [SerializeField] public float pipeSpeed = 0.65f;

    public void Update()
    {
        transform.position += Vector3.left * pipeSpeed * Time.deltaTime;
    }

}
