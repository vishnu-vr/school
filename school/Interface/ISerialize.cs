﻿using System;
using System.Collections.Generic;

namespace school.Interface
{
    public interface ISerialize
    {
        void Serialize();

        dynamic Deserialize();
    }
}
