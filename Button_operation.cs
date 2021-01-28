using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_operation : MonoBehaviour
{

   // [SerializeField] public bool hasGenerateBeenPressed = false;
    [SerializeField] public bool hasResetBeenPressed = false;
    // public bool iterationHasChanged = false;
    [SerializeField] private l_system TreeSpawner;


    [SerializeField] private Text TreeText;
    [SerializeField] private Text IterationText;
    [SerializeField] private Text LengthText;
    [SerializeField] private Text AngleText;


    public void Update()
    {
       
      
    }

    public void TitleDown()
    {
        if (TreeSpawner.title > 1)
        {
            TreeSpawner.title--;
            TreeSpawner.hasTreeChanged = true;
            TreeText.text = ("Tree" + TreeSpawner.title);

        }
    }

    public void TitleUp()
    {
        if (TreeSpawner.title < 8)
        {
            TreeSpawner.title++;
           // Debug.Log("treenumber:" + TreeSpawner.title);
            TreeSpawner.hasTreeChanged = true;
            TreeText.text = ("Tree" + TreeSpawner.title);


        }
        else
        {
            Debug.Log("numbere too big");
        }
    }

    public void IterationUP ()
    {
        if(TreeSpawner.iteration <8 )
        {
            TreeSpawner.iteration++;
            //iterationHasChanged = true;
            IterationText.text = TreeSpawner.iteration.ToString();

        }

    }

    public void IterationDown()
    {
        if (TreeSpawner.iteration >1)
        {
            TreeSpawner.iteration--;
          //  iterationHasChanged = true;
            IterationText.text = TreeSpawner.iteration.ToString();
        }

    }

    public void AngleUp()
    {
        TreeSpawner.angle++;
        AngleText.text = TreeSpawner.angle.ToString() + "°";
    }
    public void AngleDown()
    {
        TreeSpawner.angle--;
        AngleText.text = TreeSpawner.angle.ToString() + "°";
    }

    public void LengthUp()
    {
        TreeSpawner.length += .1f;
        LengthText.text = TreeSpawner.length.ToString();
    }
    public void LengthDown()
    {
        if (TreeSpawner.length > 0)
        {
            TreeSpawner.length -= .1f;
            LengthText.text = TreeSpawner.length.ToString();
        }
    }

    /*  public void GenerateNew()
      {
          hasGenerateBeenPressed = true;
      }*/

}
