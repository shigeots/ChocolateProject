using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashQuantityHUDController : MonoBehaviour {

    [SerializeField] private Text _dashText;

    private void Awake() {
        EventObserver.UpdateDashTextEvent += UpdateText;
    }

    private void UpdateText(int amountOfChocolate) {
        _dashText.text = "x " + amountOfChocolate.ToString();
    }
}
