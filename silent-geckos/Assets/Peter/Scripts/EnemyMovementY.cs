using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovementY : MonoBehaviour
{

    [SerializeField] GameObject PatrolPoint1;
    [SerializeField] GameObject PatrolPoint2;
    private bool isSwap = false;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localPosition.y < PatrolPoint1.transform.localPosition.y || this.transform.localPosition.y > PatrolPoint2.transform.localPosition.y && isSwap == false)
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
