// Decompiled with JetBrains decompiler
// Type: Gantt.Program
// Assembly: Gantt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BAF6587B-9366-49E4-B85F-799E18470D29
// Assembly location: D:\Обучение\Универ\6 семестр\АВУГКС\ganttPetri\Gantt.exe

using System;
using System.Windows.Forms;

namespace Gantt
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new frmMain());
    }
  }
}
