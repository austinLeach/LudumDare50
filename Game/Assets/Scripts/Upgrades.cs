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
                DamageButton.GetComponent<Text>().text = "Upgrade Damage 2";
            }
        }
        else if (hasDamage == 1) {
            if(Damage2()) {
                hasDamage = 2;
                DamageButton.GetComponent<Text>().text = "Upgrade Damage 3";
            }
        }
        else if (hasDamage == 2) {
            if(Damage3()) {
                hasDamage = 3;
                DamageButton.GetComponent<Text>().text = "Upgrade Damage 4";
            }
        }
        else if (hasDamage == 3) {
            if(Damage4()) {
                hasDamage = 4;
                DamageButton.GetComponent<Text>().text = "Upgrade Damage 5";
            }
        }
        else if (hasDamage == 4) {
            if(Damage5()) {
                hasDamage = 5;
                DamageButton.GetComponent<Text>().text = "Maxed Out Damage";
            }
        }
    }

    public void UpgradeButtonPressed() {
        if (hasUpgrade == 0) {
            if(pickUpgrade1()) {
                hasUpgrade = 1;
                UpgradeButton.GetComponent<Text>().text = "Upgrade Pointer 2";
            }
        }
        else if (hasUpgrade == 1) {
            if(pickUpgrade2()) {
                hasUpgrade = 2;
                UpgradeButton.GetComponent<Text>().text = "Upgrade Pointer 3";
            }
        }
        else if (hasUpgrade == 2) {
            if(pickUpgrade3()) {
                hasUpgrade = 3;
                UpgradeButton.GetComponent<Text>().text = "Upgrade Pointer 4";
            }
        }
        else if (hasUpgrade == 3) {
            if(pickUpgrade4()) {
                hasUpgrade = 4;
                UpgradeButton.GetComponent<Text>().text = "Upgrade Pointer 5";
            }
        }
        else if (hasUpgrade == 4) {
            if(pickUpgrade5()) {
                hasUpgrade = 5;
                UpgradeButton.GetComponent<Text>().text = "Maxed Out Pointer";
            }
        }
    }
    public bool Damage1() {
        // if (GlobalVariables.money >= 100) {
        //     GlobalVariables.money -= 100;
            GlobalVariables.upgrades.Add("1");
            return true;
        // }
    }
    public bool Damage2() {
        // if (GlobalVariables.money >= 200) {
        //     GlobalVariables.money -= 200;
            GlobalVariables.upgrades.Add("2");
            return true;
        // }
    }
    public bool Damage3() {
        // if (GlobalVariables.money >= 300) {
        //     GlobalVariables.money -= 300;
            GlobalVariables.upgrades.Add("3");
            return true;
        // }
    }
    public bool Damage4() {
        // if (GlobalVariables.money >= 400) {
        //     GlobalVariables.money -= 400;
            GlobalVariables.upgrades.Add("4");
            return true;
        // }
    }
    public bool Damage5() {
        // if (GlobalVariables.money >= 500) {
        //     GlobalVariables.money -= 500;
            GlobalVariables.upgrades.Add("5");
            return true;
        // }
    }

    public bool pickUpgrade1() {
        // if (GlobalVariables.money >= 100) {
        //     GlobalVariables.money -= 100;
            dragDrop.numberCanPickUp = 2;
            return true;
        // }
    }
    public bool pickUpgrade2() {
        // if (GlobalVariables.money >= 100) {
        //     GlobalVariables.money -= 100;
            dragDrop.numberCanPickUp = 5;
        // }
        return true;
    }
    public bool pickUpgrade3() {
        // if (GlobalVariables.money >= 100) {
        //     GlobalVariables.money -= 100;
            dragDrop.numberCanPickUp = 10;
        // }
        return true;
    }
    public bool pickUpgrade4() {
        // if (GlobalVariables.money >= 100) {
        //     GlobalVariables.money -= 100;
            dragDrop.numberCanPickUp = 15;
        // }
        return true;
    }
    public bool pickUpgrade5() {
        // if (GlobalVariables.money >= 100) {
        //     GlobalVariables.money -= 100;
            dragDrop.numberCanPickUp = 20;
        // }
        return true;
    }
}
