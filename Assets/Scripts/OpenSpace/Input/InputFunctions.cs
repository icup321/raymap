﻿using UnityEngine;
using System.Collections;
using System;

namespace OpenSpace.Input {
    public abstract class InputFunctions {

        public enum FunctionType {
            Unknown,
            And,
            Or,
            Not,
            KeyJustPressed,
            KeyJustReleased,
            KeyPressed,
            KeyReleased,
            ActionJustValidated,
            ActionJustInvalidated,
            ActionValidated,
            ActionInvalidated,
            PadJustPressed,
            PadJustReleased,
            PadPressed,
            PadReleased,
            JoystickAxeValue,
            JoystickAngularValue,
            JoystickTrueNormValue,
            JoystickCorrectedNormValue,
            JoystickJustPressed,
            JoystickJustReleased,
            JoystickPressed,
            JoystickReleased,
            JoystickOrPadJustPressed,
            JoystickOrPadJustReleased,
            JoystickOrPadPressed,
            JoystickOrPadReleased,
            MouseAxeValue,
            MouseAxePosition,
            MouseJustPressed,
            MouseJustReleased,
            MousePressed,
            Sequence,
            SequenceKey,
            SequenceKeyEnd,
            SequencePad,
            SequencePadEnd
        }

        public static FunctionType[] functionTypesSE = new FunctionType[] {
            FunctionType.Unknown,
            FunctionType.And,
            FunctionType.Or,
            FunctionType.Not,
            FunctionType.KeyJustPressed,
            FunctionType.KeyJustReleased,
            FunctionType.KeyPressed,
            FunctionType.KeyReleased,
            FunctionType.JoystickAxeValue,
            FunctionType.JoystickAngularValue,
            FunctionType.JoystickTrueNormValue,
            FunctionType.JoystickCorrectedNormValue,
            FunctionType.JoystickJustPressed,
            FunctionType.JoystickJustReleased,
            FunctionType.JoystickPressed,
            FunctionType.JoystickReleased,
            FunctionType.JoystickOrPadJustPressed,
            FunctionType.JoystickOrPadJustReleased,
            FunctionType.JoystickOrPadPressed,
            FunctionType.JoystickOrPadReleased,
            FunctionType.MouseAxeValue,
            FunctionType.MouseAxePosition,
            FunctionType.MouseJustPressed,
            FunctionType.MouseJustReleased,
            FunctionType.MousePressed,
            FunctionType.Sequence,
            FunctionType.SequenceKey,
            FunctionType.SequenceKeyEnd,
            FunctionType.SequencePad,
            FunctionType.SequencePadEnd
        };

        public static FunctionType GetFunctionType(uint index) {
            try {
                if (Settings.s.game == Settings.Game.TTSE) return functionTypesSE[index];
                return (FunctionType)(index);
            } catch (Exception) {
                return FunctionType.Unknown;
            }
        }
    }
}