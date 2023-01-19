
using UnityEngine;

public class horn : MonoBehaviour
{
    [SerializeField] private AudioSource[] horns;
    private int currentHorn=0;

    public void playHorn()
    {
        horns[currentHorn].Play();
        if(currentHorn<horns.Length-1)
        currentHorn++;
        else
            currentHorn=0;
    }
}
