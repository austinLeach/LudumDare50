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
    public Image foodSliderFill;
    public Image waterSliderFill;
    public Text duckLimitLabel;
    public Text moneyLabel;
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        duckLimitLabel.text = GlobalVariables.population + " / 1000";
        moneyLabel.text = "$" + GlobalVariables.money;
        foodSlider.maxValue = GlobalVariables.sliderMax;
        waterSlider.maxValue = GlobalVariables.sliderMax;
        godSlider.maxValue = GlobalVariables.sliderMax;

        foodSlider.value = GlobalVariables.initialSliderValue;
        godSlider.value = GlobalVariables.initialSliderValue;// + 100;
        waterSlider.value = GlobalVariables.initialSliderValue;

       godSlider.maxValue = 250;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeGodColor();
        ChangeFoodColor();
        ChangeWaterColor();
        UpdateDuckText();
        UpdateMoneyText();
        UpdateSliders();
        SettingsActive();
    }


    private void ChangeGodColor()
    {
        if (godSlider.value < godSlider.maxValue * 0.25)
            godSliderFill.color = Color.red;
        else if (godSlider.value < godSlider.maxValue * 0.5)
            godSliderFill.color = new Color(1f, 0.6f, 0f);
        else if (godSlider.value >= godSlider.maxValue * 0.75)
            godSliderFill.color = Color.green;
    }
    private void ChangeWaterColor()
    {
        if (waterSlider.value < waterSlider.maxValue * 0.25)
            waterSliderFill.color = Color.red;
        else if (waterSlider.value >= waterSlider.maxValue * 0.75)
            waterSliderFill.color = new Color(0f, 0.490963f, 1f);
    }
    private void ChangeFoodColor()
    {
        if (foodSlider.value < foodSlider.maxValue * 0.25)
            foodSliderFill.color = Color.red;
        else
            foodSliderFill.color = new Color(0.7735849f, 0.5212242f, 0.09122462f);
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
        GlobalVariables.money += 1000000;
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

    public void SettingsActive()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(Panel.activeInHierarchy)
                Panel.SetActive(false);
            else
                Panel.SetActive(true);
        }
        
    }
}
