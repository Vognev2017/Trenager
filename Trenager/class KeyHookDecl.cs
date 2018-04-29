using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;

class KeyHookDecl
{
    public const int WH_KEYBOARD = 2;

    public delegate int HookProc(int code, int wParam, IntPtr lParam);

    [DllImport("user32.dll",

     CharSet = CharSet.Auto,CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    
    public static extern int SetWindowsHookEx(int idHook, HookProc lpfn,IntPtr hMod,int dwThreadId);
    

    [DllImport("user32.dll",CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    
    public static extern int CallNextHookEx(int idHook,int nCode,int wParam,IntPtr lParam);
    
    [DllImport("user32.dll",CharSet = CharSet.Auto
        ,CallingConvention = CallingConvention.StdCall,SetLastError = true)]
    
    public static extern bool UnhookWindowsHookEx(int hhk);
}

public class KeyHook
{
    public event KeyEventHandler KeyDown;
    public event KeyEventHandler KeyUp;

    [DllImport("kernel32.dll")]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    int hhook;// хэндл созданой нами ловушки
    int HookProc(int code, int wParam, IntPtr lParam)
    {

        // для доступа к битам
        BitArray bt = new BitArray(BitConverter.GetBytes((uint)lParam));
        KeyEventArgs arg = new KeyEventArgs((Keys)wParam);
        //Если клавиша нажата - вызвать KeyDown, если отпущена - вызвать KeyUp
        if (bt[30])
        {

            if (KeyUp != null) KeyUp(this, arg);

        }

        else

                    if (KeyDown != null) KeyDown(this, arg);

        // Вызов следующей ловушки в очереди
        KeyHookDecl.CallNextHookEx(0, code, wParam, lParam);
        return 1;
    }
    public KeyHook()
    {
        // Создание ловушки
        hhook = KeyHookDecl.SetWindowsHookEx(KeyHookDecl.WH_KEYBOARD,

        new KeyHookDecl.HookProc(HookProc),

        GetModuleHandle(null),

        AppDomain.GetCurrentThreadId());
    }

    ~KeyHook()
    {
        KeyHookDecl.UnhookWindowsHookEx(hhook);
    }

}