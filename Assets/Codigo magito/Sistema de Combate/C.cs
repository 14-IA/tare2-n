using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class C : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemigosRestantes;
    public TextMeshPro numeros;

    void Start()
    {
        numeros.text = "" + enemigosRestantes;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemies == null)
        {
            enemigosRestantes = enemies.Length;
            numeros.text = "" + enemigosRestantes;
        }
    }
}
