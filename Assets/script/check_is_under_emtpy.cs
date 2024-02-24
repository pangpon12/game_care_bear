using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_is_under_emtpy : MonoBehaviour
{
         public  List<Vector3> parent_script = new List<Vector3>();

public int object_range;

public GameObject range_obj;

public bool isMissing;


public bool isMissing_not_in_range;
    // Start is called before the first frame update
    void Start()
    {
       
      parent_script =   gameObject.GetComponentInParent<child_colum_count>().child_count;
            for (var i = 0; i < parent_script.Count; i++){
        if(parent_script[i] == transform.position){
            // not doing anything here at the moment

object_range = i; 

             }
            }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

         isMissing = ReferenceEquals(range_obj, null) ? false : (range_obj ? false : true);






           RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        Debug.DrawRay(transform.position, Vector2.down, Color.green,1.7f);




        // If it hits something...
        if (hit.collider != null )
        {

            float distance = Mathf.Abs(hit.point.y - transform.position.y);

     Debug.Log("distance " + distance);

   //If the object hit is less than or equal to 6 units away from this object.
            if (hit.distance <= 1.7f && hit.collider != null)
            {
                isMissing_not_in_range = false;
                Debug.Log("Enemy In Range!");
                range_obj = hit.collider.gameObject;
            }
            else{
                                Debug.Log("Enemy Not In Range!");
isMissing_not_in_range = true;
                if(parent_script[object_range+1] != null){

                  


                  transform.position = parent_script[object_range+1];
object_range = object_range +1 ;



                }
            }
        }
   
    }
}
