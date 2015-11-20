using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bonus : MonoBehaviour {

    private GameObject zero, one, two, three, four, five, six;
    private GameObject[] ar = new GameObject[7];
    private int[] rdArr;
    private int numb1;
    private bool checkRepeate = true;



    public void setUp()
    {
        zero = GameObject.Find("Candy two");
        one = GameObject.Find("Candy two (1)");
        two = GameObject.Find("Candy two (2)");
        three = GameObject.Find("Candy two (3)");
        four = GameObject.Find("Candy two (4)");
        five = GameObject.Find("Candy two (5)");
        six = GameObject.Find("Candy two (6)");

        ar[0] = zero;
        ar[1] = one;
        ar[2] = two;
        ar[3] = three;
        ar[4] = four;
        ar[5] = five;
        ar[6] = six;

    }

    public void setCandyToTure()
    {
        rdArr = new int[ar.Length / 2 + 1];


        // Random number from 1  to ar.length - 1

       // numb1 = Random.Range(1, ar.Length - 1);

        for (int i = 0; i < rdArr.Length; i++)
        {
            // i is inner look index for rdArr.length

            numb1 = Random.Range(1, ar.Length - 1);

            if (i == 0)
            {
                ar[i].SetActive(true);
               // rdArr[i] = i;
            }


            else if (i == 1)
            {
                rdArr[i] = numb1;
                ar[rdArr[i]].SetActive(true);
            }

            else if (i > 1)
            {
                //inorder to check new value is not a repeat value

                while (checkRepeate == true)
                {
                    for (int ii = 1; ii < rdArr.Length; ii++)
                    {
                        if (numb1 == rdArr[ii])
                        {
                            checkRepeate = true;
                            numb1 = Random.Range(1, ar.Length - 1);
                            break;
                        }

                        else
                            checkRepeate = false;

                    }


                }

                if(checkRepeate == false)
                {
                    rdArr[i] = numb1;
                    ar[rdArr[i]].SetActive(true);
                }

                checkRepeate = true;
            }
        }
       
    }

    public void SetActiveFalse()
    {
        zero.SetActive(false);
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);
        four.SetActive(false);
        five.SetActive(false);
        six.SetActive(false);

    }



    // Use this for initialization
    public void OnTriggerEnterBonus(Collider other, Text bonusCountText, int bonusCount)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            bonusCount += 1;
            setBonusCountText(bonusCountText, bonusCount);
        }

    }

    public void setBonusCountText(Text bonusCountText, int bonusCount)
    {
        bonusCountText.text = "Count: " + bonusCount.ToString();
    }

}
