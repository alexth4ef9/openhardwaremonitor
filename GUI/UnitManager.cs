﻿/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2012 Michael Möller <mmoeller@openhardwaremonitor.org>
	
*/

using System;
using OpenHardwareMonitor.Common;

namespace OpenHardwareMonitor.GUI {

  public enum TemperatureUnit {
    Celsius = 0,
    Fahrenheit = 1
  }

  public class UnitManager {

    private UISettings settings;
    private TemperatureUnit temperatureUnit;

    public UnitManager(ISettings settings) {
      this.settings = new UISettings(settings);
      this.temperatureUnit = (TemperatureUnit)this.settings.GetValue("TemperatureUnit",
        (int)TemperatureUnit.Celsius);
    }

    public TemperatureUnit TemperatureUnit {
      get { return temperatureUnit; }
      set {
        this.temperatureUnit = value;
        this.settings.SetValue("TemperatureUnit", (int)temperatureUnit);
      }
    }

    public static float? CelsiusToFahrenheit(float? valueInCelsius) {
      return valueInCelsius * 1.8f + 32;
    }
  }
}
