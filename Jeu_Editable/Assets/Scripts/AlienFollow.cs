using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class AlienFollow : MonoBehaviour
{
    public bool following = false;
    public float distance;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (following) {
            distance = Vector2.Distance(transform.position, target.transform.position);
            if (distance >= 2) {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 10 * Time.deltaTime);

            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        following = true;        
    }
}
