using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovementXThrone : MonoBehaviour
{

    [SerializeField] GameObject PatrolPoint1;
    [SerializeField] GameObject PatrolPoint2;
    private bool isSwap = false;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector3(-1,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if ((this.transform.localPosition.x < PatrolPoint1.transform.localPosition.x || this.transform.localPosition.x > PatrolPoint2.transform.localPosition.x) && isSwap == false)
        {
            this.GetComponent<Rigidbody2D>().velocity *= -1;
            StartCoroutine(SwapDirection());
        }
    }

    IEnumerator SwapDirection()
    {
        isSwap = true;
        yield return new WaitForSeconds(.1f);
        isSwap = false;
    }
}
