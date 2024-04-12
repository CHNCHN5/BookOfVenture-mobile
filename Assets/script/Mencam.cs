using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mencam : MonoBehaviour
{
    private Animator anima1;

    // Start is called before the first frame update
    void Start()
    {
        anima1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nxtbutton()
    {
        anima1.SetBool("dev", true);
        anima1.SetBool("dev1", false);
    }
    public void bckbutton()
    {
        anima1.SetBool("dev1", true);
        anima1.SetBool("dev", false);
    }
}
