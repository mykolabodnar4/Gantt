// Decompiled with JetBrains decompiler
// Type: GanttCore.ATMScheduleManager
// Assembly: GanttCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3BE757B5-4D03-423B-93BA-C07A478D7778
// Assembly location: D:\Обучение\Универ\.Палево_тотал\6 семестр\ГКС\ganttorig\gantt\GanttCore.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GanttCore;
using Module = GanttCore.Module;


namespace kopylash
{
  public class ATMScheduleManager
  {
    private List<Module> _modules;
    private List<ATM> _atms;
    private List<Detail> _details;
    private double _operationsLength;
    private List<bool> _moduleIsTempModule;

    public List<Module> Modules
    {
      get
      {
        return this._modules;
      }
      set
      {
        this._modules = value;
      }
    }

    public List<ATM> ATMs
    {
      get
      {
        return this._atms;
      }
      set
      {
        this._atms = value;
      }
    }

    public List<Detail> Details
    {
      get
      {
        return this._details;
      }
      set
      {
        this._details = value;
      }
    }

    public List<bool> ModuleIsTempModule
    {
      get
      {
        return this._moduleIsTempModule;
      }
      set
      {
        this._moduleIsTempModule = value;
      }
    }

    public ATMScheduleManager()
    {
      this._modules = new List<Module>();
      this._atms = new List<ATM>();
      this._details = new List<Detail>();
    }

    public ATMScheduleManager(List<Module> modules, List<Detail> details, int atmCount, List<List<double>> moveTimes, List<double> moduleLoadingTime, List<double> moduleUnloadingTime, List<int> moduleStorageCount, List<List<int>> atmAvailableModules, double takeTime, double stateTime, List<int> atmStartModules, List<bool> moduleIsTempModule)
      : this()
    {
      for (int index1 = 0; index1 < details.Count; ++index1)
      {
        for (int index2 = 0; index2 < details[index1].Operations.Count; ++index2)
          details[index1].Operations[index2].Done = false;
      }
      for (int index = 0; index < modules.Count; ++index)
      {
        modules[index].LoadingTime = moduleLoadingTime[index];
        modules[index].UnloadingTime = moduleUnloadingTime[index];
        modules[index].StorageCount = moduleStorageCount[index];
        modules[index].IsTempModule = moduleIsTempModule[index];
      }
      this._modules = modules;
      for (int index1 = 0; index1 < atmCount; ++index1)
      {
        ATM atm = new ATM(index1 + 1, this.GetModuleByNumber(atmStartModules[index1]), moveTimes, takeTime, stateTime);
        for (int index2 = 0; index2 < atmAvailableModules[index1].Count; ++index2)
          atm.Modules.Add(this.GetModuleByNumber(atmAvailableModules[index1][index2]));
        this._atms.Add(atm);
      }
      this._details = details;
      this._moduleIsTempModule = moduleIsTempModule;
    }

    private Module GetModuleByNumber(int moduleNumber)
    {
      if (moduleNumber == -1)
        return (Module) null;
      for (int index = 0; index < this._modules.Count; ++index)
      {
        if (this._modules[index].ModuleIndex == moduleNumber)
          return this._modules[index];
      }
      return (Module) null;
    }

    public int RequestsCompare(Operation op1, Operation op2)
    {
      if (op1.Detail.CurrentModule == null && op2.Detail.CurrentModule != null)
        return int.MinValue;
      if (op1.Detail.CurrentModule != null && op2.Detail.CurrentModule == null)
        return int.MaxValue;
      if (op1.Length.CompareTo(op2.Length) != 0)
        return op1.Length.CompareTo(op2.Length);
      return op1.Detail.Index.CompareTo(op2.Detail.Index);
    }

    public int RequestsCompare2(Operation op1, Operation op2)
    {
      Operation operation1 = op1.Detail.NextOperation(op1);
      Operation operation2 = op2.Detail.NextOperation(op2);
      if (operation1 == (Operation) null && operation2 != (Operation) null)
        return int.MaxValue;
      if (operation1 != (Operation) null && operation2 == (Operation) null)
        return int.MinValue;
      if (operation1 == (Operation) null || operation1.Length.CompareTo(operation2.Length) == 0)
        return op1.Detail.Index.CompareTo(op2.Detail.Index);
      return operation1.Length.CompareTo(operation2.Length);
    }

