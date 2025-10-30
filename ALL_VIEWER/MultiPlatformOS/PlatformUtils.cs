using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;

namespace MultiPlatformOS
{
    public static class PlatformUtils
    {
        public static PlaformOS GetPlaformOS
        {
            get
            {
                if (_plaformOS == null)
                {
                    bool isLinux = IsLinux();
                    bool isMono = IsMono();
                    bool isWine = IsRunningUnderWine();

                    if (isWine)
                    {
                        _plaformOS = PlaformOS.Wine;
                    }
                    else if (isLinux && isMono)
                    {
                        _plaformOS = PlaformOS.MonoLinux;
                    }
                    else if (isMono)
                    {
                        _plaformOS = PlaformOS.MonoWin;
                    }
                    else
                    {
                        _plaformOS = PlaformOS.DotNetFramework;
                    }
                }
                return _plaformOS.Value;
            }
        }

        static PlaformOS? _plaformOS = null;
        static string _infoPlaformOS = null;

        public static string GetInfoPlaformOS
        {
            get
            {
                if (_infoPlaformOS == null)
                {
                    if (GetPlaformOS != PlaformOS.Wine)
                    {
                        return GetOSInfo() + " + " + GetRuntimeInfo();
                    }
                    else
                    {
                        return "Wine Version: " + (GetWineVersion() ?? "???") + " + " + GetOSInfo() + " + " + GetRuntimeInfo();
                    }
                }
                return _infoPlaformOS;
            }

        }

        public static string DisplayPlaformOS()
        {
            switch (_plaformOS)
            {
                case PlaformOS.DotNetFramework: return "Windows .NET Framework";
                case PlaformOS.MonoLinux: return "Linux Mono";
                case PlaformOS.MonoWin: return "Windows Mono ";
                case PlaformOS.Wine: return "Wine";
                default: return "Error";
            }

        }

        static string GetRuntimeInfo()
        {
            // Verifica se está no Mono
            Type monoRuntime = Type.GetType("Mono.Runtime");
            if (monoRuntime != null)
            {
                MethodInfo displayName = monoRuntime.GetMethod("GetDisplayName", BindingFlags.NonPublic | BindingFlags.Static);
                if (displayName != null)
                {
                    string monoVersion = displayName.Invoke(null, null)?.ToString();
                    return "Mono " + monoVersion;
                }
                return "Mono (Unknown Version)";
            }

            // .NET Framework
            return ".NET Framework " + Environment.Version.ToString();
        }

        static string GetOSInfo()
        {
            string os = Environment.OSVersion.ToString();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return "Windows - " + os;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return "Linux - " + os;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return "macOS - " + os;

            return "Outro - " + os;
        }

        static bool IsLinux()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        }

        static bool IsMono()
        {
            return Type.GetType("Mono.Runtime") != null;
        }

        static bool IsRunningUnderWine()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) { return false; }

            try
            {
                // Procura a DLL ntdll que é sobrescrita no Wine
                IntPtr hModule = GetModuleHandle("ntdll.dll");
                if (hModule == IntPtr.Zero) { return false; }

                IntPtr procAddr = GetProcAddress(hModule, "wine_get_version");
                return procAddr != IntPtr.Zero;
            }
            catch
            {
                return false;
            }
        }

        static string GetWineVersion()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return null;

            try
            {
                IntPtr ntdll = LoadLibrary("ntdll.dll");
                if (ntdll != IntPtr.Zero)
                {
                    IntPtr proc = GetProcAddress(ntdll, "wine_get_version");
                    if (proc != IntPtr.Zero)
                    {
                        WineGetVersionDelegate func = (WineGetVersionDelegate)Marshal.GetDelegateForFunctionPointer(proc, typeof(WineGetVersionDelegate));
                        return func();
                    }
                }
            }
            catch { }

            return null;
        }

        delegate string WineGetVersionDelegate();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LoadLibrary(string dllToLoad);


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
    }

    public enum PlaformOS : byte
    {
        DotNetFramework = 0,
        MonoLinux = 1,
        MonoWin = 2,
        Wine = 3
    }

}
