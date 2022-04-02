using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public DragDrop dragDrop;
    // 5 damage upgrades, all 5 allow for enough damage to kill the boss
    // 5 pick up upgrades, 1, 2, 5, 10, 20

    private void Start() {
        dragDrop = dragDrop.GetComponent<DragDrop>();
    }
    public void Damage1() {
        if (GlobalVariables.money >= 100) {
            GlobalVariables.money -= 100;
            GlobalVariables.upgrades.Add("1");
        }
    }
    public void Damage2() {
        if (GlobalVariables.money >= 200) {
            GlobalVariables.money -= 200;
            GlobalVariables.upgrades.Add("2");
        }
    }
    public void Damage3() {
        if (GlobalVariables.money >= 300) {
            GlobalVariables.money -= 300;
            GlobalVariables.upgrades.Add("3");
        }
    }
    public void Damage4() {
        if (GlobalVariables.money >= 400) {
            GlobalVariables.money -= 400;
            GlobalVariables.upgrades.Add("4");
        }
    }
    public void Damage5() {
        if (GlobalVariables.money >= 500) {
            GlobalVariables.money -= 500;
            GlobalVariables.upgrades.Add("5");
        }
    }

    public void pickUpgrade1() {
        // if (GlobalVariables.money >= 100) {
        //     GlobalVariables.money -= 100;
            dragDrop.numberCanPickUp = 2;
        // }
    }
    public void pickUpgrade2() {
        if (GlobalVariables.money >= 100) {
            GlobalVariables.money -= 100;
            dragDrop.numberCanPickUp = 5;
        }
    }
    public void pickUpgrade3() {
        if (GlobalVariables.money >= 100) {
            GlobalVariables.money -= 100;
            dragDrop.numberCanPickUp = 10;
        }
    }
    public void pickUpgrade4() {
        if (GlobalVariables.money >= 100) {
            GlobalVariables.money -= 100;
            dragDrop.numberCanPickUp = 15;
        }
    }
    public void pickUpgrade5() {
        if (GlobalVariables.money >= 100) {
            GlobalVariables.money -= 100;
            dragDrop.numberCanPickUp = 20;
        }
    }
}
