using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bonus : MonoBehaviour {

    public Text countText;

    private int count;

    public void setCount(int count)
    {
        this.count = count;
    }

    public int getCount()
    {
        return count;
    }

    // Use this for initialization
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            setCountText();
        }

    }

    public void setCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

}
