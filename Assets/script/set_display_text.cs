using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class set_display_text : MonoBehaviour
{

    public   TMP_Text  mText; 
    // Start is called before the first frame update
    void Start()
    {
         mText = gameObject.GetComponent<TMP_Text>();
mText.text = gameObject.GetComponentInParent<plant_value>( ).name_of_plant;
    }

}
