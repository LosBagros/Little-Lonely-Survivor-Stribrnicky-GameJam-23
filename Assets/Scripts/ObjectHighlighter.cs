using UnityEngine;
using System.Collections.Generic;
using cakeslice;

public class ObjectHighlighter : MonoBehaviour
{
    public float outlineThreshold = 10f; // Vzdálenost, ve které se bude objevovat outline
    public Collider triggerCollider; // Collider definující oblast, ve které se bude zobrazovat outline

    private List<Outline> outlines = new List<Outline>(); // Seznam objektù s outline

    private void OnTriggerEnter(Collider other)
    {
        // Najdeme komponentu Outline na objektu, který vstoupil do triggerCollideru
        var objWithOutline = other.GetComponent<Outline>();

        // Pokud se v collideru nachází objekt s outline a zatím není v seznamu, pøidáme ho
        if (objWithOutline != null && !outlines.Contains(objWithOutline))
        {
            outlines.Add(objWithOutline);
            objWithOutline.enabled = true; // Zobrazíme outline
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Najdeme komponentu Outline na objektu, který opustil triggerCollider
        var objWithOutline = other.GetComponent<Outline>();

        // Pokud se v collideru nachází objekt s outline a je v seznamu, odebereme ho
        if (objWithOutline != null && outlines.Contains(objWithOutline))
        {
            outlines.Remove(objWithOutline);
            objWithOutline.enabled = false; // Skryjeme outline
        }
    }
}
