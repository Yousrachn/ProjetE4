using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToolTipsMangager : MonoBehaviour
{

    [SerializeField] GameObject toolTip;

    [SerializeField] GameObject player;


    public void ShowToolTip(bool active) {
        toolTip.SetActive(active);
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = player.transform.position.x + 2;
        newPosition.y = player.transform.position.y + 2;
        toolTip.transform.position = newPosition;
    }
}
