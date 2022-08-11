using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFields : MonoBehaviour
{
    public GameObject fieldPrefab;
    public int countField = 2000;
    public float radius;
    public Material isLife;
    public Material isDead;
    public GameObject [] sfereFilds;
    bool[] isAlive;

    public float deltaTime;
    private float startTime = 1f;

    void Start()
    {
        sfereFilds = new GameObject[countField];

        float phi = (Mathf.Sqrt(5) + 1) / 2 - 1;
        float ga = phi * 2 * Mathf.PI;
        float lon;
        float lat;

         for (int  i= 0; i < countField; i++)
         {
            lon = ga * (float)i;
            lat = Mathf.Asin((float)-1.0 + (float)2.0 * (float)i / (countField + 1));
            float x = Mathf.Cos(lon) * Mathf.Cos(lat);
            float y = Mathf.Sin(lon) * Mathf.Cos(lat);
            float z = Mathf.Sin(lat);

            Vector3 pos = (new Vector3(x, y, z) * radius);
            GameObject field = Instantiate(fieldPrefab);
            field.name = $"Field{(i)}";
            field.transform.position = pos;
            sfereFilds[i] = field;
            int lifeOreDead = Random.Range(0, 2);
            if (lifeOreDead == 0)
            {
               field.GetComponent<Renderer>().material = isDead;
               field.GetComponent<NeighborField>().isAlive = false;
            }
            else
            {
                field.GetComponent<Renderer>().material = isLife;
                field.GetComponent<NeighborField>().isAlive = true;
            }
         }
 
        isAlive = new bool[countField];
        for(int i = 0; i < countField; i++)
        {
            isAlive[i] = sfereFilds[i].GetComponent<NeighborField>().isAlive;
        }
    }
    void Update()
    {
        if (Time.time > startTime)
        {
            for(int i = 0; i < countField; i++)
            {
               int countLive = sfereFilds[i].GetComponent<NeighborField>().countLive;
               if (sfereFilds[i].GetComponent<NeighborField>().isAlive == true)
               {
                    if (countLive > 3 || countLive < 2)
                    {
                        isAlive[i] = false;
                    }
               }
               if(sfereFilds[i].GetComponent<NeighborField>().isAlive == false)
               {
                   if (countLive == 3)
                   {
                        isAlive[i] = true;
                   }
               }
            }
            for(int i = 0; i < countField; i++)
            {
                if (isAlive[i])
                {
                    sfereFilds[i].GetComponent<Renderer>().material = isLife;
                    sfereFilds[i].GetComponent<NeighborField>().isAlive = true;
                }
                else
                {
                    sfereFilds[i].GetComponent<Renderer>().material = isDead;
                    sfereFilds[i].GetComponent<NeighborField>().isAlive = false;
                }
            }

           startTime = Time.time + deltaTime;
        }
    }
}
