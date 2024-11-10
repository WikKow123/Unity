using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    private List<Vector3> positions = new List<Vector3>();

    public int numberOfObjects = 10;  
    public float delay = 3.0f;        
    public GameObject block;          
    public Material[] materials;      

    private int objectCounter = 0; 

    void Start()
    {

        float platformSizeX = transform.localScale.x * 10f; 
        float platformSizeZ = transform.localScale.z * 10f; 

        List<float> pozycje_x = new List<float>(Enumerable.Range(0, (int)platformSizeX).OrderBy(x => Random.value).Take(numberOfObjects).Select(x => x - platformSizeX / 2));
        List<float> pozycje_z = new List<float>(Enumerable.Range(0, (int)platformSizeZ).OrderBy(z => Random.value).Take(numberOfObjects).Select(z => z - platformSizeZ / 2));
        for (int i = 0; i < numberOfObjects; i++)
        {
            positions.Add(new Vector3(pozycje_x[i], 0.5f, pozycje_z[i]));
        }

        StartCoroutine(GenerujObiekt());
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("Wywo³ano coroutine");

        foreach (Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(block, pos, Quaternion.identity);

            if (materials.Length > 0)
            {
                Material randomMaterial = materials[Random.Range(0, materials.Length)];
                newBlock.GetComponent<Renderer>().material = randomMaterial;
            }

            objectCounter++;
            yield return new WaitForSeconds(delay);
        }
    }
}