    public void Calculate()
    {
      this._operationsLength = 0.0;
      double val2 = 0.0;
      double num1 = 0.01;
      double num2 = 0.0;
      List<Operation> list1 = new List<Operation>();
      while (!this.IsDone(num2))
      {
        list1.Clear();
        foreach (Module module in this.GetModulesByState(num2, ModuleState.Free))
        {
          Operation operation1 = module.NextOperation(num2);
          if (operation1 != (Operation) null)
          {
            Detail detail = operation1.Detail;
            Module currentModule = detail.CurrentModule;
            List<Operation> list2 = detail.NextOperation(num2);
            Operation operation2 = list2.Count != 0 ? list2[list2.Count - 1] : (Operation) null;
            if ((currentModule == null || currentModule.GetModuleOperationByTime(num2).State == ModuleState.NeedsATM) && operation2 == operation1)
              list1.Add(operation1);
          }
        }
        list1.Sort(new Comparison<Operation>(this.RequestsCompare));
        foreach (Operation operation1 in list1)
        {
          Module module1 = operation1.Module;
          if (operation1 != (Operation) null)
          {
            Detail detail = operation1.Detail;
            Module currentModule = detail.CurrentModule;
            List<Operation> list2 = detail.NextOperation(num2);
            Operation operation2 = list2.Count != 0 ? list2[list2.Count - 1] : (Operation) null;
            if ((currentModule == null || currentModule.GetModuleOperationByTime(num2).State == ModuleState.NeedsATM) && operation2 == operation1)
            {
              double num3 = num2;
              for (int index = 0; index < list2.Count; ++index)
              {
                Operation operation3 = list2[index];
                List<ATM> atMsByState = this.GetATMsByState(num3, ATMStates.Free);
                Module module2 = index == 0 ? currentModule : list2[index - 1].Module;
                double moveTime;
                ATM nearestAtm = this.GetNearestATM(atMsByState, module2, operation3.Module, out moveTime);
                if (nearestAtm != null)
                {
                  ATMOperation atmOperationByTime = nearestAtm.GetATMOperationByTime(num3);
                  if (atmOperationByTime != null)
                  {
                    atmOperationByTime.EndTime = num3;
                    atmOperationByTime.Length = atmOperationByTime.EndTime - atmOperationByTime.StartTime;
                  }
                  nearestAtm.ATMOperations.Add(new ATMOperation(nearestAtm, ATMStates.EmptyOnWay, detail, num3, nearestAtm.CurrentModule, detail.CurrentModule, moveTime, num3 + moveTime, operation1, module1.LastUndoneOperation(num3)));
                  nearestAtm.CurrentModule = detail.CurrentModule;
                  double timeWithModuleWork = nearestAtm.GetATMMoveTimeWithModuleWork(nearestAtm.CurrentModule, operation3.Module);
                  nearestAtm.ATMOperations.Add(new ATMOperation(nearestAtm, ATMStates.FullOnWay, detail, num3 + moveTime, nearestAtm.CurrentModule, operation3.Module, timeWithModuleWork, num3 + moveTime + timeWithModuleWork, operation1, module1.LastUndoneOperation(num3)));
                  nearestAtm.CurrentModule = operation3.Module;
                  nearestAtm.ATMOperations.Add(new ATMOperation(nearestAtm, ATMStates.Free, (Detail) null, num3 + moveTime + timeWithModuleWork, nearestAtm.CurrentModule, (Module) null, -1.0, -1.0, (Operation) null, (Operation) null));
                  if (num3 + moveTime + timeWithModuleWork > val2)
                    val2 = num3 + moveTime + timeWithModuleWork;
                  if (module2 != null)
                  {
                    ModuleOperation moduleOperationByTime = module2.GetModuleOperationByTime(num3);
                    if (moduleOperationByTime != null)
                    {
                      moduleOperationByTime.EndTime = num3;
                      moduleOperationByTime.Length = moduleOperationByTime.EndTime - moduleOperationByTime.StartTime;
                    }
                    double num4 = module2.StorageCount == 1 ? nearestAtm.TakeTime : 0.0;
                    module2.ModuleOperations.Add(new ModuleOperation(module2, ModuleState.WaitingForFreeATM, detail, (Operation) null, nearestAtm, num3, moveTime, num3 + moveTime + num4));
                    if (module2 == currentModule)
                      module2.ModuleOperations.Add(new ModuleOperation(module2, ModuleState.Free, (Detail) null, (Operation) null, (ATM) null, num3 + moveTime + num4, -1.0, -1.0));
                    else
                      module2.ModuleOperations.Add(new ModuleOperation(module2, ModuleState.NeedsATM, (Detail) null, (Operation) null, (ATM) null, num3 + moveTime + num4, -1.0, -1.0));
                  }
                  ModuleOperation moduleOperationByTime1 = operation3.Module.GetModuleOperationByTime(num3);
                  if (moduleOperationByTime1 != null)
                  {
                    moduleOperationByTime1.EndTime = num3;
                    moduleOperationByTime1.Length = moduleOperationByTime1.EndTime - moduleOperationByTime1.StartTime;
                  }
                  operation3.Module.ModuleOperations.Add(new ModuleOperation(operation3.Module, ModuleState.WaitingForDetail, detail, operation3, nearestAtm, num3, moveTime + timeWithModuleWork, num3 + moveTime + timeWithModuleWork));
                  operation3.Module.ModuleOperations.Add(new ModuleOperation(operation3.Module, ModuleState.Processing, detail, operation3, (ATM) null, num3 + moveTime + timeWithModuleWork, operation3.Length, num3 + moveTime + timeWithModuleWork + operation3.Length));
                  operation3.Module.ModuleOperations.Add(new ModuleOperation(operation3.Module, ModuleState.NeedsATM, detail, operation3, (ATM) null, num3 + moveTime + timeWithModuleWork + operation3.Length, -1.0, -1.0));
                  detail.CurrentModule = operation3.Module;
                  OperationOperation operationOperationByTime = operation3.GetOperationOperationByTime(num3);
                  if (operationOperationByTime != null)
                    operationOperationByTime.EndTime = num3 + moveTime + timeWithModuleWork;
                  operation3.OperationOperations.Add(new OperationOperation(operation3, OperationStates.Processing, operation3.Module, num3 + moveTime + timeWithModuleWork, num3 + moveTime + timeWithModuleWork + operation3.Length));
                  operation3.OperationOperations.Add(new OperationOperation(operation3, OperationStates.Done, operation3.Module, num3 + moveTime + timeWithModuleWork + operation3.Length, -1.0));
                  num3 = num3 + moveTime + timeWithModuleWork + operation3.Length;
                }
              }
            }
          }
        }
        List<Module> modulesByStateNotUsed = this.GetModulesByStateNotUsed(num2, ModuleState.NeedsATM);
        List<Detail> list3 = new List<Detail>();
        for (int index = 0; index < modulesByStateNotUsed.Count; ++index)
        {
          if (modulesByStateNotUsed[index].NextOperation(num2) != (Operation) null)
            list3.Add(modulesByStateNotUsed[index].NextOperation(num2).Detail);
        }
        list1.Clear();
        foreach (Module startModule in modulesByStateNotUsed)
        {
          Operation operation1 = startModule.LastUndoneOperation(num2);
          if (operation1 != (Operation) null)
          {
            Detail detail = operation1.Detail;
            List<Operation> list2 = detail.NextOperation(num2);
            Operation operation2 = list2.Count != 0 ? list2[list2.Count - 1] : (Operation) null;
            if (operation2 != (Operation) null)
            {
              Module module = operation2.Module;
              Operation operation3 = module.NextOperation(num2);
              Operation operation4 = module.LastUndoneOperation(num2);
              Operation operation5 = (Operation) null;
              if (operation4 != (Operation) null)
              {
                List<Operation> list4 = operation4.Detail.NextOperation(num2);
                operation5 = list4.Count != 0 ? list4[list4.Count - 1] : (Operation) null;
              }
              if (operation3 != (Operation) null && operation3.Detail != detail && (operation4 == (Operation) null && this._atms[0].GetATMMoveTimeWithModuleWork(startModule, (Module) null) + this._atms[0].GetATMMoveTimeWithModuleWork((Module) null, module) < operation3.Length + this._atms[0].GetATMMoveTimeWithModuleWork(operation3.Detail.CurrentModule, module) || operation4 != (Operation) null && this._atms[0].GetATMMoveTimeWithModuleWork(startModule, (Module) null) + this._atms[0].GetATMMoveTimeWithModuleWork((Module) null, module) < operation3.Length + this._atms[0].GetATMMoveTimeWithModuleWork(operation3.Detail.CurrentModule, module) + Math.Max(operation4.EndTime - num2, 0.0)) || operation4 != (Operation) null && operation5 != (Operation) null && modulesByStateNotUsed.IndexOf(operation5.Module) != -1 || (startModule.ModuleIndex != 1 || module.ModuleIndex != 2 || operation1.Detail.Index != 6 && operation1.Detail.Index != 4 && operation1.Detail.Index != 5) && (startModule.ModuleIndex != 2 || module.ModuleIndex != 3 || operation1.Detail.Index != 2 && operation1.Detail.Index != 7))
                list1.Add(operation1);
            }
            else
              list1.Add(operation1);
          }
        }
        list1.Sort(new Comparison<Operation>(this.RequestsCompare2));
        foreach (Operation operation1 in list1)
        {
          Module currentModule = operation1.Detail.CurrentModule;
          if (operation1 != (Operation) null)
          {
            Detail detail = operation1.Detail;
            List<Operation> list2 = detail.NextOperation(num2);
            Operation operation2 = list2.Count != 0 ? list2[list2.Count - 1] : (Operation) null;
            if (operation2 != (Operation) null)
            {
              Module module1 = operation2.Module;
              Operation operation3 = module1.NextOperation(num2);
              Operation operation4 = module1.LastUndoneOperation(num2);
              Operation operation5 = (Operation) null;
              if (operation4 != (Operation) null)
              {
                List<Operation> list4 = operation4.Detail.NextOperation(num2);
                operation5 = list4.Count != 0 ? list4[list4.Count - 1] : (Operation) null;
              }
              if (operation3 != (Operation) null && operation3.Detail != detail && (operation4 == (Operation) null && this._atms[0].GetATMMoveTimeWithModuleWork(currentModule, (Module) null) + this._atms[0].GetATMMoveTimeWithModuleWork((Module) null, module1) < operation3.Length + this._atms[0].GetATMMoveTimeWithModuleWork(operation3.Detail.CurrentModule, module1) || operation4 != (Operation) null && this._atms[0].GetATMMoveTimeWithModuleWork(currentModule, (Module) null) + this._atms[0].GetATMMoveTimeWithModuleWork((Module) null, module1) < operation3.Length + this._atms[0].GetATMMoveTimeWithModuleWork(operation3.Detail.CurrentModule, module1) + Math.Max(operation4.EndTime - num2, 0.0)) || operation4 != (Operation) null && operation5 != (Operation) null && modulesByStateNotUsed.IndexOf(operation5.Module) != -1)
              {
                if (currentModule.ModuleIndex == 1 && module1.ModuleIndex == 2)
                  operation1.ToString();
                double num3 = num2;
                for (int index = 0; index < list2.Count; ++index)
                {
                  Operation operation6 = list2[index];
                  List<ATM> atMsByState = this.GetATMsByState(num3, ATMStates.Free);
                  Module module2 = index == 0 ? currentModule : list2[index - 1].Module;
                  Module module3 = index != list2.Count - 1 ? operation6.Module : (Module) null;
                  double moveTime;
                  ATM nearestAtm = this.GetNearestATM(atMsByState, module2, module3, out moveTime);
                  if (nearestAtm != null)
                  {
                    ATMOperation atmOperationByTime = nearestAtm.GetATMOperationByTime(num3);
                    if (atmOperationByTime != null)
                    {
                      atmOperationByTime.EndTime = num3;
                      atmOperationByTime.Length = atmOperationByTime.EndTime - atmOperationByTime.StartTime;
                    }
                    nearestAtm.ATMOperations.Add(new ATMOperation(nearestAtm, ATMStates.EmptyOnWay, detail, num3, nearestAtm.CurrentModule, module2, moveTime, num3 + moveTime, operation1, (Operation) null));
                    nearestAtm.CurrentModule = module2;
                    double timeWithModuleWork = nearestAtm.GetATMMoveTimeWithModuleWork(nearestAtm.CurrentModule, module3);
                    nearestAtm.ATMOperations.Add(new ATMOperation(nearestAtm, ATMStates.FullOnWay, detail, num3 + moveTime, nearestAtm.CurrentModule, module3, timeWithModuleWork, num3 + moveTime + timeWithModuleWork, operation1, (Operation) null));
                    nearestAtm.CurrentModule = module3;
                    nearestAtm.ATMOperations.Add(new ATMOperation(nearestAtm, ATMStates.Free, (Detail) null, num3 + moveTime + timeWithModuleWork, nearestAtm.CurrentModule, (Module) null, -1.0, -1.0, (Operation) null, (Operation) null));
                    if (num3 + moveTime + timeWithModuleWork > val2)
                      val2 = num3 + moveTime + timeWithModuleWork;
                    ModuleOperation moduleOperationByTime1 = module2.GetModuleOperationByTime(num3);
                    if (moduleOperationByTime1 != null)
                    {
                      moduleOperationByTime1.EndTime = num3;
                      moduleOperationByTime1.Length = moduleOperationByTime1.EndTime - moduleOperationByTime1.StartTime;
                    }
                    double num4 = module2.StorageCount == 1 ? nearestAtm.TakeTime : 0.0;
                    module2.ModuleOperations.Add(new ModuleOperation(module2, ModuleState.WaitingForFreeATM, detail, (Operation) null, nearestAtm, num3, moveTime, num3 + moveTime + num4));
                    if (module2 == currentModule)
                      module2.ModuleOperations.Add(new ModuleOperation(module2, ModuleState.Free, (Detail) null, (Operation) null, (ATM) null, num3 + moveTime + num4, -1.0, -1.0));
                    else
                      module2.ModuleOperations.Add(new ModuleOperation(module2, ModuleState.NeedsATM, (Detail) null, (Operation) null, (ATM) null, num3 + moveTime + num4, -1.0, -1.0));
                    if (module3 != null)
                    {
                      ModuleOperation moduleOperationByTime2 = module3.GetModuleOperationByTime(num3);
                      if (moduleOperationByTime2 != null)
                      {
                        moduleOperationByTime2.EndTime = num3;
                        moduleOperationByTime2.Length = moduleOperationByTime2.EndTime - moduleOperationByTime2.StartTime;
                      }
                      module3.ModuleOperations.Add(new ModuleOperation(module3, ModuleState.WaitingForDetail, detail, operation6, nearestAtm, num3, moveTime + timeWithModuleWork, num3 + moveTime + timeWithModuleWork));
                      module3.ModuleOperations.Add(new ModuleOperation(module3, ModuleState.Processing, detail, operation6, (ATM) null, num3 + moveTime + timeWithModuleWork, operation6.Length, num3 + moveTime + timeWithModuleWork + operation6.Length));
                      module3.ModuleOperations.Add(new ModuleOperation(module3, ModuleState.NeedsATM, detail, operation6, (ATM) null, num3 + moveTime + timeWithModuleWork + operation6.Length, -1.0, -1.0));
                    }
                    detail.CurrentModule = module3;
                    num3 = num3 + moveTime + timeWithModuleWork + operation6.Length;
                  }
                }
              }
            }
            else
            {
              double moveTime;
              ATM nearestAtm = this.GetNearestATM(this.GetATMsByState(num2, ATMStates.Free), currentModule, (Module) null, out moveTime);
              if (nearestAtm != null)
              {
                ATMOperation atmOperationByTime = nearestAtm.GetATMOperationByTime(num2);
                if (atmOperationByTime != null)
                {
                  atmOperationByTime.EndTime = num2;
                  atmOperationByTime.Length = atmOperationByTime.EndTime - atmOperationByTime.StartTime;
                }
                nearestAtm.ATMOperations.Add(new ATMOperation(nearestAtm, ATMStates.EmptyOnWay, detail, num2, nearestAtm.CurrentModule, currentModule, moveTime, num2 + moveTime, operation1, (Operation) null));
                nearestAtm.CurrentModule = currentModule;
                double timeWithModuleWork = nearestAtm.GetATMMoveTimeWithModuleWork(nearestAtm.CurrentModule, (Module) null);
                nearestAtm.ATMOperations.Add(new ATMOperation(nearestAtm, ATMStates.FullOnWay, detail, num2 + moveTime, nearestAtm.CurrentModule, (Module) null, timeWithModuleWork, num2 + moveTime + timeWithModuleWork, operation1, (Operation) null));
                nearestAtm.CurrentModule = (Module) null;
                nearestAtm.ATMOperations.Add(new ATMOperation(nearestAtm, ATMStates.Free, (Detail) null, num2 + moveTime + timeWithModuleWork, nearestAtm.CurrentModule, (Module) null, -1.0, -1.0, (Operation) null, (Operation) null));
                if (num2 + moveTime + timeWithModuleWork > val2)
                  val2 = num2 + moveTime + timeWithModuleWork;
                ModuleOperation moduleOperationByTime = currentModule.GetModuleOperationByTime(num2);
                if (moduleOperationByTime != null)
                {
                  moduleOperationByTime.EndTime = num2;
                  moduleOperationByTime.Length = moduleOperationByTime.EndTime - moduleOperationByTime.StartTime;
                }
                double num3 = currentModule.StorageCount == 1 ? nearestAtm.TakeTime : 0.0;
                currentModule.ModuleOperations.Add(new ModuleOperation(currentModule, ModuleState.WaitingForFreeATM, detail, (Operation) null, nearestAtm, num2, moveTime, num2 + moveTime + num3));
                currentModule.ModuleOperations.Add(new ModuleOperation(currentModule, ModuleState.Free, (Detail) null, (Operation) null, (ATM) null, num2 + moveTime + num3, -1.0, -1.0));
                detail.CurrentModule = (Module) null;
              }
            }
          }
        }
        num2 += num1;
      }
      for (int index = 0; index < this._atms.Count; ++index)
      {
        if (this._atms[index].CurrentModule != null)
        {
          ATMOperation atmOperationByTime = this._atms[index].GetATMOperationByTime(num2);
          if (atmOperationByTime != null)
          {
            atmOperationByTime.EndTime = num2;
            atmOperationByTime.Length = atmOperationByTime.EndTime - atmOperationByTime.StartTime;
          }
        }
      }
      this._operationsLength = Math.Max(num2, val2);
    }

