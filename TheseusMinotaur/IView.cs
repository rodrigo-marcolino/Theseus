﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusMinotaur
{
    interface IView
    {
        void Start();
        int SetLevel(string prompt);
        void Display<T>(T message);
        void Stop();
    }
}
