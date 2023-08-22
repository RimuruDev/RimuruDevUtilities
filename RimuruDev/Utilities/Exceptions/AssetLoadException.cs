// ReSharper disable All
// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//
// **************************************************************** //

using System;

namespace External.RimuruDev.Utilities.Exceptions
{
    public sealed class AssetLoadException : Exception
    {
        public AssetLoadException()
        {
        }

        public AssetLoadException(string path) : base(path)
        {
        }

        public AssetLoadException(string path, Exception inner) : base(path, inner)
        {
        }
    }
}