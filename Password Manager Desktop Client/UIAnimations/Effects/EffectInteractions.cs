﻿namespace Password_Manager_Desktop_Client.UIAnimations.Effects;

[Flags]
public enum EffectInteractions
{
    X = 1,
    Y = 2,
    WIDTH = 8,
    HEIGHT = 4,
    COLOR = 16,
    TRANSPARENCY = 32,
    LOCATION = X | Y,
    SIZE = WIDTH | HEIGHT,
    BOUNDS = X | Y | WIDTH | HEIGHT
}

