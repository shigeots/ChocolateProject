using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashQuantityHUDController : MonoBehaviour {

    #region Private properties

    [SerializeField] private Text _dashText;

    #endregion

    #region Main methods

    private void Awake() {
        EventObserver.UpdateDashTextEvent += UpdateText;
    }

    private void OnDestroy() {
        EventObserver.UpdateDashTextEvent -= UpdateText;
    }

    #endregion

    #region Private methods

    private void UpdateText(int amountOfChocolate) {
        _dashText.text = "x " + amountOfChocolate.ToString();
    }

    #endregion
}
