// Decompiled with JetBrains decompiler
// Type: GanttCore.ScheduleManager
// Assembly: GanttCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3BE757B5-4D03-423B-93BA-C07A478D7778
// Assembly location: D:\Обучение\Универ\6 семестр\АВУГКС\ganttPetri\gant_kopylash\bin\Debug\GanttCore.dll

using System;
using System.Collections.Generic;
using System.Linq;
using GanttCore;

namespace kopylash
{
    public class ScheduleManager
    {
        private List<Module> _modules;
        private List<ATM> _atms;
        private List<Detail> _details;
        private ScheduleRules _scheduleRule;
        private bool _useATMs;

        public List<Detail> Details
        {
            get
            {
                return this._details;
            }
        }

        public ScheduleRules ScheduleRule
        {
            get
            {
                return this._scheduleRule;
            }
            set
            {
                this._scheduleRule = value;
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

        public bool Done
        {
            get
            {
                for (int index = 0; index < this.Details.Count; ++index)
                {
                    if (!this.Details[index].Done)
                        return false;
                }
                return true;
            }
        }

        public Dictionary<int, List<string>> Portfeils { get; set; }

        public ScheduleManager()
        {
            this._modules = new List<Module>();
            this._details = new List<Detail>();
            this._atms = new List<ATM>();
            this._useATMs = false;
            this.Portfeils = new Dictionary<int, List<string>>();
        }

        public ScheduleManager(List<int> modulesNumbers, int detailsCount, int ATMCount, List<List<int>> routeMatrix, List<List<double>> operationsLengthMatrix, ScheduleManager.ScheduleRules scheduleRule, bool useATMs, List<List<double>> moveTimes, List<double> moduleLoadingTime, List<double> moduleUnloadingTime, List<int> moduleStorageCount, List<List<int>> atmAvailableModules)
            : this()
        {
            this._scheduleRule = scheduleRule;
            for (int index = 0; index < modulesNumbers.Count; ++index)
                this._modules.Add(new Module(index + 1, modulesNumbers[index]));
            for (int index1 = 0; index1 < detailsCount; ++index1)
            {
                Detail detail = new Detail(index1 + 1);
                for (int index2 = 0; index2 < routeMatrix[index1].Count; ++index2)
                    detail.AddOperation(new Operation(index2 + 1, this.GetModuleByNumber(routeMatrix[index1][index2]), operationsLengthMatrix[index1][index2], detail));
                this._details.Add(detail);
            }
        }

        public ScheduleManager(List<int> modulesNumbers, int detailsCount, List<List<int>> routeMatrix, List<List<double>> operationsLengthMatrix, ScheduleManager.ScheduleRules scheduleRule)
            : this(modulesNumbers, detailsCount, 0, routeMatrix, operationsLengthMatrix, scheduleRule, false, (List<List<double>>)null, (List<double>)null, (List<double>)null, (List<int>)null, (List<List<int>>)null)
        {
        }

        private int ShortestOperationCompare(Operation op1, Operation op2)
        {
            if (op1.Length.CompareTo(op2.Length) != 0)
                return op1.Length.CompareTo(op2.Length);
            return op1.Detail.Index.CompareTo(op2.Detail.Index);
        }

        private int ShortestOperationCompare2(Operation op1, Operation op2)
        {
            if (op1.Length.CompareTo(op2.Length) != 0)
                return op1.Length.CompareTo(op2.Length);
            double num1 = 0.0;
            double num2 = 0.0;
            for (int index = 0; index < op1.Detail.Operations.Count; ++index)
            {
                if (!op1.Detail.Operations[index].Done)
                    num1 += op1.Detail.Operations[index].Length;
            }
            for (int index = 0; index < op2.Detail.Operations.Count; ++index)
            {
                if (!op2.Detail.Operations[index].Done)
                    num2 += op2.Detail.Operations[index].Length;
            }
            if (num1.CompareTo(num2) != 0)
                return num1.CompareTo(num2);
            return this.ShortestOperationCompare(op1, op2);
        }

        private int MaximumResidualLaborContentCompare(Operation op1, Operation op2)
        {
            if (op1.Detail == null || op2.Detail == null)
                return this.ShortestOperationCompare(op1, op2);
            double num1 = 0.0;
            double num2 = 0.0;
            for (int index = 0; index < op1.Detail.Operations.Count; ++index)
            {
                if (!op1.Detail.Operations[index].Done)
                    num1 += op1.Detail.Operations[index].Length;
            }
            for (int index = 0; index < op2.Detail.Operations.Count; ++index)
            {
                if (!op2.Detail.Operations[index].Done)
                    num2 += op2.Detail.Operations[index].Length;
            }
            if (num2.CompareTo(num1) != 0)
                return num2.CompareTo(num1);
            return this.ShortestOperationCompare(op1, op2);
        }

        private int LineBalancingCompare(Operation op1, Operation op2)
        {
            Operation operation1 = op1.Detail.PrevOperation();
            double num1 = Math.Max(operation1 != (Operation)null ? operation1.EndTime : 0.0, op1.Module.FinishTime());
            if (op1.Module == null || op2.Module == null)
                return this.ShortestOperationCompare(op1, op2);
            Module module1;
            double num2;
            if (op1.Detail.Next2Operation() != (Operation)null && (module1 = op1.Detail.Next2Operation().Module) != null)
            {
                num2 = module1.FinishTime() - num1;
                List<Operation> list = new List<Operation>();
                for (int index = 0; index < this.Details.Count; ++index)
                {
                    if (!this.Details[index].Done)
                    {
                        Operation operation2 = this.Details[index].NextOperation();
                        if (operation2.Module == module1)
                            num2 += operation2.Length;
                    }
                }
            }
            else
                num2 = double.MaxValue;
            Module module2;
            double num3;
            if (op2.Detail.Next2Operation() != (Operation)null && (module2 = op2.Detail.Next2Operation().Module) != null)
            {
                num3 = module2.FinishTime() - num1;
                List<Operation> list = new List<Operation>();
                for (int index = 0; index < this.Details.Count; ++index)
                {
                    if (!this.Details[index].Done)
                    {
                        Operation operation2 = this.Details[index].NextOperation();
                        if (operation2.Module == module2)
                            num3 += operation2.Length;
                    }
                }
            }
            else
                num3 = double.MaxValue;
            if (num2.CompareTo(num3) != 0)
                return num2.CompareTo(num3);
            return this.ShortestOperationCompare(op1, op2);
        }

        private int MainimumResidualLaborContentCompare(Operation op1, Operation op2)
        {
            if (op1.Detail == null || op2.Detail == null)
                return this.ShortestOperationCompare(op1, op2);
            double num1 = 0.0;
            double num2 = 0.0;
            for (int index = 0; index < op1.Detail.Operations.Count; ++index)
            {
                if (!op1.Detail.Operations[index].Done)
                    num1 += op1.Detail.Operations[index].Length;
            }
            for (int index = 0; index < op2.Detail.Operations.Count; ++index)
            {
                if (!op2.Detail.Operations[index].Done)
                    num2 += op2.Detail.Operations[index].Length;
            }
            if (num1.CompareTo(num2) != 0)
                return num1.CompareTo(num2);
            return this.ShortestOperationCompare(op1, op2);
        }

        private int LongestOperationCompare(Operation op1, Operation op2)
        {
            if (op2.Length.CompareTo(op1.Length) != 0)
                return op2.Length.CompareTo(op1.Length);
            return this.MaximumResidualLaborContentCompare(op1, op2);
        }

        private int FIFOCompare(Operation op1, Operation op2)
        {
            if (op1.Detail.Operations.IndexOf(op1).CompareTo(op2.Detail.Operations.IndexOf(op2)) != 0)
                return op1.Detail.Operations.IndexOf(op1).CompareTo(op2.Detail.Operations.IndexOf(op2));
            return this.ShortestOperationCompare(op1, op2);
        }

        private int LIFOCompare(Operation op1, Operation op2)
        {
            if (op2.Detail.Operations.IndexOf(op2).CompareTo(op1.Detail.Operations.IndexOf(op1)) != 0)
                return op2.Detail.Operations.IndexOf(op2).CompareTo(op1.Detail.Operations.IndexOf(op1));
            return this.ShortestOperationCompare(op1, op2);
        }

        private void CalculateSchedule()
        {
            for (int index = 0; index < this.Details.Count; ++index)
                this.Details[index].Clear();
            while (!this.Done)
            {
                List<Operation> list = new List<Operation>();
                double num1 = double.MaxValue;
                for (int index = 0; index < this.Details.Count; ++index)
                {
                    if (!this.Details[index].Done)
                    {
                        Operation operation1 = this.Details[index].NextOperation();
                        Operation operation2 = this.Details[index].PrevOperation();
                        double val2 = operation1.Module.FinishTime();
                        if (operation2 != (Operation)null)
                            val2 = Math.Max(operation2.EndTime, val2);
                        if (num1 > val2)
                            num1 = val2;
                        list.Add(operation1);
                    }
                }
                for (int index = 0; index < list.Count; ++index)
                {
                    Operation operation1 = list[index];
                    Operation operation2 = operation1.Detail.PrevOperation();
                    double val2 = operation1.Module.FinishTime();
                    if (operation2 != (Operation)null)
                        val2 = Math.Max(operation2.EndTime, val2);
                    if (val2 != num1)
                    {
                        list.RemoveAt(index);
                        --index;
                    }
                }
                switch (this.ScheduleRule)
                {
                    case ScheduleRules.ShortestOperation:
                        list.Sort(new Comparison<Operation>(this.ShortestOperationCompare));
                        break;
                    case ScheduleRules.MaximumResidualLaborContent:
                        list.Sort(new Comparison<Operation>(this.MaximumResidualLaborContentCompare));
                        break;
                    case ScheduleRules.LineBalancing:
                        list.Sort(new Comparison<Operation>(this.LineBalancingCompare));
                        break;
                    case ScheduleRules.MainimumResidualLaborContent:
                        list.Sort(new Comparison<Operation>(this.MainimumResidualLaborContentCompare));
                        break;
                    case ScheduleRules.LongestOperation:
                        list.Sort(new Comparison<Operation>(this.LongestOperationCompare));
                        break;
                    case ScheduleRules.FIFO:
                        list.Sort(new Comparison<Operation>(this.FIFOCompare));
                        break;
                    case ScheduleRules.LIFO:
                        list.Sort(new Comparison<Operation>(this.LIFOCompare));
                        break;
                }
                IEnumerable<Operation> enumerable = Enumerable.Select<IGrouping<int, Operation>, Operation>((IEnumerable<IGrouping<int, Operation>>)Enumerable.OrderBy<IGrouping<int, Operation>, int>(Enumerable.GroupBy<Operation, int>((IEnumerable<Operation>)list, (Func<Operation, int>)(oper => oper.Module.ModuleIndex)), (Func<IGrouping<int, Operation>, int>)(g => g.Key)), (Func<IGrouping<int, Operation>, Operation>)(g => Enumerable.First<Operation>((IEnumerable<Operation>)g)));
                foreach (IGrouping<int, Operation> grouping in (IEnumerable<IGrouping<int, Operation>>)Enumerable.OrderBy<IGrouping<int, Operation>, int>(Enumerable.GroupBy<Operation, int>((IEnumerable<Operation>)list, (Func<Operation, int>)(oper => oper.Module.ModuleIndex)), (Func<IGrouping<int, Operation>, int>)(g => g.Key)))
                {
                    if (!this.Portfeils.ContainsKey(grouping.Key))
                        this.Portfeils.Add(grouping.Key, new List<string>());
                    string str = "";
                    foreach (Operation operation1 in (IEnumerable<Operation>)grouping)
                    {
                        str = str + (object)operation1.Detail + "\t";
                        switch (this.ScheduleRule)
                        {
                            case ScheduleRules.ShortestOperation:
                                str += operation1.Length;
                                break;
                            case ScheduleRules.MaximumResidualLaborContent:
                                double num2 = 0.0;
                                for (int index = 0; index < operation1.Detail.Operations.Count; ++index)
                                {
                                    if (!operation1.Detail.Operations[index].Done)
                                        num2 += operation1.Detail.Operations[index].Length;
                                }
                                str += num2;
                                break;
                            case ScheduleRules.LineBalancing:
                                Operation operation2 = operation1.Detail.PrevOperation();
                                double num3 = Math.Max(operation2 != (Operation)null ? operation2.EndTime : 0.0, operation1.Module.FinishTime());
                                Module module;
                                double num4;
                                if (operation1.Detail.Next2Operation() != (Operation)null && (module = operation1.Detail.Next2Operation().Module) != null)
                                {
                                    num4 = module.FinishTime() - num3;
                                    for (int index = 0; index < this.Details.Count; ++index)
                                    {
                                        if (!this.Details[index].Done)
                                        {
                                            Operation operation3 = this.Details[index].NextOperation();
                                            if (operation3.Module == module)
                                                num4 += operation3.Length;
                                        }
                                    }
                                }
                                else
                                    num4 = double.NaN;
                                str += num4.ToString();
                                break;
                            case ScheduleRules.MainimumResidualLaborContent:
                                double num5 = 0.0;
                                for (int index = 0; index < operation1.Detail.Operations.Count; ++index)
                                {
                                    if (!operation1.Detail.Operations[index].Done)
                                        num5 += operation1.Detail.Operations[index].Length;
                                }
                                str += num5.ToString();
                                break;
                            case ScheduleRules.LongestOperation:
                                str += operation1.Length.ToString();
                                break;
                            case ScheduleRules.FIFO:
                                str += operation1.Detail.Operations.IndexOf(operation1);
                                break;
                            case ScheduleRules.LIFO:
                                str += operation1.Detail.Operations.IndexOf(operation1);
                                break;
                        }
                        str += "\n";
                    }
                    this.Portfeils[grouping.Key].Add(str.Trim('\n'));
                }
                foreach (Operation op in enumerable)
                {
                    Module module = op.Module;
                    if (module != null)
                    {
                        double num2 = module.FinishTime();
                        Operation operation = op.Detail.PrevOperation();
                        if (operation != (Operation)null)
                            num2 = Math.Max(operation.EndTime, num2);
                        module.AddOperationToSequence(op, num2);
                    }
                }
            }
        }

        private void CalculateScheduleWithATMs()
        {
        }

        public Module GetModuleByNumber(int moduleNumber)
        {
            for (int index = 0; index < this.Modules.Count; ++index)
            {
                if (this.Modules[index].ModuleIndex == moduleNumber)
                    return this.Modules[index];
            }
            return (Module)null;
        }

        private ATM GetNearestATM(Module module, double curTime, out double endMoveTime, bool isNewDetail)
        {
            ATM atm = Enumerable.First<ATM>((IEnumerable<ATM>)Enumerable.OrderBy<ATM, double>(Enumerable.Where<ATM>((IEnumerable<ATM>)this._atms, (Func<ATM, bool>)(a => a.Modules.IndexOf(module) != -1)), (Func<ATM, double>)(a => a.GetMoveTime(module, curTime, isNewDetail))));
            endMoveTime = 0.0;
            if (atm != null)
                endMoveTime = atm.GetMoveTime(module, curTime, isNewDetail);
            return atm;
        }

        public double GetOperatonsLength()
        {
            if (!this.Done)
            {
                if (!this._useATMs)
                    this.CalculateSchedule();
                else
                    this.CalculateScheduleWithATMs();
            }
            double num = 0.0;
            for (int index = 0; index < this.Modules.Count; ++index)
            {
                if (num < this.Modules[index].FinishTime())
                    num = this.Modules[index].FinishTime();
            }
            return num;
        }

        public enum ScheduleRules
        {
            ShortestOperation,
            MaximumResidualLaborContent,
            LineBalancing,
            MainimumResidualLaborContent,
            LongestOperation,
            FIFO,
            LIFO,
        }
    }
}
