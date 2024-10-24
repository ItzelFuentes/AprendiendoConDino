using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float velocidad = 2;
    public Renderer fondo;
    public GameObject col1;
    public GameObject estrella1;
    public GameObject concha1; 

    public List<GameObject> suelo;
    public List<GameObject> obstaculos;
    // Start is called before the first frame update
    void Start()
    {
        // Crear Mapa
        for (int i = 0; i < 21; i++)
        {
            suelo.Add(Instantiate(col1, new Vector2(-10 + i, -4), Quaternion.identity));
        }

        //Crear Obstaculos
        obstaculos.Add(Instantiate(estrella1, new Vector2(15, -3), Quaternion.identity));
        obstaculos.Add(Instantiate(concha1, new Vector2(20, -3), Quaternion.identity));

    }

    // Update is called once per frame
    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.015f, 0) * Time.deltaTime;

        // Mover Mapa
        for (int i = 0; i < suelo.Count; i++)
        {
            if (suelo[i].transform.position.x <= -10)
            {
                suelo[i].transform.position = new Vector3(10f, -4, 0);
            }
            suelo[i].transform.position = suelo[i].transform.position + new Vector3(-1, 0, 0) * velocidad * Time.deltaTime;
        }

        //Mover Obstaculos
        for (int i = 0; i < obstaculos.Count; i++)
        {
            if (obstaculos[i].transform.position.x <= -10)
            {
                float randomObs = Random.Range(10, 18);
                obstaculos[i].transform.position = new Vector3(randomObs, -3, 0);
            }
            obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1, 0, 0) * velocidad * Time.deltaTime;
        }
    }
}
