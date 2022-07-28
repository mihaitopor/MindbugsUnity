using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doOnClick()
    {
        animator.SetBool("isRun", true);
        StartCoroutine(DestroyBug());    
    }

    IEnumerator DestroyBug()
    {
        Debug.Log("Urmeaza 5 secunde");
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("RewardEsenceScene");
    }
}
