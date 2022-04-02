using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public DragDrop dragDrop;
    public GameObject UpgradeButton;
    public GameObject DamageButton;
    // 5 damage upgrades, all 5 allow for enough damage to kill the boss
    // 5 pick up upgrades, 1, 2, 5, 10, 20

    int hasDamage = 0;
    int hasUpgrade = 0;
    private void Start() {
        dragDrop = dragDrop.GetComponent<DragDrop>();
    }

    public void DamageButtonPressed() {
        if (hasDamage == 0) {
            if(Damage1()) {
                hasDamage = 1;
                DamageButton.GetComponent<Text>().text = "Egg-Quacker";
            }
        }
        else if (hasDamage == 1) {
            if(Damage2()) {
                hasDamage = 2;
                DamageButton.GetComponent<Text>().text = "Quack-19";
            }
        }
        else if (hasDamage == 2) {
            if(Damage3()) {
                hasDamage = 3;
                DamageButton.GetComponent<Text>().text = "Quack-tillery";
            }
        }
        else if (hasDamage == 3) {
            if(Damage4()) {
                hasDamage = 4;
                DamageButton.GetComponent<Text>().text = "M.O.A.Q";
            }
        }
        else if (hasDamage == 4) {
            if(Damage5()) {
                hasDamage = 5;
                DamageButton.GetComponent<Text>().text = "Quacked Out Damage";
            }
        }
    }

    public void UpgradeButtonPressed() {
        if (hasUpgrade == 0) {
            if(pickUpgrade1()) {
                hasUpgrade = 1;
                UpgradeButton.GetComponent<Text>().text = "Lasso";
            }
        }
        else if (hasUpgrade == 1) {
            if(pickUpgrade2()) {
                hasUpgrade = 2;
                UpgradeButton.GetComponent<Text>().text = "The Claw";
            }
        }
        else if (hasUpgrade == 2) {
            if(pickUpgrade3()) {
                hasUpgrade = 3;
                UpgradeButton.GetComponent<Text>().text = "Bigger Picker Upper";
            }
        }
        else if (hasUpgrade == 3) {
            if(pickUpgrade4()) {
                hasUpgrade = 4;
                UpgradeButton.GetComponent<Text>().text = "Quacuum";
            }
        }
        else if (hasUpgrade == 4) {
            if(pickUpgrade5()) {
                hasUpgrade = 5;
                UpgradeButton.GetComponent<Text>().text = "Maxed Out Grabber";
            }
        }
    }
    public bool Damage1() {
        if (GlobalVariables.money >= 100) {
            GlobalVariables.money -= 100;
            GlobalVariables.upgrades.Add("1");
            return true;
        }
        return false;
    }
    public bool Damage2() {
        if (GlobalVariables.money >= 200) {
            GlobalVariables.money -= 200;
            GlobalVariables.upgrades.Add("2");
            return true;
        }
        return false;
    }
    public bool Damage3() {
        if (GlobalVariables.money >= 300) {
            GlobalVariables.money -= 300;
            GlobalVariables.upgrades.Add("3");
            return true;
        }
        return false;
    }
    public bool Damage4() {
        if (GlobalVariables.money >= 400) {
            GlobalVariables.money -= 400;
            GlobalVariables.upgrades.Add("4");
            return true;
        }
        return false;
    }
    public bool Damage5() {
        if (GlobalVariables.money >= 500) {
            GlobalVariables.money -= 500;
            GlobalVariables.upgrades.Add("5");
            return true;
        }
        return false;
    }

    public bool pickUpgrade1() {
        if (GlobalVariables.money >= 100) {
            GlobalVariables.money -= 100;
            dragDrop.numberCanPickUp = 2;
            return true;
        }
        return false;
    }
    public bool pickUpgrade2() {
        if (GlobalVariables.money >= 100) {
            GlobalVariables.money -= 100;
            dragDrop.numberCanPickUp = 5;
            return true;
        }
        return false;
    }
    public bool pickUpgrade3() {
        if (GlobalVariables.money >= 100) {
            GlobalVariables.money -= 100;
            dragDrop.numberCanPickUp = 10;
            return true;
        }
        return false;
    }
    public bool pickUpgrade4() {
        if (GlobalVariables.money >= 100) {
            GlobalVariables.money -= 100;
            dragDrop.numberCanPickUp = 15;
            return true;
        }
        return false;
    }
    public bool pickUpgrade5() {
        if (GlobalVariables.money >= 100) {
            GlobalVariables.money -= 100;
            dragDrop.numberCanPickUp = 20;
            return true;
        }
        return false;
    }
}
