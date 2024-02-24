using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;




public class go_to_next_scene : MonoBehaviour
{

    [SerializeField] InputField feedback1;

    string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfZNQ7umFev-Xo1G3pG78I3udEM9qSBKOy3Ey0WBhYJA0Vq7A/formResponse";
     public   AudioSource audioData;
 public   AudioClip audio_select;
 public   GameObject transition_animation;
    Animator animator;
 public   GameObject light_;


 void Start()
{

            animator = transition_animation.GetComponent<Animator>();
        //    DontDestroyOnLoad(light_);

            DontDestroyOnLoad(transform.gameObject);
                        DontDestroyOnLoad(transition_animation);

transition_animation.SetActive(false);

                audioData = GetComponent<AudioSource>();
}
      public void NextScene()
    {
        StartCoroutine(Post(feedback1.text));

        transition_animation.SetActive(true);

                audioData.PlayOneShot(audio_select, 0.7f);

        Invoke("load_next_scene", 1.5f);


    }


void load_next_scene(){
        SceneManager.LoadScene("select_type");
        animator.SetBool("is_finish", true);

}



    IEnumerator Post(string s1)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1334104522", s1);


        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        
        yield return www.SendWebRequest();

    }



}
