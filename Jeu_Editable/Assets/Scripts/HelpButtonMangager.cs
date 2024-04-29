using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HelpButtonMangager : MonoBehaviour
{

    [SerializeField] Dialog dialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {
        DialogMangager.Instance.ShowDialog(dialog);
        EventSystem.current.SetSelectedGameObject(null);
    }
}
