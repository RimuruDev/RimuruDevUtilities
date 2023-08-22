// ReSharper disable All
// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//
// **************************************************************** //

#if !UNITY_EDITOR
using UnityEngine;
using UnityEngine.Rendering;

namespace External.RimuruDev.Utilities.UnityEngine
{
    public sealed class SkipSplash
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void BeforeSplashScreen()
        {
#if UNITY_WEBGL
        Application.focusChanged += Application_focusChanged;
#else
            System.Threading.Tasks.Task.Run(AsyncSkip);
#endif
        }

#if UNITY_WEBGL
    private static void Application_focusChanged(bool value)
    {
        Application.focusChanged -= Application_focusChanged;

        SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);
    }

#else
        private static void AsyncSkip() =>
            SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);
#endif
    }
}
#endif