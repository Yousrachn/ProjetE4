using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Clickdeplacement : MonoBehaviour


{
    private Vector3 offset;
    private Camera cam;


    void Start()
    {
        cam = Camera.main;
    }


    void OnMouseDown()
    {
        // Calculer l'offset entre la position de l'objet et celle de la souris
        offset = transform.position - GetMouseWorldPos();
    }


    void OnMouseDrag()
    {
        // Déplacer l'objet avec la souris en maintenant l'offset
        Vector3 newPosition = GetMouseWorldPos() + offset;
        newPosition.z = 0; // Assurez-vous que l'objet reste sur le même plan (2D)
        transform.position = newPosition;
    }


    Vector3 GetMouseWorldPos()
    {
        // Convertir la position de la souris à l'écran en position dans le monde
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = -cam.transform.position.z; // distance de la caméra à l'objet sur l'axe Z (doit être négative si la caméra regarde vers l'objet)
        return cam.ScreenToWorldPoint(mousePoint);
    }
}

