using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class click_before_play : MonoBehaviour
{

    public bool selected_animal;
        public bool selected_friut;

  public bool  handleButtonClicks;


 public   GameObject transition_animation;
    Animator animator;


 public Text  text_mode;


    public Button btn_animal;
    public Button btn_fruit;

    // Start is called before the first frame update
    void Start()
    {
        transition_animation.SetActive(false);

            animator = transition_animation.GetComponent<Animator>();
        //    DontDestroyOnLoad(light_);

            DontDestroyOnLoad(transform.gameObject);
                        DontDestroyOnLoad(transition_animation);


    }

    // Update is called once per frame
    void Update()
    {


    }
  public  void click_before(){

    }
 public   void select_me_animal(){
         //  handleButtonClicks= true; //Allow button clicks to be handled now
text_mode.text = "Select animal Mode";
       selected_animal = true;
              selected_friut = false;
    }
 public   void select_me_friut(){
  text_mode.text = "Select friut Mode";

       selected_friut = true;
              selected_animal = false;

    }
       public void NextScene()
    {
      if(selected_animal == true){
                transition_animation.SetActive(true);

        Invoke("go_to_animal", 1.5f);
        

      }
      
      if(selected_friut == true){
                transition_animation.SetActive(true);

        Invoke("go_to_fruit", 1.5f);


      }
    }



     void go_to_animal()
    {
        SceneManager.LoadScene("animal_1");
        animator.SetBool("is_finish", true);

    }

       void go_to_fruit()
    {
        SceneManager.LoadScene("fruit_1");
        animator.SetBool("is_finish", true);

    }


}
