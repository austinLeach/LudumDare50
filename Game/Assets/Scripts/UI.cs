using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public Slider foodSlider;
    public Slider waterSlider;
    public Slider godSlider;
    public Image godSliderFill;
    public Text duckLimitLabel;
    public Text moneyLabel;
    // Start is called before the first frame update
    void Start()
    {
        duckLimitLabel.text = "0 / 420";
        moneyLabel.text = "$0";
    }

    // Update is called once per frame
    void Update()
    {
        ChangeGodColor();
    }


    private void ChangeGodColor()
    {

        if (godSlider.value < .5)
            godSliderFill.color = Color.red;
        else if (godSlider.value >= .5)
            godSliderFill.color = Color.green;
    }

    public void UpdateSliders(string bar, int value)
    {

        if (bar.ToLower().Equals("god"))
        {
            godSlider.value += value;
            ChangeGodColor();
        }

        else if (bar.ToLower().Equals("water"))
        {
            waterSlider.value += value;
        }
        else
        {
            foodSlider.value += value;
        }
    }

    public void UpdateDuckText(int value)
    {
        duckLimitLabel.text = (value + int.Parse(moneyLabel.ToString().Substring(1))).ToString() + " / 100";
    } 

    public void UpdateMoneyText(int value)
    {
        moneyLabel.text = "$" + (value + int.Parse(moneyLabel.ToString().Substring(1))).ToString();
    }

    public void TestMoneyIncrease()
    {
        moneyLabel.text = "$" + (int.Parse(moneyLabel.ToString().Substring(1)) + 10).ToString();
    }

    public void TestMoneydecrease()
    {
        moneyLabel.text = "$" + (int.Parse(moneyLabel.ToString().Substring(1)) + 10).ToString();
    }

    public void TestDuckTextIncrease()
    {
        duckLimitLabel.text = (1 + int.Parse(moneyLabel.ToString().Substring(1))).ToString() + " / 100";

    }

    public void TestDuckTextDecrease()
    {
        duckLimitLabel.text = (-1 + int.Parse(moneyLabel.ToString().Substring(1))).ToString() + " / 100";
    }

}
