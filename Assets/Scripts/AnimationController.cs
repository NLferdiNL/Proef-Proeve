using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationController : MonoBehaviour
{
    Animator anim;
    int jumpHash = Animator.StringToHash("Jump");
    int runStateHash = Animator.StringToHash("Base Layer.Run");

    private void Start()
    {
        TimeKeeper.myTimeKeeper += NormalState;
        TimeKeeper.myTimeKeeper += WarningState;
        TimeKeeper.myTimeKeeper += DangerState;
        TimeKeeper.myTimeKeeper += EndState;
        anim = GetComponent<Animator>();
    }

    
        

    void NormalState(float animNumber)
    {
        print(animNumber);
        anim.SetFloat("Current_Time", animNumber);
        TimeKeeper.myTimeKeeper -= NormalState;
    }
    void WarningState(float animNumber)
    {
        print(animNumber);
        anim.SetFloat("Current_Time", animNumber);
        TimeKeeper.myTimeKeeper -= WarningState;
    }
    void DangerState(float animNumber)
    {
        print(animNumber);
        anim.SetFloat("Current_Time", animNumber);
        TimeKeeper.myTimeKeeper -= DangerState;
    }
    void EndState(float animNumber)
    {
        print(animNumber);
        anim.SetFloat("Current_Time", animNumber);
        TimeKeeper.myTimeKeeper -= EndState;
        SceneManager.LoadScene("MainMenu");
    }
}
