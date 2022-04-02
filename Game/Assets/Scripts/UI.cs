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
        duckLimitLabel.text = GlobalVariables.population + " / 1000";
        moneyLabel.text = "$" + GlobalVariables.money;
        foodSlider.maxValue = GlobalVariables.sliderMax;
        waterSlider.maxValue = GlobalVariables.sliderMax;
        godSlider.maxValue = GlobalVariables.sliderMax;

        foodSlider.value = GlobalVariables.initialSliderValue;
        godSlider.value = GlobalVariables.initialSliderValue;
        waterSlider.value = GlobalVariables.initialSliderValue;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeGodColor();
        UpdateDuckText();
        UpdateMoneyText();
        UpdateSliders();
    }


    private void ChangeGodColor()
    {

        if (godSlider.value < .5 * GlobalVariables.sliderMax)
            godSliderFill.color = Color.red;
        else if (godSlider.value >= .5 * GlobalVariables.sliderMax)
            godSliderFill.color = Color.green;
    }

    private void UpdateSliders()
    {
        godSlider.value = GlobalVariables.godHappiness;
        foodSlider.value = GlobalVariables.food;
        waterSlider.value = GlobalVariables.water;
    }

    public void UpdateDuckText()
    {
        duckLimitLabel.text = GlobalVariables.population + " / 1000";
    } 

    public void UpdateMoneyText()
    {
        moneyLabel.text = "$" + GlobalVariables.money;
    }

    public void TestMoneyIncrease()
    {
        GlobalVariables.money += 10;
        //moneyLabel.text = "$" + GlobalVariables.money;
    }

    public void TestMoneydecrease()
    {
        GlobalVariables.money -= 10;
        //moneyLabel.text = "$" + GlobalVariables.money;
    }

    public void TestDuckTextIncrease()
    {
        GlobalVariables.population += 10;
        //duckLimitLabel.text = (int.Parse(duckLimitLabel.text.Substring(0, 2)) + 10).ToString() + " / 420";

    }

    public void TestDuckTextDecrease()
    {
        GlobalVariables.population -= 10;
        //duckLimitLabel.text = (int.Parse(duckLimitLabel.text.Substring(0,2)) + 10).ToString() + " / 420";
    }
    /*
     * no functionality here
     */
    public void UpgradeBuilding()
    {

    }

}
