using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborField : MonoBehaviour
{
    public Material isLife;
    public Material isDead;
    public List<GameObject> neighborsList = new ();
    public float neighborSearchRadius;
    public bool isAlive;
    public int countLive = 0;

    void Start()
    {
        RaycastHit[] neighbors = Physics.SphereCastAll(transform.position, neighborSearchRadius, Vector3.forward, neighborSearchRadius);

        foreach (RaycastHit neighbor in neighbors)
        {
            if (neighbor.collider.gameObject != gameObject)
            { 
                neighborsList.Add(neighbor.collider.gameObject);
            }
        }
    }
    void Update()
    {
        int count = 0;
        foreach(GameObject go in neighborsList)
        {
            if(go.GetComponent<NeighborField>().isAlive == false)
                count++;
        }
        countLive = count;
    }
}
