using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventObserver {

    public static Action GetChocolateEvent;

    public static Action<int> UpdateDashTextEvent;

    public static Action RespawnPlayerEvent;
}
