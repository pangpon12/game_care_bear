using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant_value : MonoBehaviour
{
    public string name_of_plant;
        public int plant_ID;

    // Start is called before the first frame update
    void Start()
    {
        plant_ID = GetInstanceID();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
