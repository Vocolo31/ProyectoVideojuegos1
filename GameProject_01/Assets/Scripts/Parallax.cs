using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;
    [SerializeField] private float multiplicadorVelocidad = 0.1f;
    private Vector2 offset;
    private Material material;
    private Transform jugadorTransform;
    private Vector2 ultimaPosicion;
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        jugadorTransform = GameObject.FindGameObjectWithTag("Player").transform;
        ultimaPosicion = jugadorTransform.position;
    }
    private void Update()
    {
        Vector2 posicionActual = jugadorTransform.position;
        Vector2 desplazamiento = (posicionActual - ultimaPosicion) * velocidadMovimiento;

        material.mainTextureOffset += desplazamiento;

        ultimaPosicion = posicionActual;
    }
}
