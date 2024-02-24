using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class click_detection : MonoBehaviour
{

  public string nextscene;


 public  List<string> collect = new List<string>();
 public  List<int> ID_check = new List<int>();
 public  List<GameObject> gameObject_select = new List<GameObject>();
        public TMP_Text  _title;

 public   AudioSource audioData;

 public   AudioClip audio_success;
 public   AudioClip audio_select;

 public   GameObject transition_animation;
    Animator animator;



private int count = 0;

 public  string word_for_check ;
    // Start is called before the first frame update
    void Start()
    {

  transition_animation =      GameObject.FindGameObjectWithTag("transiton");

            animator = transition_animation.GetComponent<Animator>();
  
                  audioData = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
             // Check for mouse click
        if (Input.GetMouseButton(0))
        {
            // Cast a ray fromcollect the mouse position
            Vector3  ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 touchPos = new Vector2(ray.x, ray.y);

            Collider2D  hit = Physics2D.OverlapPoint(touchPos);

            // Check if the ray hits a collider
            if (hit != null)
            {



 if (hit.tag == "plant")
        {
        

 GameObject clickedObject = hit.GetComponent<Collider2D>().gameObject;



 int ID_of_object =  clickedObject.GetComponent<plant_value>().plant_ID;
        if (!ID_check.Contains(ID_of_object))
        {


 add_text(clickedObject);


            // If the list doesn't contain the integer, add it
            ID_check.Add(ID_of_object);

gameObject_select.Add(clickedObject);
 clickedObject.GetComponent<SpriteRenderer>().color =  new Color (1, 1, 0, 1); 


      //  audioData.PlayOneShot(audio_select, 0.7f);

            Debug.Log("Added " + ID_of_object + " to the list.");
        }
        else
        {
            // If the list already contains the integer, do something else or log a message
            Debug.Log(ID_of_object + " is already in the list. Did not add.");
        }


            }}}

            if(Input.GetMouseButtonUp(0))
            {
                

              for (int j = 0; j < collect.Count; j++)
  {
    if(word_for_check == collect[j])
    {

        count += 1;

//                audioData.PlayOneShot(audio_success, 0.7f);

                            for (int i = 0; i < gameObject_select.Count; i++)
    {

  
          Destroy(gameObject_select[i]);
    }
    }
  
    
   }


if(count ==  collect.Count){

// go to another scene
  transition_animation.SetActive(false);

        transition_animation.SetActive(true);


        Invoke("go_to_next_scene", 1.5f);

                Debug.Log("YOU ARE PASS!!");




}



  

if(gameObject_select != null){
                           for (int z = 0; z < gameObject_select.Count; z++)
    {
  
 gameObject_select[z].GetComponent<SpriteRenderer>().color =  new Color32 (217, 207, 166, 255); 
    } 
}

word_for_check = null ;
  _title.text = "";
gameObject_select.Clear();
                ID_check.Clear();
            }
    }


    void add_text(GameObject game_select){


            word_for_check += game_select.GetComponent<plant_value>().name_of_plant;

            _title.text  = word_for_check;


    }


    void go_to_next_scene (){
                SceneManager.LoadScene( nextscene);
        animator.SetBool("is_finish", true);
    }
}