    public List<Module> GetModulesByState(double time, ModuleState state)
    {
      List<Module> list = new List<Module>();
      foreach (Module module in this._modules)
      {
        if (!module.IsTempModule)
        {
          ModuleOperation moduleOperationByTime = module.GetModuleOperationByTime(time);
          if (moduleOperationByTime != null && moduleOperationByTime.State == state)
            list.Add(module);
        }
      }
      return list;
    }

    public List<Module> GetModulesByStateNotUsed(double time, ModuleState state)
    {
      List<Module> list = new List<Module>();
      foreach (Module module in this._modules)
      {
        ModuleOperation moduleOperationByTime = module.GetModuleOperationByTime(time);
        if (moduleOperationByTime != null && moduleOperationByTime.State == state && moduleOperationByTime.EndTime == -1.0)
          list.Add(module);
      }
      return list;
    }

    public List<ATM> GetATMsByState(double time, ATMStates state)
    {
      List<ATM> list = new List<ATM>();
      foreach (ATM atm in this._atms)
      {
        ATMOperation atmOperationByTime = atm.GetATMOperationByTime(time);
        if (atmOperationByTime != null && atmOperationByTime.State == state)
          list.Add(atm);
      }
      return list;
    }

    private ATM GetNearestATM(List<ATM> atms, Module endModule, Module finishModule, out double moveTime)
    {
        moveTime = 0;
        var assembly = Assembly.LoadFrom(@"GanttCore.dll");
        var type = assembly.GetTypes().FirstOrDefault(t => t.Name == "ATMScheduleManager");
        var classInstance = Activator.CreateInstance(type, null);
        MethodInfo info = type.GetMethod("GetNearestATM", BindingFlags.NonPublic | BindingFlags.Instance);
        var result = info.Invoke(classInstance, new object[]{atms,endModule,finishModule,moveTime});
        return (ATM)result;
    }

    private bool IsDone(double time)
    {
      for (int index = 0; index < this._details.Count; ++index)
      {
        if (!this._details[index].IsDone(time) || this._details[index].CurrentModule != null)
          return false;
      }
      return true;
    }

    public double GetOperationsLength()
    {
      if (!this.IsDone(this._operationsLength))
        this.Calculate();
      return this._operationsLength;
    }
  }
}
