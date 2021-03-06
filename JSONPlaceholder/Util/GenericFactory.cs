﻿using System;
namespace JSONPlaceholder.Util
{
    public abstract class GenericFactory<T>
    {
        public static T GetInstance()
        {
            return (T)Activator.CreateInstance(typeof(T), true);
        }
    }
}
