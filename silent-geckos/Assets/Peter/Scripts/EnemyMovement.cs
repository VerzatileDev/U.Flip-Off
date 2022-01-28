using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] GameObject PatrolPoint1;
    [SerializeField] GameObject PatrolPoint2;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector3(1,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localPosition.x < PatrolPoint1.transform.localPosition.x || this.transform.localPosition.x > PatrolPoint2.transform.localPosition.x)
        {
            SwapDirection();
        }
    }

    void SwapDirection()
    {
        this.GetComponent<Rigidbody2D>().velocity *= -1;
        this.transform.localScale = new Vector3(this.transform.localScale.x * -1,1,1);
    }
}
