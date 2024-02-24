using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class child_colum_count : MonoBehaviour
{

         public  List<Vector3> child_count = new List<Vector3>();

    // Start is called before the first frame update
    void Awake()
    {
        

        
    for (int i = 0; i < transform.childCount; i++)
    {
  
           child_count.Add(transform.GetChild(i).gameObject.transform.position);
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
