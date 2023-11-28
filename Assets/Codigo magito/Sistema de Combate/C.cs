using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class C : MonoBehaviour
{
    public int enemigosRestantes;
    public TextMeshPro numeros;

    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemigosRestantes = enemies.Length;
        numeros.text = enemigosRestantes.ToString();
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemigosRestantes = enemies.Length;
        numeros.text = enemigosRestantes.ToString();

        if (enemigosRestantes == 0)
        {
            CambiarEscena(); 
        }
    }

    void CambiarEscena()
    {
        
    }
}
