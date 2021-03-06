﻿/*
 * This file is part of alphaSynth.
 * Copyright (c) 2014, T3866, PerryCodes, Daniel Kuschny and Contributors, All rights reserved.
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3.0 of the License, or at your option any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library.
 */

using AlphaTab.IO;

namespace AlphaTab.Audio.Synth.Midi.Event
{
    class MetaNumberEvent : MetaEvent
    {
        public int Value { get; private set; }

        public MetaNumberEvent(int delta, byte status, byte metaId, int number)
            : base(delta, status, metaId, 0)
        {
            Value = number;
        }


        public override void WriteTo(IWriteable s)
        {
            s.WriteByte(0xFF);
            s.WriteByte((byte)MetaStatus);

            MidiFile.WriteVariableInt(s, 3);

            var b = new[]{
                (byte)((Value >> 16) & 0xFF), (byte)((Value >> 8) & 0xFF), (byte)((Value >> 0) & 0xFF)
            };
            s.Write(b, 0, b.Length);
        }
    }
}
