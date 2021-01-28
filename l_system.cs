using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System;


public class TransformInfo
{
    public Vector3 position;
    public Quaternion rotation;


}
//[Obsolete]
public class l_system : MonoBehaviour
{

    private const string axiom = "X"; 
    private Stack<TransformInfo> transformStack;
    private Dictionary<char, string> rules;
    private string currentstring = string.Empty;
    public int titleLastFrame;
    public int title = 1;
    private float[] randomRotationValues = new float[100];
    private List<GameObject> treeList = new List<GameObject>();
    private List<GameObject> treeReturnList = new List<GameObject>();
    private Vector3 initialPosition;
    private Quaternion initialRatation;


    [SerializeField] public float length=10f;
    [SerializeField] public float angle = 30f;
    [SerializeField] private GameObject branch;
    [SerializeField] private GameObject leaf;

    [SerializeField] public int iteration = 4;
    [SerializeField] private Button_operation button_Operation;
    public bool hasTreeChanged = false;


     private float Contrastlength;
     private float Contrastangle;
     private int Contrastiteration;

    private void Start()
    {
    //    branch.GetComponent<LineRenderer>().SetColors(Color.yellow, Color.yellow);

        Contrastlength = length;
        Contrastangle = angle;
        Contrastiteration = iteration;

        initialRatation = transform.rotation;
        initialPosition = transform.position;
        titleLastFrame = title;

        transformStack = new Stack<TransformInfo>();
        rules = new Dictionary<char, string>

        {
            { 'X', "F[+F]F[-F]F" },
            { 'F', "F[+F]F[-F]F" }
        };

        Generate();

        
    }



    private  void Update()
    {
        if (Contrastlength!= length || Contrastangle != angle ||
        Contrastiteration != iteration)
        {

            Contrastlength = length;
            Contrastangle = angle;
            Contrastiteration = iteration;
            Generate();
        }

        if (hasTreeChanged)
        {

            switch (title)
            {
                case 1:
                    SelectTreeOne();
                    hasTreeChanged = false;
                    break;

                case 2:
                    SelectTreeTwo();
                    hasTreeChanged = false;
                    break;

                case 3:
                    SelectTreeThree();
                    hasTreeChanged = false;
                    break;

                case 4:
                    SelectTreeFour();
                    hasTreeChanged = false;
                    break;

                case 5:
                    SelectTreeFive();
                    hasTreeChanged = false;
                    break;

                case 6:
                    SelectTreeSix();
                    hasTreeChanged = false;
                    break;
                case 7:
                    SelectTreeSeven();
                    hasTreeChanged = false;
                    break;
                case 8:
                    SelectTreeEight();
                    hasTreeChanged = false;
                    break;


                default:
                    SelectTreeOne();
                    hasTreeChanged = false;
                    break;
            }
        }
            else
            {
            Debug.Log("can not show the tree");

            }
           
        
    }

    public void Generate()
    {
        

        transform.position = initialPosition;
        transform.rotation= initialRatation;



        for (int i = treeList.Count - 1; i >= 0; i--)
        {
            treeList[i].SetActive(false);
            treeReturnList.Add(treeList[i]);
            treeList.RemoveAt(i);
        }



        currentstring = axiom;
        StringBuilder sb = new StringBuilder();

        for(int i=0; i<iteration; i++)
        {
            foreach (char c in currentstring)
            {
                sb.Append(rules.ContainsKey(c) ? rules[c] : c.ToString());

            }

            currentstring = sb.ToString();

            sb = new StringBuilder();

        }
        Debug.Log(currentstring);

        foreach (char c in currentstring)
        {
            switch (c)
            {
                case 'F':
                    Vector3 curPos = transform.position;
                    transform.Translate(Vector3.up * length);
                    
                    GameObject treeSegment;


                    int count = treeReturnList.Count;
                    if(count >= 1)
                    {
                        treeSegment = treeReturnList[count - 1];
                        treeSegment.SetActive(true);
                        treeReturnList.RemoveAt(count - 1);
                    }
                    else
                    {
                        treeSegment = Instantiate<GameObject>(branch);
                    }
                    treeList.Add(treeSegment);
                    treeSegment.GetComponent<LineRenderer>().SetPosition(0, curPos);
                    treeSegment.GetComponent<LineRenderer>().SetPosition(1, transform.position);
                    break;
                case 'X':
                    break;
                case '+':
                    transform.Rotate(Vector3.back * angle);
                    break;
                case '-':
                    transform.Rotate(Vector3.forward * angle);
                    break;
                case '[':
                    transformStack.Push(new TransformInfo
                    {
                        position = transform.position,
                        rotation = transform.rotation
                    });

                    break;
                case ']':
                    TransformInfo ti = transformStack.Pop();
                    transform.position = ti.position;
                    transform.rotation = ti.rotation;
                   // treeSegment = Instantiate<GameObject>(leaf);

                    break;

                default:
                    throw new InvalidOperationException("error");

            }

        }
    }
 

    private void SelectTreeOne()
    {
        
        rules = new Dictionary<char, string>
        {
             { 'X', "F[+F]F[-F]F" },
            { 'F', "F[+F]F[-F]F" }
        };

        Generate();
    }

    private void SelectTreeTwo()
    {
      
        rules = new Dictionary<char, string>
        {
            { 'X', "F[+F]F[-F][F]" },
            { 'F', "F[+F]F[-F][F]" }
        };

        Generate();
    }

    private void SelectTreeThree()
    {
        
        rules = new Dictionary<char, string>
        {
            { 'X', "FF-[-F+F+F]+[+F-F-F]" },
            { 'F', "FF-[-F+F+F]+[+F-F-F]" }
        };

        Generate();
    }

    private void SelectTreeFour()
    {
      
        rules = new Dictionary<char, string>
        {
            { 'X', "F[+X][-X]FX" },
            { 'F', "FF" }
          
        };

        Generate();
    }

    private void SelectTreeFive()
    {
      
        rules = new Dictionary<char, string>
        {
            { 'X', "F-[[X]+X]+F[+FX]-X" },
            { 'F', "FF" }
        };

        Generate();
    }

    private void SelectTreeSix()
    {
        
        rules = new Dictionary<char, string>
        {
             { 'X', "F[+X]F[-X]+X" },
            { 'F', "FF" }
          
        };

        Generate();
    }

    private void SelectTreeSeven()
    {

        rules = new Dictionary<char, string>
        {
            { 'X', "F[-X]+X" },
            { 'F', "FF" }


        };

        Generate();
    }

    private void SelectTreeEight()
    {
        rules = new Dictionary<char, string>
        {
             { 'X', "F-X-F" },
            { 'F', "X+F+X" }
          
        };

        Generate();
    }
}