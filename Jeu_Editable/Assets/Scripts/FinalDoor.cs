using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public Dialog dialog;
    public GameObject machineInterface;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckIfCanOpen() {
       bool alienIsFree = GameObject.FindGameObjectWithTag("Alien").GetComponent<AlienFollow>().following;
       bool logsAreDeleted = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().logsDeleted;

       if (alienIsFree && logsAreDeleted) {
            machineInterface.GetComponent<OpenUI>().PauseAndOpenUI();
       } else {
        DialogMangager.Instance.ShowDialog(dialog);
       }
    }
}
