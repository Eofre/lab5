﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Objects
{
    class BaseObject
    {
        public float X;
        public float Y;
        public float Angle;

        public BaseObject(float x, float y, float angle)
        {
            X = x;
            Y = y;
            Angle = angle;
        }
    }
}