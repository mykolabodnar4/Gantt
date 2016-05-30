// Decompiled with JetBrains decompiler
// Type: Gantt.frmMain
// Assembly: Gantt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BAF6587B-9366-49E4-B85F-799E18470D29
// Assembly location: D:\Обучение\Универ\6 семестр\АВУГКС\ganttPetri\Gantt.exe

using GanttCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Gantt
{
  public class frmMain : Form
  {
    private string filename = "Безымянный";
    private string header = "Диаграммы Ганта - {0} | by Mykola Bodnar";
    private int _atmCount = 1;
    private const string FILE_HEADER = "TES";
    private bool Calculated;
    private bool DataFilled;
    private List<List<int>> _routeMatrix;
    private List<List<double>> _operationLengthMatrix;
    private List<List<double>> _moveTimes;
    private List<double> _moduleLoadingTimes;
    private List<double> _moduleUnloadingTimes;
    private List<int> _moduleStorageCount;
    private List<bool> _moduleIsTempModule;
    private List<List<int>> _atmAvailableModules;
    private double _atmStateTime;
    private double _atmTakeTime;
    private List<int> _atmStartModules;
    private List<int> _modulesNumbers;
    private int _detailsCount;
    private IContainer components;
    private TabControl tcMain;
    private TabPage tpScheduleShortestOperation;
    private TabPage tpScheduleMaximumResidualLaborContent;
    private TableLayoutPanel tlpMain;
    private EnviromentScheduleView esvShortestOperation;
    private TableLayoutPanel tlpCommandButtons;
    private Button btnNext;
    private TabPage tpScheduleMainimumResidualLaborContent;
    private TabPage tpScheduleLongestOperation;
    private TabPage tpScheduleFIFO;
    private TabPage tpScheduleLIFO;
    private EnviromentScheduleView esvMaximumResidualLaborContent;
    private EnviromentScheduleView esvLongestOperation;
    private EnviromentScheduleView esvFIFO;
    private EnviromentScheduleView esvLIFO;
    private EnviromentScheduleView esvMainimumResidualLaborContent;
    private TabPage tpScheduleLineBalancing;
    private EnviromentScheduleView esvLineBalancing;
    private MenuStrip msMainMenu;
    private TabPage tpData;
    private Button btnBack;
    private ToolStripMenuItem tsmiFile;
    private ToolStripMenuItem tsmiNew;
    private ToolStripMenuItem tsmiOpen;
    private ToolStripSeparator toolStripSeparator;
    private ToolStripMenuItem tsmiSave;
    private ToolStripMenuItem tsmiSaveAs;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem tsmiExit;
    private OpenFileDialog ofdData;
    private SaveFileDialog sfdData;
    private TabPage tpScheduleWithATM;
    private TabControl tcScheduleData;
    private TabPage tpScheduleDataOperations;
    private SplitContainer scData;
    private GroupBox grbRouteMatrix;
    private TextBox txtRouteMatrix;
    private GroupBox grbOperationLengthMatrix;
    private TextBox txtOperationLengthMatrix;
    private TabPage tpScheduleDataAdditionalInfo;
    private GroupBox grbATMsProperies;
    private NumericUpDown nudATMsCount;
    private Label lblATMsCount;
    private DataGridView dgvATMAvailableModules;
    private Label lblATMTakeTime;
    private TextBox txtATMTakeTime;
    private TextBox txtATMStateTime;
    private Label lblATMStateTime;
    private GroupBox grbATMStartModules;
    private GroupBox grbATMAvailableModules;
    private DataGridView dgvATMStartModules;
    private DataGridViewTextBoxColumn colATMNames;
    private DataGridViewComboBoxColumn colATMStartModule;
    private TableLayoutPanel tlpScheduleData;
    private TableLayoutPanel tlpModulesProperies;
    private GroupBox grbModulesProperies;
    private DataGridView dgvModulesProperies;
    private DataGridViewTextBoxColumn colModuleName;
    private DataGridViewTextBoxColumn colModuleLoadingTime;
    private DataGridViewTextBoxColumn colModuleUnloadingTime;
    private DataGridViewTextBoxColumn colModuleStorageCount;
    private DataGridViewCheckBoxColumn colVisibleInDiagram;
    private GroupBox grbMoveTimes;
    private DataGridView dgvMoveTimes;
    private TableLayoutPanel tlpATMProperties;
    private TableLayoutPanel tlpScheduleWithATM;
    private EnviromentScheduleWithATMView esvATM;
    private Label lblScheduleWithATMScheduleType;
    private ComboBox cboScheduleWithATMScheduleType;
    private ToolStripMenuItem tsmiHelp;
    private ToolStripMenuItem tsmiAboutProgram;
    private TabPage tabPage1;
    private RichTextBox richTextBox1;
    private TabPage tabPage2;
    private RichTextBox richTextBox2;

    public List<List<int>> RouteMatrix
    {
      get
      {
        if (this._routeMatrix == null || !this.DataFilled)
          this.FillData();
        return this._routeMatrix;
      }
      set
      {
        this._routeMatrix = value;
      }
    }

    public List<List<double>> OperationLengthMatrix
    {
      get
      {
        if (this._operationLengthMatrix == null || !this.DataFilled)
          this.FillData();
        return this._operationLengthMatrix;
      }
      set
      {
        this._operationLengthMatrix = value;
      }
    }

    public List<int> ModulesNumbers
    {
      get
      {
        if (this._modulesNumbers == null || !this.DataFilled)
          this.FillData();
        return this._modulesNumbers;
      }
      set
      {
        this._modulesNumbers = value;
      }
    }

    public int DetailsCount
    {
      get
      {
        if (this._detailsCount == -1 || !this.DataFilled)
          this.FillData();
        return this._detailsCount;
      }
      set
      {
        this._detailsCount = value;
      }
    }

    public List<List<double>> MoveTimes
    {
      get
      {
        if (this._moveTimes == null || !this.DataFilled)
          this.FillData();
        return this._moveTimes;
      }
      set
      {
        this._moveTimes = value;
      }
    }

    public List<double> ModuleLoadingTimes
    {
      get
      {
        if (this._moduleLoadingTimes == null || !this.DataFilled)
          this.FillData();
        return this._moduleLoadingTimes;
      }
      set
      {
        this._moduleLoadingTimes = value;
      }
    }

    public List<double> ModuleUnloadingTimes
    {
      get
      {
        if (this._moduleUnloadingTimes == null || !this.DataFilled)
          this.FillData();
        return this._moduleUnloadingTimes;
      }
      set
      {
        this._moduleUnloadingTimes = value;
      }
    }

    public List<int> ModuleStorageCount
    {
      get
      {
        if (this._moduleStorageCount == null || !this.DataFilled)
          this.FillData();
        return this._moduleStorageCount;
      }
      set
      {
        this._moduleStorageCount = value;
      }
    }

    public List<bool> ModuleIsTempModule
    {
      get
      {
        if (this._moduleIsTempModule == null || !this.DataFilled)
          this.FillData();
        return this._moduleIsTempModule;
      }
      set
      {
        this._moduleIsTempModule = value;
      }
    }

    public List<List<int>> ATMAvailableModules
    {
      get
      {
        if (this._atmAvailableModules == null || !this.DataFilled)
          this.FillData();
        return this._atmAvailableModules;
      }
      set
      {
        this._atmAvailableModules = value;
      }
    }

    public List<int> ATMStartModules
    {
      get
      {
        if (this._atmStartModules == null || !this.DataFilled)
          this.FillData();
        return this._atmStartModules;
      }
      set
      {
        this._atmStartModules = value;
      }
    }

    public frmMain()
    {
      this.InitializeComponent();
    }

    private void tsmiExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private bool ParseRouteMatrix(string text, out List<List<int>> routeMatrix)
    {
      routeMatrix = new List<List<int>>();
      try
      {
        string str1 = text.Trim();
        string[] separator = new string[1]
        {
          Environment.NewLine
        };
        int num = 1;
        foreach (string str2 in str1.Split(separator, (StringSplitOptions) num))
        {
          List<int> list = new List<int>();
          foreach (string str3 in str2.Trim().Split(" /\\[]-=+^&*();#№@!%$<>?.,\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
          {
            string s = str3.Trim();
            int result = -1;
            if (int.TryParse(s, out result))
            {
              if (result > 0)
                list.Add(result);
            }
            else
            {
              routeMatrix.Clear();
              throw new Exception("Ошибка приведения типов!");
            }
          }
          routeMatrix.Add(list);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(string.Format("Ошибка разбора матрицы маршрутов!{0}Сообщение: {1}", (object) Environment.NewLine, (object) ex.Message), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      return true;
    }

    private bool ParseOperationLengthMatrix(string text, out List<List<double>> operationLengthMatrix)
    {
      operationLengthMatrix = new List<List<double>>();
      try
      {
        string str1 = text.Trim();
        string[] separator = new string[1]
        {
          Environment.NewLine
        };
        int num = 1;
        foreach (string str2 in str1.Split(separator, (StringSplitOptions) num))
        {
          List<double> list = new List<double>();
          foreach (string str3 in str2.Trim().Replace(",", ".").Split(" /\\[]-=+^&*();#№@!%$<>?\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
          {
            string s = str3.Trim();
            double result = -1.0;
            if (double.TryParse(s, NumberStyles.Any, (IFormatProvider) new NumberFormatInfo()
            {
              NumberDecimalSeparator = "."
            }, out result))
            {
              list.Add(result);
            }
            else
            {
              list.Clear();
              throw new Exception("Ошибка приведения типов!");
            }
          }
          operationLengthMatrix.Add(list);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(string.Format("Ошибка разбора матрицы времени обработки!{0}Сообщение: {1}", (object) Environment.NewLine, (object) ex.Message), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      return true;
    }

    private List<int> GetModulesNumbers(List<List<int>> routeMatrix)
    {
      List<int> list = new List<int>();
      for (int index1 = 0; index1 < routeMatrix.Count; ++index1)
      {
        for (int index2 = 0; index2 < routeMatrix[index1].Count; ++index2)
        {
          if (!list.Contains(routeMatrix[index1][index2]))
            list.Add(routeMatrix[index1][index2]);
        }
      }
      list.Sort();
      return list;
    }

    private int GetDetailsCount(List<List<int>> routeMatrix)
    {
      return routeMatrix.Count;
    }

    private void FillMoveTime()
    {
      this.dgvMoveTimes.Rows.Clear();
      this.dgvMoveTimes.Columns.Clear();
      if (this._moveTimes == null)
        this._moveTimes = new List<List<double>>();
      while (this._moveTimes.Count > this._modulesNumbers.Count + 1)
        this._moveTimes.RemoveAt(this._moveTimes.Count - 1);
      for (int index = 0; index < this._moveTimes.Count; ++index)
      {
        while (this._moveTimes[index].Count > this._modulesNumbers.Count + 1)
          this._moveTimes[index].RemoveAt(this._moveTimes[index].Count - 1);
      }
      while (this._moveTimes.Count < this._modulesNumbers.Count + 1)
        this._moveTimes.Add(new List<double>());
      for (int index = 0; index < this._moveTimes.Count; ++index)
      {
        while (this._moveTimes[index].Count < this._modulesNumbers.Count + 1)
          this._moveTimes[index].Add(0.0);
      }
      for (int index = 0; index < this._modulesNumbers.Count + 2; ++index)
      {
        this.dgvMoveTimes.Columns.Add("", "");
        this.dgvMoveTimes.Columns[index].Width = 60;
        this.dgvMoveTimes.Columns[index].ReadOnly = index == 0;
        this.dgvMoveTimes.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
      }
      this.dgvMoveTimes.Rows.Add(this._modulesNumbers.Count + 2);
      this.dgvMoveTimes.Rows[0].Cells[0].Style.BackColor = SystemColors.AppWorkspace;
      for (int index1 = 0; index1 < this._modulesNumbers.Count + 1; ++index1)
      {
        this.dgvMoveTimes.Rows[index1 + 1].Cells[0].Value = index1 == 0 ? (object) "AC" : (object) string.Format("ГВМ {0}", (object) this._modulesNumbers[index1 - 1]);
        this.dgvMoveTimes.Rows[index1 + 1].Cells[0].Style.BackColor = SystemColors.AppWorkspace;
        this.dgvMoveTimes.Rows[index1 + 1].Cells[0].ReadOnly = true;
        this.dgvMoveTimes.Rows[0].Cells[index1 + 1].Value = index1 == 0 ? (object) "AC" : (object) string.Format("ГВМ {0}", (object) this._modulesNumbers[index1 - 1]);
        this.dgvMoveTimes.Rows[0].Cells[index1 + 1].Style.BackColor = SystemColors.AppWorkspace;
        this.dgvMoveTimes.Rows[0].Cells[index1 + 1].ReadOnly = true;
        this.dgvMoveTimes.Rows[index1 + 1].Cells[index1 + 1].ReadOnly = true;
        this.dgvMoveTimes.Rows[index1 + 1].Cells[index1 + 1].Style.BackColor = Color.LightGray;
        for (int index2 = 0; index2 < this._modulesNumbers.Count + 1; ++index2)
          this.dgvMoveTimes.Rows[index1 + 1].Cells[index2 + 1].Value = (object) this._moveTimes[index1][index2];
      }
    }

    private void FillModulesProperies()
    {
      if (this._moduleLoadingTimes == null)
        this._moduleLoadingTimes = new List<double>();
      while (this._moduleLoadingTimes.Count > this._modulesNumbers.Count)
        this._moduleLoadingTimes.RemoveAt(this._moduleLoadingTimes.Count - 1);
      while (this._moduleLoadingTimes.Count < this._modulesNumbers.Count)
        this._moduleLoadingTimes.Add(0.0);
      if (this._moduleUnloadingTimes == null)
        this._moduleUnloadingTimes = new List<double>();
      while (this._moduleUnloadingTimes.Count > this._modulesNumbers.Count)
        this._moduleUnloadingTimes.RemoveAt(this._moduleUnloadingTimes.Count - 1);
      while (this._moduleUnloadingTimes.Count < this._modulesNumbers.Count)
        this._moduleUnloadingTimes.Add(0.0);
      if (this._moduleStorageCount == null)
        this._moduleStorageCount = new List<int>();
      while (this._moduleStorageCount.Count > this._modulesNumbers.Count)
        this._moduleStorageCount.RemoveAt(this._moduleStorageCount.Count - 1);
      while (this._moduleStorageCount.Count < this._modulesNumbers.Count)
        this._moduleStorageCount.Add(1);
      if (this._moduleIsTempModule == null)
        this._moduleIsTempModule = new List<bool>();
      while (this._moduleIsTempModule.Count > this._modulesNumbers.Count)
        this._moduleIsTempModule.RemoveAt(this._moduleIsTempModule.Count - 1);
      while (this._moduleIsTempModule.Count < this._modulesNumbers.Count)
        this._moduleIsTempModule.Add(false);
      this.dgvModulesProperies.Rows.Clear();
      for (int index = 0; index < this._modulesNumbers.Count; ++index)
      {
        this.dgvModulesProperies.Rows.Add((object) string.Format("ГВМ {0}", (object) this._modulesNumbers[index]), (object) this._moduleLoadingTimes[index], (object) this._moduleUnloadingTimes[index], (object) this._moduleStorageCount[index], (object) (bool) (!this._moduleIsTempModule[index] ? true : false));
        this.dgvModulesProperies.Rows[index].Cells[0].Style.BackColor = SystemColors.AppWorkspace;
      }
    }

    private void FillATMAvailableModules()
    {
      this.dgvATMAvailableModules.Rows.Clear();
      this.dgvATMAvailableModules.Columns.Clear();
      if (this._atmAvailableModules == null)
        this._atmAvailableModules = new List<List<int>>();
      while (this._atmAvailableModules.Count > this._atmCount)
        this._atmAvailableModules.RemoveAt(this._atmAvailableModules.Count - 1);
      while (this._atmAvailableModules.Count < this._atmCount)
        this._atmAvailableModules.Add(new List<int>());
      for (int index1 = 0; index1 < this._atmAvailableModules.Count; ++index1)
      {
        for (int index2 = 0; index2 < this._atmAvailableModules[index1].Count; ++index2)
        {
          if (this._atmAvailableModules[index1][index2] != -1 && this._modulesNumbers.IndexOf(this._atmAvailableModules[index1][index2]) == -1)
            this._atmAvailableModules[index1].RemoveAt(index2);
        }
      }
      for (int index = 0; index < this._modulesNumbers.Count + 2; ++index)
      {
        this.dgvATMAvailableModules.Columns.Add("", "");
        this.dgvATMAvailableModules.Columns[index].Width = 60;
        this.dgvATMAvailableModules.Columns[index].ReadOnly = index == 0;
        this.dgvATMAvailableModules.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
      }
      this.dgvATMAvailableModules.Rows.Add();
      for (int index = 0; index < this._modulesNumbers.Count + 1; ++index)
      {
        this.dgvATMAvailableModules.Rows[0].Cells[index + 1].Value = index == 0 ? (object) "AC" : (object) string.Format("ГВМ {0}", (object) this._modulesNumbers[index - 1]);
        this.dgvATMAvailableModules.Rows[0].Cells[index + 1].Style.BackColor = SystemColors.AppWorkspace;
        this.dgvATMAvailableModules.Rows[0].Cells[index + 1].ReadOnly = true;
      }
      this.dgvATMAvailableModules.Rows[0].Cells[0].Style.BackColor = SystemColors.AppWorkspace;
      this.dgvATMAvailableModules.Rows[0].Cells[0].ReadOnly = true;
      for (int index1 = 0; index1 < this._atmCount; ++index1)
      {
        DataGridViewRow dataGridViewRow = new DataGridViewRow();
        for (int index2 = 0; index2 < this._modulesNumbers.Count + 2; ++index2)
        {
          if (index2 == 0)
            dataGridViewRow.Cells.Add((DataGridViewCell) new DataGridViewTextBoxCell());
          else
            dataGridViewRow.Cells.Add((DataGridViewCell) new DataGridViewCheckBoxCell());
          if (index2 == 0)
          {
            dataGridViewRow.Cells[0].Value = (object) string.Format("АТМ {0}", (object) (index1 + 1));
            dataGridViewRow.Cells[0].Style.BackColor = SystemColors.AppWorkspace;
            dataGridViewRow.Cells[0].ReadOnly = true;
          }
          else
          {
            dataGridViewRow.Cells[index2].Value = index2 != 1 ? (object) (bool) (this._atmAvailableModules[index1].IndexOf(this._modulesNumbers[index2 - 2]) != -1 ? true : false) : (object) (bool) (this._atmAvailableModules[index1].IndexOf(-1) != -1 ? true : false);
            dataGridViewRow.Cells[index2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
          }
        }
        this.dgvATMAvailableModules.Rows.Add(dataGridViewRow);
      }
    }

    private void FillATMStartModules()
    {
      this.dgvATMStartModules.Rows.Clear();
      if (this._atmStartModules == null)
        this._atmStartModules = new List<int>();
      while (this._atmStartModules.Count > this._atmCount)
        this._atmStartModules.RemoveAt(this._atmStartModules.Count - 1);
      while (this._atmStartModules.Count < this._atmCount)
        this._atmStartModules.Add(0);
      for (int index1 = 0; index1 < this._atmCount; ++index1)
      {
        DataGridViewComboBoxCell viewComboBoxCell = (DataGridViewComboBoxCell) this.dgvATMStartModules.Rows[this.dgvATMStartModules.Rows.Add(new object[1]
        {
          (object) string.Format("АТМ {0}", (object) (index1 + 1))
        })].Cells[1];
        viewComboBoxCell.Sorted = true;
        viewComboBoxCell.DisplayMember = "Text";
        viewComboBoxCell.ValueMember = "Value";
        for (int index2 = 0; index2 < this._atmAvailableModules[index1].Count; ++index2)
          viewComboBoxCell.Items.Add((object) new
          {
            Value = this._atmAvailableModules[index1][index2],
            Text = (this._atmAvailableModules[index1][index2] == -1 ? "АС" : string.Format("ГВМ {0}", (object) this._atmAvailableModules[index1][index2]))
          });
        if (this._atmStartModules[index1] != 0)
          viewComboBoxCell.Value = (object) this._atmStartModules[index1];
      }
    }

    private bool FillData()
    {
      this.Validate();
      this.DataFilled = false;
      if (!this.ParseRouteMatrix(this.txtRouteMatrix.Text, out this._routeMatrix) || !this.ParseOperationLengthMatrix(this.txtOperationLengthMatrix.Text, out this._operationLengthMatrix))
        return false;
      this._modulesNumbers = this.GetModulesNumbers(this._routeMatrix);
      this._detailsCount = this.GetDetailsCount(this._routeMatrix);
      this.FillMoveTime();
      this.FillModulesProperies();
      this.FillATMAvailableModules();
      this.FillATMStartModules();
      this.DataFilled = true;
      return true;
    }

    private void FillResults()
    {
      this.esvShortestOperation.ModulesNumbers = this.ModulesNumbers;
      this.esvShortestOperation.DetailsCount = this.DetailsCount;
      this.esvShortestOperation.RouteMatrix = this.RouteMatrix;
      this.esvShortestOperation.OperationsLengthMatrix = this.OperationLengthMatrix;
      this.esvShortestOperation.ModuleIsTempModule = this.ModuleIsTempModule;
      if (!this.esvShortestOperation.FillResults())
      {
        this.tcMain.SelectedIndex = 0;
        this.txtRouteMatrix.Focus();
      }
      else
      {
        this.esvMaximumResidualLaborContent.ModulesNumbers = this.ModulesNumbers;
        this.esvMaximumResidualLaborContent.DetailsCount = this.DetailsCount;
        this.esvMaximumResidualLaborContent.RouteMatrix = this.RouteMatrix;
        this.esvMaximumResidualLaborContent.OperationsLengthMatrix = this.OperationLengthMatrix;
        this.esvMaximumResidualLaborContent.ModuleIsTempModule = this.ModuleIsTempModule;
        if (!this.esvMaximumResidualLaborContent.FillResults())
        {
          this.tcMain.SelectedIndex = 0;
          this.txtRouteMatrix.Focus();
        }
        else
        {
          this.esvLineBalancing.ModulesNumbers = this.ModulesNumbers;
          this.esvLineBalancing.DetailsCount = this.DetailsCount;
          this.esvLineBalancing.RouteMatrix = this.RouteMatrix;
          this.esvLineBalancing.OperationsLengthMatrix = this.OperationLengthMatrix;
          this.esvLineBalancing.ModuleIsTempModule = this.ModuleIsTempModule;
          if (!this.esvLineBalancing.FillResults())
          {
            this.tcMain.SelectedIndex = 0;
            this.txtRouteMatrix.Focus();
          }
          else
          {
            this.esvMainimumResidualLaborContent.ModulesNumbers = this.ModulesNumbers;
            this.esvMainimumResidualLaborContent.DetailsCount = this.DetailsCount;
            this.esvMainimumResidualLaborContent.RouteMatrix = this.RouteMatrix;
            this.esvMainimumResidualLaborContent.OperationsLengthMatrix = this.OperationLengthMatrix;
            this.esvMainimumResidualLaborContent.ModuleIsTempModule = this.ModuleIsTempModule;
            if (!this.esvMainimumResidualLaborContent.FillResults())
            {
              this.tcMain.SelectedIndex = 0;
              this.txtRouteMatrix.Focus();
            }
            else
            {
              this.esvLongestOperation.ModulesNumbers = this.ModulesNumbers;
              this.esvLongestOperation.DetailsCount = this.DetailsCount;
              this.esvLongestOperation.RouteMatrix = this.RouteMatrix;
              this.esvLongestOperation.OperationsLengthMatrix = this.OperationLengthMatrix;
              this.esvLongestOperation.ModuleIsTempModule = this.ModuleIsTempModule;
              if (!this.esvLongestOperation.FillResults())
              {
                this.tcMain.SelectedIndex = 0;
                this.txtRouteMatrix.Focus();
              }
              else
              {
                this.esvFIFO.ModulesNumbers = this.ModulesNumbers;
                this.esvFIFO.DetailsCount = this.DetailsCount;
                this.esvFIFO.RouteMatrix = this.RouteMatrix;
                this.esvFIFO.OperationsLengthMatrix = this.OperationLengthMatrix;
                this.esvFIFO.ModuleIsTempModule = this.ModuleIsTempModule;
                if (!this.esvFIFO.FillResults())
                {
                  this.tcMain.SelectedIndex = 0;
                  this.txtRouteMatrix.Focus();
                }
                else
                {
                  this.esvLIFO.ModulesNumbers = this.ModulesNumbers;
                  this.esvLIFO.DetailsCount = this.DetailsCount;
                  this.esvLIFO.RouteMatrix = this.RouteMatrix;
                  this.esvLIFO.OperationsLengthMatrix = this.OperationLengthMatrix;
                  this.esvLIFO.ModuleIsTempModule = this.ModuleIsTempModule;
                  if (!this.esvLIFO.FillResults())
                  {
                    this.tcMain.SelectedIndex = 0;
                    this.txtRouteMatrix.Focus();
                  }
                  else
                  {
                    this.esvATM.ModulesNumbers = this.ModulesNumbers;
                    this.esvATM.DetailsCount = this.DetailsCount;
                    this.esvATM.RouteMatrix = this.RouteMatrix;
                    this.esvATM.OperationsLengthMatrix = this.OperationLengthMatrix;
                    this.esvATM.ATMsCount = this._atmCount;
                    this.esvATM.MoveTimes = this.MoveTimes;
                    this.esvATM.ModuleLoadingTimes = this.ModuleLoadingTimes;
                    this.esvATM.ModuleUnloadingTimes = this.ModuleUnloadingTimes;
                    this.esvATM.ModuleStorageCount = this.ModuleStorageCount;
                    this.esvATM.ATMAvailableModules = this.ATMAvailableModules;
                    this.esvATM.ATMStartModules = this.ATMStartModules;
                    this.esvATM.ModuleIsTempModule = this.ModuleIsTempModule;
                    this.esvATM.ATMTakeTime = this._atmTakeTime;
                    this.esvATM.ATMStateTime = this._atmStateTime;
                    if (!this.esvATM.FillResults())
                    {
                      this.tcMain.SelectedIndex = 0;
                      this.txtRouteMatrix.Focus();
                    }
                    else
                    {
                      this.richTextBox1.Text = this.esvATM.FirstTable;
                      this.richTextBox2.Text = this.esvATM.SecondTable;
                    }
                  }
                }
              }
            }
          }
        }
      }
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
      if (!this.Calculated)
      {
        if (this.FillData())
        {
          if (this._atmStartModules.IndexOf(0) == -1)
          {
            this.FillResults();
          }
          else
          {
            int num = (int) MessageBox.Show(string.Format("Укажите начальные позиции АТМов!"), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return;
          }
        }
        this.Calculated = true;
      }
      ++this.tcMain.SelectedIndex;
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
      --this.tcMain.SelectedIndex;
    }

    private void tcMain_Selecting(object sender, TabControlCancelEventArgs e)
    {
      e.Cancel = !this.Calculated;
    }

    private void tcMain_Selected(object sender, TabControlEventArgs e)
    {
      this.btnBack.Visible = e.TabPageIndex != 0;
      this.btnNext.Enabled = e.TabPageIndex != this.tcMain.TabPages.Count - 1;
    }

    private void txtOperationLengthMatrix_TextChanged(object sender, EventArgs e)
    {
      this.Calculated = false;
      this.DataFilled = false;
    }

    private void txtRouteMatrix_TextChanged(object sender, EventArgs e)
    {
      this.Calculated = false;
      this.DataFilled = false;
    }

    private void tsmiNew_Click(object sender, EventArgs e)
    {
      this.filename = "Безымянный";
      this.tcMain.SelectedIndex = 0;
      this.tcScheduleData.SelectedIndex = 0;
      this.DataFilled = false;
      this.Calculated = false;
      this.txtRouteMatrix.Clear();
      this.txtOperationLengthMatrix.Clear();
      this._routeMatrix = (List<List<int>>) null;
      this._operationLengthMatrix = (List<List<double>>) null;
      this._moveTimes = (List<List<double>>) null;
      this._moduleLoadingTimes = (List<double>) null;
      this._moduleUnloadingTimes = (List<double>) null;
      this._moduleStorageCount = (List<int>) null;
      this._moduleIsTempModule = (List<bool>) null;
      this._atmCount = 1;
      this._atmAvailableModules = (List<List<int>>) null;
      this._atmStateTime = 0.0;
      this._atmTakeTime = 0.0;
      this._atmStartModules = (List<int>) null;
      this.txtRouteMatrix.Focus();
    }

    public void SaveData(string fileName)
    {
      this.Validate();
      BinaryWriter binaryWriter = (BinaryWriter) null;
      try
      {
        binaryWriter = new BinaryWriter((Stream) new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write));
        binaryWriter.Write("TES");
        binaryWriter.Write(this.RouteMatrix.Count);
        for (int index1 = 0; index1 < this.RouteMatrix.Count; ++index1)
        {
          List<int> list1 = this.RouteMatrix[index1];
          List<double> list2 = this.OperationLengthMatrix[index1];
          if (list1.Count > list2.Count)
            throw new Exception("Недостаточно информации о продолжительности операций!");
          binaryWriter.Write(list1.Count);
          for (int index2 = 0; index2 < list1.Count; ++index2)
          {
            binaryWriter.Write(list1[index2]);
            binaryWriter.Write(list2[index2]);
          }
        }
        binaryWriter.Write(this.MoveTimes.Count);
        for (int index1 = 0; index1 < this.MoveTimes.Count; ++index1)
        {
          binaryWriter.Write(this.MoveTimes[index1].Count);
          for (int index2 = 0; index2 < this.MoveTimes[index1].Count; ++index2)
            binaryWriter.Write(this.MoveTimes[index1][index2]);
        }
        binaryWriter.Write(this.ModuleLoadingTimes.Count);
        for (int index = 0; index < this.ModuleLoadingTimes.Count; ++index)
          binaryWriter.Write(this.ModuleLoadingTimes[index]);
        binaryWriter.Write(this.ModuleUnloadingTimes.Count);
        for (int index = 0; index < this.ModuleUnloadingTimes.Count; ++index)
          binaryWriter.Write(this.ModuleUnloadingTimes[index]);
        binaryWriter.Write(this.ModuleStorageCount.Count);
        for (int index = 0; index < this.ModuleStorageCount.Count; ++index)
          binaryWriter.Write(this.ModuleStorageCount[index]);
        binaryWriter.Write(this.ModuleIsTempModule.Count);
        for (int index = 0; index < this.ModuleIsTempModule.Count; ++index)
          binaryWriter.Write(this.ModuleIsTempModule[index]);
        binaryWriter.Write(this._atmCount);
        binaryWriter.Write(this._atmTakeTime);
        binaryWriter.Write(this._atmStateTime);
        binaryWriter.Write(this._atmCount);
        for (int index1 = 0; index1 < this._atmCount; ++index1)
        {
          binaryWriter.Write(this.ATMAvailableModules[index1].Count);
          for (int index2 = 0; index2 < this.ATMAvailableModules[index1].Count; ++index2)
            binaryWriter.Write(this.ATMAvailableModules[index1][index2]);
        }
        binaryWriter.Write(this._atmCount);
        for (int index = 0; index < this.ATMStartModules.Count; ++index)
          binaryWriter.Write(this.ATMStartModules[index]);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(string.Format("Ошибка при сохранении данных!{0}Сообщение: {1}", (object) Environment.NewLine, (object) ex.Message), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      finally
      {
        if (binaryWriter != null)
        {
          binaryWriter.Flush();
          binaryWriter.Close();
        }
      }
    }

    public bool LoadData(string fileName)
    {
      this.tcMain.SelectedIndex = 0;
      this.tcScheduleData.SelectedIndex = 0;
      this.Calculated = false;
      this.DataFilled = false;
      BinaryReader binaryReader = (BinaryReader) null;
      try
      {
        binaryReader = new BinaryReader((Stream) new FileStream(fileName, FileMode.Open, FileAccess.Read));
        if (binaryReader.ReadString() != "TES")
          throw new Exception("Неверный формат файла!");
        this.txtRouteMatrix.Clear();
        this.txtOperationLengthMatrix.Clear();
        this._routeMatrix = (List<List<int>>) null;
        this._operationLengthMatrix = (List<List<double>>) null;
        this._moveTimes = (List<List<double>>) null;
        this._moduleLoadingTimes = (List<double>) null;
        this._moduleUnloadingTimes = (List<double>) null;
        this._moduleStorageCount = (List<int>) null;
        this._moduleIsTempModule = (List<bool>) null;
        this._atmCount = 1;
        this._atmAvailableModules = (List<List<int>>) null;
        this._atmStateTime = 0.0;
        this._atmTakeTime = 0.0;
        this._atmStartModules = (List<int>) null;
        int num1 = binaryReader.ReadInt32();
        this._routeMatrix = new List<List<int>>();
        this._operationLengthMatrix = new List<List<double>>();
        for (int index1 = 0; index1 < num1; ++index1)
        {
          List<int> list1 = new List<int>();
          List<double> list2 = new List<double>();
          int num2 = binaryReader.ReadInt32();
          for (int index2 = 0; index2 < num2; ++index2)
          {
            int num3 = binaryReader.ReadInt32();
            list1.Add(num3);
            this.txtRouteMatrix.Text += string.Format("{0} ", (object) num3);
            double num4 = binaryReader.ReadDouble();
            list2.Add(num4);
            this.txtOperationLengthMatrix.Text += string.Format("{0:F2} ", (object) num4);
          }
          this._routeMatrix.Add(list1);
          this._operationLengthMatrix.Add(list2);
          this.txtRouteMatrix.Text += Environment.NewLine;
          this.txtOperationLengthMatrix.Text += Environment.NewLine;
        }
        this._moveTimes = new List<List<double>>();
        int num5 = binaryReader.ReadInt32();
        for (int index1 = 0; index1 < num5; ++index1)
        {
          List<double> list = new List<double>();
          int num2 = binaryReader.ReadInt32();
          for (int index2 = 0; index2 < num2; ++index2)
            list.Add(binaryReader.ReadDouble());
          this._moveTimes.Add(list);
        }
        this._moduleLoadingTimes = new List<double>();
        int num6 = binaryReader.ReadInt32();
        for (int index = 0; index < num6; ++index)
          this._moduleLoadingTimes.Add(binaryReader.ReadDouble());
        this._moduleUnloadingTimes = new List<double>();
        int num7 = binaryReader.ReadInt32();
        for (int index = 0; index < num7; ++index)
          this._moduleUnloadingTimes.Add(binaryReader.ReadDouble());
        this._moduleStorageCount = new List<int>();
        int num8 = binaryReader.ReadInt32();
        for (int index = 0; index < num8; ++index)
          this._moduleStorageCount.Add(binaryReader.ReadInt32());
        this._moduleIsTempModule = new List<bool>();
        int num9 = binaryReader.ReadInt32();
        for (int index = 0; index < num9; ++index)
          this._moduleIsTempModule.Add(binaryReader.ReadBoolean());
        this._atmCount = binaryReader.ReadInt32();
        this._atmTakeTime = binaryReader.ReadDouble();
        this._atmStateTime = binaryReader.ReadDouble();
        this._atmAvailableModules = new List<List<int>>();
        int num10 = binaryReader.ReadInt32();
        for (int index1 = 0; index1 < num10; ++index1)
        {
          List<int> list = new List<int>();
          int num2 = binaryReader.ReadInt32();
          for (int index2 = 0; index2 < num2; ++index2)
            list.Add(binaryReader.ReadInt32());
          this._atmAvailableModules.Add(list);
        }
        this._atmStartModules = new List<int>();
        int num11 = binaryReader.ReadInt32();
        for (int index = 0; index < num11; ++index)
          this._atmStartModules.Add(binaryReader.ReadInt32());
        this.FillData();
        this.nudATMsCount.Value = (Decimal) this._atmCount;
        this.txtATMStateTime.Text = this._atmStateTime.ToString();
        this.txtATMTakeTime.Text = this._atmTakeTime.ToString();
        return true;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(string.Format("Ошибка при открытии файла данных!{0}Сообщение: {1}", (object) Environment.NewLine, (object) ex.Message), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        this.DataFilled = false;
        return false;
      }
      finally
      {
        if (binaryReader != null)
          binaryReader.Close();
      }
    }

    private void tsmiSaveAs_Click(object sender, EventArgs e)
    {
      if (this.sfdData.ShowDialog() != DialogResult.OK)
        return;
      this.filename = this.sfdData.FileName;
      this.SaveData(this.filename);
      this.Text = string.Format(this.header, (object) this.filename.Substring(this.filename.LastIndexOf("\\") + 1));
    }

    private void tsmiSave_Click(object sender, EventArgs e)
    {
      if (this.filename == "Безымянный")
        this.tsmiSaveAs_Click(sender, e);
      else
        this.SaveData(this.filename);
    }

    private void tsmiOpen_Click(object sender, EventArgs e)
    {
      if (this.ofdData.ShowDialog() != DialogResult.OK || !this.LoadData(this.ofdData.FileName))
        return;
      this.filename = this.ofdData.FileName;
      this.Text = string.Format(this.header, (object) this.filename.Substring(this.filename.LastIndexOf("\\") + 1));
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      this.Text = string.Format(this.header, (object) this.filename.Substring(this.filename.LastIndexOf("\\") + 1));
      this.cboScheduleWithATMScheduleType.SelectedIndex = 0;
    }

    private void tcScheduleData_Selecting(object sender, TabControlCancelEventArgs e)
    {
      if (this.DataFilled)
        return;
      e.Cancel = !this.FillData();
    }

    private void dgvMoveTimes_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
      if (e.RowIndex <= 0 || e.ColumnIndex <= 0)
        return;
      double result = 0.0;
      if (!double.TryParse(e.FormattedValue.ToString().Replace(",", "."), NumberStyles.Any, (IFormatProvider) new NumberFormatInfo()
      {
        NumberDecimalSeparator = "."
      }, out result))
        e.Cancel = true;
      else
        this._moveTimes[e.RowIndex - 1][e.ColumnIndex - 1] = result;
    }

    private void dgvModulesProperies_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
      NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
      numberFormatInfo.NumberDecimalSeparator = ".";
      switch (e.ColumnIndex)
      {
        case 1:
          double result1 = 0.0;
          if (!double.TryParse(e.FormattedValue.ToString().Replace(",", "."), NumberStyles.Any, (IFormatProvider) numberFormatInfo, out result1))
          {
            e.Cancel = true;
            break;
          }
          this._moduleLoadingTimes[e.RowIndex] = result1;
          break;
        case 2:
          double result2 = 0.0;
          if (!double.TryParse(e.FormattedValue.ToString().Replace(",", "."), NumberStyles.Any, (IFormatProvider) numberFormatInfo, out result2))
          {
            e.Cancel = true;
            break;
          }
          this._moduleUnloadingTimes[e.RowIndex] = result2;
          break;
        case 3:
          int result3 = 0;
          if (!int.TryParse(e.FormattedValue.ToString(), out result3))
          {
            e.Cancel = true;
            break;
          }
          this._moduleStorageCount[e.RowIndex] = result3;
          break;
        case 4:
          this._moduleIsTempModule[e.RowIndex] = !(bool) e.FormattedValue;
          break;
      }
      this.Calculated = false;
    }

    private void txtATMTakeTime_Validating(object sender, CancelEventArgs e)
    {
      if (double.TryParse(this.txtATMTakeTime.Text.Replace(",", "."), NumberStyles.Any, (IFormatProvider) new NumberFormatInfo()
      {
        NumberDecimalSeparator = "."
      }, out this._atmTakeTime))
        return;
      e.Cancel = true;
    }

    private void txtATMStateTime_Validating(object sender, CancelEventArgs e)
    {
      if (double.TryParse(this.txtATMStateTime.Text.Replace(",", "."), NumberStyles.Any, (IFormatProvider) new NumberFormatInfo()
      {
        NumberDecimalSeparator = "."
      }, out this._atmStateTime))
        return;
      e.Cancel = true;
    }

    private void nudATMsCount_ValueChanged(object sender, EventArgs e)
    {
      this._atmCount = (int) this.nudATMsCount.Value;
      this.FillATMAvailableModules();
      this.FillATMStartModules();
      this.Calculated = false;
    }

    private void dgvATMAvailableModules_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex <= 0 || e.ColumnIndex <= 0)
        return;
      bool flag = (bool) this.dgvATMAvailableModules.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
      int index = e.ColumnIndex - 2;
      int num = index == -1 ? -1 : this._modulesNumbers[index];
      if (flag)
      {
        if (this._atmAvailableModules[e.RowIndex - 1].IndexOf(num) == -1)
          this._atmAvailableModules[e.RowIndex - 1].Add(num);
      }
      else if (this._atmAvailableModules[e.RowIndex - 1].IndexOf(num) != -1)
      {
        this._atmAvailableModules[e.RowIndex - 1].Remove(num);
        if (this._atmStartModules[e.RowIndex - 1] == num)
          this._atmStartModules[e.RowIndex - 1] = 0;
      }
      this.FillATMStartModules();
      this.Calculated = false;
    }

    private void dgvATMStartModules_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex < 0 || e.ColumnIndex != 1)
        return;
      object obj = this.dgvATMStartModules.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
      this._atmStartModules[e.RowIndex] = obj == null ? 0 : (int) obj;
      this.Calculated = false;
    }

    private void cboScheduleWithATMScheduleType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.esvATM.ScheduleRule = (kopylash.ScheduleManager.ScheduleRules) this.cboScheduleWithATMScheduleType.SelectedIndex;
      if (this.Calculated)
        this.esvATM.FillResults();
      this.richTextBox1.Text = this.esvATM.FirstTable;
      this.richTextBox2.Text = this.esvATM.SecondTable;
    }

    private void tsmiAboutProgram_Click(object sender, EventArgs e)
    {
      frmAbout frmAbout = new frmAbout();
      int num = (int) frmAbout.ShowDialog();
      frmAbout.Dispose();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmMain));
      this.tcMain = new TabControl();
      this.tpData = new TabPage();
      this.tcScheduleData = new TabControl();
      this.tpScheduleDataOperations = new TabPage();
      this.scData = new SplitContainer();
      this.grbRouteMatrix = new GroupBox();
      this.txtRouteMatrix = new TextBox();
      this.grbOperationLengthMatrix = new GroupBox();
      this.txtOperationLengthMatrix = new TextBox();
      this.tpScheduleDataAdditionalInfo = new TabPage();
      this.tlpScheduleData = new TableLayoutPanel();
      this.grbATMsProperies = new GroupBox();
      this.tlpATMProperties = new TableLayoutPanel();
      this.grbATMAvailableModules = new GroupBox();
      this.dgvATMAvailableModules = new DataGridView();
      this.grbATMStartModules = new GroupBox();
      this.dgvATMStartModules = new DataGridView();
      this.colATMNames = new DataGridViewTextBoxColumn();
      this.colATMStartModule = new DataGridViewComboBoxColumn();
      this.txtATMStateTime = new TextBox();
      this.lblATMStateTime = new Label();
      this.txtATMTakeTime = new TextBox();
      this.lblATMTakeTime = new Label();
      this.nudATMsCount = new NumericUpDown();
      this.lblATMsCount = new Label();
      this.tlpModulesProperies = new TableLayoutPanel();
      this.grbModulesProperies = new GroupBox();
      this.dgvModulesProperies = new DataGridView();
      this.colModuleName = new DataGridViewTextBoxColumn();
      this.colModuleLoadingTime = new DataGridViewTextBoxColumn();
      this.colModuleUnloadingTime = new DataGridViewTextBoxColumn();
      this.colModuleStorageCount = new DataGridViewTextBoxColumn();
      this.colVisibleInDiagram = new DataGridViewCheckBoxColumn();
      this.grbMoveTimes = new GroupBox();
      this.dgvMoveTimes = new DataGridView();
      this.tpScheduleShortestOperation = new TabPage();
      this.tpScheduleMaximumResidualLaborContent = new TabPage();
      this.tpScheduleLineBalancing = new TabPage();
      this.tpScheduleMainimumResidualLaborContent = new TabPage();
      this.tpScheduleLongestOperation = new TabPage();
      this.tpScheduleFIFO = new TabPage();
      this.tpScheduleLIFO = new TabPage();
      this.tpScheduleWithATM = new TabPage();
      this.tlpScheduleWithATM = new TableLayoutPanel();
      this.lblScheduleWithATMScheduleType = new Label();
      this.cboScheduleWithATMScheduleType = new ComboBox();
      this.tlpMain = new TableLayoutPanel();
      this.tlpCommandButtons = new TableLayoutPanel();
      this.btnNext = new Button();
      this.btnBack = new Button();
      this.msMainMenu = new MenuStrip();
      this.tsmiFile = new ToolStripMenuItem();
      this.tsmiNew = new ToolStripMenuItem();
      this.tsmiOpen = new ToolStripMenuItem();
      this.toolStripSeparator = new ToolStripSeparator();
      this.tsmiSave = new ToolStripMenuItem();
      this.tsmiSaveAs = new ToolStripMenuItem();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.tsmiExit = new ToolStripMenuItem();
      this.tsmiHelp = new ToolStripMenuItem();
      this.tsmiAboutProgram = new ToolStripMenuItem();
      this.ofdData = new OpenFileDialog();
      this.sfdData = new SaveFileDialog();
      this.tabPage1 = new TabPage();
      this.richTextBox1 = new RichTextBox();
      this.esvShortestOperation = new EnviromentScheduleView();
      this.esvMaximumResidualLaborContent = new EnviromentScheduleView();
      this.esvLineBalancing = new EnviromentScheduleView();
      this.esvMainimumResidualLaborContent = new EnviromentScheduleView();
      this.esvLongestOperation = new EnviromentScheduleView();
      this.esvFIFO = new EnviromentScheduleView();
      this.esvLIFO = new EnviromentScheduleView();
      this.esvATM = new EnviromentScheduleWithATMView();
      this.tabPage2 = new TabPage();
      this.richTextBox2 = new RichTextBox();
      this.tcMain.SuspendLayout();
      this.tpData.SuspendLayout();
      this.tcScheduleData.SuspendLayout();
      this.tpScheduleDataOperations.SuspendLayout();
      this.scData.Panel1.SuspendLayout();
      this.scData.Panel2.SuspendLayout();
      this.scData.SuspendLayout();
      this.grbRouteMatrix.SuspendLayout();
      this.grbOperationLengthMatrix.SuspendLayout();
      this.tpScheduleDataAdditionalInfo.SuspendLayout();
      this.tlpScheduleData.SuspendLayout();
      this.grbATMsProperies.SuspendLayout();
      this.tlpATMProperties.SuspendLayout();
      this.grbATMAvailableModules.SuspendLayout();
      ((ISupportInitialize) this.dgvATMAvailableModules).BeginInit();
      this.grbATMStartModules.SuspendLayout();
      ((ISupportInitialize) this.dgvATMStartModules).BeginInit();
      this.nudATMsCount.BeginInit();
      this.tlpModulesProperies.SuspendLayout();
      this.grbModulesProperies.SuspendLayout();
      ((ISupportInitialize) this.dgvModulesProperies).BeginInit();
      this.grbMoveTimes.SuspendLayout();
      ((ISupportInitialize) this.dgvMoveTimes).BeginInit();
      this.tpScheduleShortestOperation.SuspendLayout();
      this.tpScheduleMaximumResidualLaborContent.SuspendLayout();
      this.tpScheduleLineBalancing.SuspendLayout();
      this.tpScheduleMainimumResidualLaborContent.SuspendLayout();
      this.tpScheduleLongestOperation.SuspendLayout();
      this.tpScheduleFIFO.SuspendLayout();
      this.tpScheduleLIFO.SuspendLayout();
      this.tpScheduleWithATM.SuspendLayout();
      this.tlpScheduleWithATM.SuspendLayout();
      this.tlpMain.SuspendLayout();
      this.tlpCommandButtons.SuspendLayout();
      this.msMainMenu.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.SuspendLayout();
      this.tcMain.Controls.Add((Control) this.tpData);
      this.tcMain.Controls.Add((Control) this.tpScheduleShortestOperation);
      //this.tcMain.Controls.Add((Control) this.tpScheduleMaximumResidualLaborContent);

        //Скрыли левые вкладки
      //this.tcMain.Controls.Add((Control) this.tpScheduleLineBalancing);
      this.tcMain.Controls.Add((Control)this.tpScheduleMainimumResidualLaborContent);
      this.tcMain.Controls.Add((Control)this.tpScheduleLongestOperation);
      //this.tcMain.Controls.Add((Control) this.tpScheduleFIFO);
      //this.tcMain.Controls.Add((Control) this.tpScheduleLIFO);

      this.tcMain.Controls.Add((Control) this.tpScheduleWithATM);
      this.tcMain.Controls.Add((Control) this.tabPage1);
      this.tcMain.Controls.Add((Control) this.tabPage2);
      this.tcMain.Dock = DockStyle.Fill;
      this.tcMain.Location = new Point(3, 3);
      this.tcMain.Multiline = true;
      this.tcMain.Name = "tcMain";
      this.tcMain.SelectedIndex = 0;
      this.tcMain.Size = new Size(896, 486);
      this.tcMain.SizeMode = TabSizeMode.FillToRight;
      this.tcMain.TabIndex = 2;
      this.tcMain.Selecting += new TabControlCancelEventHandler(this.tcMain_Selecting);
      this.tcMain.Selected += new TabControlEventHandler(this.tcMain_Selected);
      this.tpData.Controls.Add((Control) this.tcScheduleData);
      this.tpData.Location = new Point(4, 40);
      this.tpData.Name = "tpData";
      this.tpData.Size = new Size(888, 442);
      this.tpData.TabIndex = 8;
      this.tpData.Text = "Исходные данные";
      this.tpData.UseVisualStyleBackColor = true;
      this.tcScheduleData.Controls.Add((Control) this.tpScheduleDataOperations);
      this.tcScheduleData.Controls.Add((Control) this.tpScheduleDataAdditionalInfo);
      this.tcScheduleData.Dock = DockStyle.Fill;
      this.tcScheduleData.Location = new Point(0, 0);
      this.tcScheduleData.Name = "tcScheduleData";
      this.tcScheduleData.SelectedIndex = 0;
      this.tcScheduleData.Size = new Size(888, 442);
      this.tcScheduleData.TabIndex = 0;
      this.tcScheduleData.Selecting += new TabControlCancelEventHandler(this.tcScheduleData_Selecting);
      this.tpScheduleDataOperations.Controls.Add((Control) this.scData);
      this.tpScheduleDataOperations.Location = new Point(4, 22);
      this.tpScheduleDataOperations.Name = "tpScheduleDataOperations";
      this.tpScheduleDataOperations.Padding = new Padding(3);
      this.tpScheduleDataOperations.Size = new Size(880, 416);
      this.tpScheduleDataOperations.TabIndex = 0;
      this.tpScheduleDataOperations.Text = "Операции";
      this.tpScheduleDataOperations.UseVisualStyleBackColor = true;
      this.scData.Dock = DockStyle.Fill;
      this.scData.Location = new Point(3, 3);
      this.scData.Name = "scData";
      this.scData.Panel1.Controls.Add((Control) this.grbRouteMatrix);
      this.scData.Panel2.Controls.Add((Control) this.grbOperationLengthMatrix);
      this.scData.Size = new Size(874, 410);
      this.scData.SplitterDistance = 431;
      this.scData.TabIndex = 1;
      this.grbRouteMatrix.Controls.Add((Control) this.txtRouteMatrix);
      this.grbRouteMatrix.Dock = DockStyle.Fill;
      this.grbRouteMatrix.Location = new Point(0, 0);
      this.grbRouteMatrix.Name = "grbRouteMatrix";
      this.grbRouteMatrix.Size = new Size(431, 410);
      this.grbRouteMatrix.TabIndex = 0;
      this.grbRouteMatrix.TabStop = false;
      this.grbRouteMatrix.Text = "Матрица технологических маршрутов";
      this.txtRouteMatrix.Dock = DockStyle.Fill;
      this.txtRouteMatrix.Font = new Font("Courier New", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.txtRouteMatrix.Location = new Point(3, 16);
      this.txtRouteMatrix.Multiline = true;
      this.txtRouteMatrix.Name = "txtRouteMatrix";
      this.txtRouteMatrix.ScrollBars = ScrollBars.Both;
      this.txtRouteMatrix.Size = new Size(425, 391);
      this.txtRouteMatrix.TabIndex = 0;
      this.txtRouteMatrix.WordWrap = false;
      this.txtRouteMatrix.TextChanged += new EventHandler(this.txtRouteMatrix_TextChanged);
      this.grbOperationLengthMatrix.Controls.Add((Control) this.txtOperationLengthMatrix);
      this.grbOperationLengthMatrix.Dock = DockStyle.Fill;
      this.grbOperationLengthMatrix.Location = new Point(0, 0);
      this.grbOperationLengthMatrix.Name = "grbOperationLengthMatrix";
      this.grbOperationLengthMatrix.Size = new Size(439, 410);
      this.grbOperationLengthMatrix.TabIndex = 0;
      this.grbOperationLengthMatrix.TabStop = false;
      this.grbOperationLengthMatrix.Text = "Матрица времени обработки";
      this.txtOperationLengthMatrix.Dock = DockStyle.Fill;
      this.txtOperationLengthMatrix.Font = new Font("Courier New", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.txtOperationLengthMatrix.Location = new Point(3, 16);
      this.txtOperationLengthMatrix.Multiline = true;
      this.txtOperationLengthMatrix.Name = "txtOperationLengthMatrix";
      this.txtOperationLengthMatrix.ScrollBars = ScrollBars.Both;
      this.txtOperationLengthMatrix.Size = new Size(433, 391);
      this.txtOperationLengthMatrix.TabIndex = 1;
      this.txtOperationLengthMatrix.WordWrap = false;
      this.txtOperationLengthMatrix.TextChanged += new EventHandler(this.txtOperationLengthMatrix_TextChanged);
      this.tpScheduleDataAdditionalInfo.Controls.Add((Control) this.tlpScheduleData);
      this.tpScheduleDataAdditionalInfo.Location = new Point(4, 22);
      this.tpScheduleDataAdditionalInfo.Name = "tpScheduleDataAdditionalInfo";
      this.tpScheduleDataAdditionalInfo.Padding = new Padding(3);
      this.tpScheduleDataAdditionalInfo.Size = new Size(880, 416);
      this.tpScheduleDataAdditionalInfo.TabIndex = 1;
      this.tpScheduleDataAdditionalInfo.Text = "Дополнительная информация";
      this.tpScheduleDataAdditionalInfo.UseVisualStyleBackColor = true;
      this.tlpScheduleData.ColumnCount = 1;
      this.tlpScheduleData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tlpScheduleData.Controls.Add((Control) this.grbATMsProperies, 0, 1);
      this.tlpScheduleData.Controls.Add((Control) this.tlpModulesProperies, 0, 0);
      this.tlpScheduleData.Dock = DockStyle.Fill;
      this.tlpScheduleData.Location = new Point(3, 3);
      this.tlpScheduleData.Name = "tlpScheduleData";
      this.tlpScheduleData.RowCount = 2;
      this.tlpScheduleData.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tlpScheduleData.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tlpScheduleData.Size = new Size(874, 410);
      this.tlpScheduleData.TabIndex = 5;
      this.grbATMsProperies.Controls.Add((Control) this.tlpATMProperties);
      this.grbATMsProperies.Controls.Add((Control) this.txtATMStateTime);
      this.grbATMsProperies.Controls.Add((Control) this.lblATMStateTime);
      this.grbATMsProperies.Controls.Add((Control) this.txtATMTakeTime);
      this.grbATMsProperies.Controls.Add((Control) this.lblATMTakeTime);
      this.grbATMsProperies.Controls.Add((Control) this.nudATMsCount);
      this.grbATMsProperies.Controls.Add((Control) this.lblATMsCount);
      this.grbATMsProperies.Dock = DockStyle.Fill;
      this.grbATMsProperies.Location = new Point(3, 208);
      this.grbATMsProperies.Name = "grbATMsProperies";
      this.grbATMsProperies.Size = new Size(868, 199);
      this.grbATMsProperies.TabIndex = 3;
      this.grbATMsProperies.TabStop = false;
      this.grbATMsProperies.Text = "Параметры АТМов";
      this.tlpATMProperties.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tlpATMProperties.ColumnCount = 2;
      this.tlpATMProperties.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.11737f));
      this.tlpATMProperties.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.88263f));
      this.tlpATMProperties.Controls.Add((Control) this.grbATMAvailableModules, 0, 0);
      this.tlpATMProperties.Controls.Add((Control) this.grbATMStartModules, 1, 0);
      this.tlpATMProperties.Location = new Point(9, 93);
      this.tlpATMProperties.Name = "tlpATMProperties";
      this.tlpATMProperties.RowCount = 1;
      this.tlpATMProperties.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tlpATMProperties.Size = new Size(852, 100);
      this.tlpATMProperties.TabIndex = 9;
      this.grbATMAvailableModules.Controls.Add((Control) this.dgvATMAvailableModules);
      this.grbATMAvailableModules.Dock = DockStyle.Fill;
      this.grbATMAvailableModules.Location = new Point(3, 3);
      this.grbATMAvailableModules.Name = "grbATMAvailableModules";
      this.grbATMAvailableModules.Size = new Size(420, 94);
      this.grbATMAvailableModules.TabIndex = 7;
      this.grbATMAvailableModules.TabStop = false;
      this.grbATMAvailableModules.Text = "Доступные модули";
      this.dgvATMAvailableModules.AllowUserToAddRows = false;
      this.dgvATMAvailableModules.AllowUserToDeleteRows = false;
      this.dgvATMAvailableModules.AllowUserToResizeColumns = false;
      this.dgvATMAvailableModules.AllowUserToResizeRows = false;
      this.dgvATMAvailableModules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvATMAvailableModules.ColumnHeadersVisible = false;
      this.dgvATMAvailableModules.Dock = DockStyle.Fill;
      this.dgvATMAvailableModules.Location = new Point(3, 16);
      this.dgvATMAvailableModules.Name = "dgvATMAvailableModules";
      this.dgvATMAvailableModules.RowHeadersVisible = false;
      this.dgvATMAvailableModules.Size = new Size(414, 75);
      this.dgvATMAvailableModules.TabIndex = 0;
      this.dgvATMAvailableModules.CellValueChanged += new DataGridViewCellEventHandler(this.dgvATMAvailableModules_CellValueChanged);
      this.grbATMStartModules.Controls.Add((Control) this.dgvATMStartModules);
      this.grbATMStartModules.Dock = DockStyle.Fill;
      this.grbATMStartModules.Location = new Point(429, 3);
      this.grbATMStartModules.Name = "grbATMStartModules";
      this.grbATMStartModules.Size = new Size(420, 94);
      this.grbATMStartModules.TabIndex = 8;
      this.grbATMStartModules.TabStop = false;
      this.grbATMStartModules.Text = "Начальное положение";
      this.dgvATMStartModules.AllowUserToAddRows = false;
      this.dgvATMStartModules.AllowUserToDeleteRows = false;
      this.dgvATMStartModules.AllowUserToResizeColumns = false;
      this.dgvATMStartModules.AllowUserToResizeRows = false;
      this.dgvATMStartModules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvATMStartModules.Columns.AddRange((DataGridViewColumn) this.colATMNames, (DataGridViewColumn) this.colATMStartModule);
      this.dgvATMStartModules.Dock = DockStyle.Fill;
      this.dgvATMStartModules.Location = new Point(3, 16);
      this.dgvATMStartModules.Name = "dgvATMStartModules";
      this.dgvATMStartModules.RowHeadersVisible = false;
      this.dgvATMStartModules.Size = new Size(414, 75);
      this.dgvATMStartModules.TabIndex = 1;
      this.dgvATMStartModules.CellValueChanged += new DataGridViewCellEventHandler(this.dgvATMStartModules_CellValueChanged);
      this.colATMNames.HeaderText = "АТМ";
      this.colATMNames.Name = "colATMNames";
      this.colATMNames.ReadOnly = true;
      this.colATMNames.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.colATMStartModule.HeaderText = "Стартовая позиция";
      this.colATMStartModule.Name = "colATMStartModule";
      this.txtATMStateTime.Location = new Point(119, 71);
      this.txtATMStateTime.Name = "txtATMStateTime";
      this.txtATMStateTime.Size = new Size(100, 20);
      this.txtATMStateTime.TabIndex = 6;
      this.txtATMStateTime.Text = "0";
      this.txtATMStateTime.Validating += new CancelEventHandler(this.txtATMStateTime_Validating);
      this.lblATMStateTime.AutoSize = true;
      this.lblATMStateTime.Location = new Point(6, 74);
      this.lblATMStateTime.Name = "lblATMStateTime";
      this.lblATMStateTime.Size = new Size(98, 13);
      this.lblATMStateTime.TabIndex = 5;
      this.lblATMStateTime.Text = "Время поставить:";
      this.txtATMTakeTime.Location = new Point(119, 45);
      this.txtATMTakeTime.Name = "txtATMTakeTime";
      this.txtATMTakeTime.Size = new Size(100, 20);
      this.txtATMTakeTime.TabIndex = 4;
      this.txtATMTakeTime.Text = "0";
      this.txtATMTakeTime.Validating += new CancelEventHandler(this.txtATMTakeTime_Validating);
      this.lblATMTakeTime.AutoSize = true;
      this.lblATMTakeTime.Location = new Point(6, 48);
      this.lblATMTakeTime.Name = "lblATMTakeTime";
      this.lblATMTakeTime.Size = new Size(75, 13);
      this.lblATMTakeTime.TabIndex = 3;
      this.lblATMTakeTime.Text = "Время взять:";
      this.nudATMsCount.Location = new Point(119, 19);
      NumericUpDown numericUpDown1 = this.nudATMsCount;
      int[] bits1 = new int[4];
      bits1[0] = 1;
      Decimal num1 = new Decimal(bits1);
      numericUpDown1.Minimum = num1;
      this.nudATMsCount.Name = "nudATMsCount";
      this.nudATMsCount.Size = new Size(76, 20);
      this.nudATMsCount.TabIndex = 2;
      NumericUpDown numericUpDown2 = this.nudATMsCount;
      int[] bits2 = new int[4];
      bits2[0] = 1;
      Decimal num2 = new Decimal(bits2);
      numericUpDown2.Value = num2;
      this.nudATMsCount.ValueChanged += new EventHandler(this.nudATMsCount_ValueChanged);
      this.lblATMsCount.AutoSize = true;
      this.lblATMsCount.Location = new Point(6, 21);
      this.lblATMsCount.Name = "lblATMsCount";
      this.lblATMsCount.Size = new Size(107, 13);
      this.lblATMsCount.TabIndex = 1;
      this.lblATMsCount.Text = "Количество АТМов:";
      this.tlpModulesProperies.ColumnCount = 2;
      this.tlpModulesProperies.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tlpModulesProperies.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tlpModulesProperies.Controls.Add((Control) this.grbModulesProperies, 1, 0);
      this.tlpModulesProperies.Controls.Add((Control) this.grbMoveTimes, 0, 0);
      this.tlpModulesProperies.Dock = DockStyle.Fill;
      this.tlpModulesProperies.Location = new Point(3, 3);
      this.tlpModulesProperies.Name = "tlpModulesProperies";
      this.tlpModulesProperies.RowCount = 1;
      this.tlpModulesProperies.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tlpModulesProperies.Size = new Size(868, 199);
      this.tlpModulesProperies.TabIndex = 4;
      this.grbModulesProperies.Controls.Add((Control) this.dgvModulesProperies);
      this.grbModulesProperies.Dock = DockStyle.Fill;
      this.grbModulesProperies.Location = new Point(437, 3);
      this.grbModulesProperies.Name = "grbModulesProperies";
      this.grbModulesProperies.Size = new Size(428, 193);
      this.grbModulesProperies.TabIndex = 6;
      this.grbModulesProperies.TabStop = false;
      this.grbModulesProperies.Text = "Свойства модулей";
      this.dgvModulesProperies.AllowUserToAddRows = false;
      this.dgvModulesProperies.AllowUserToDeleteRows = false;
      this.dgvModulesProperies.AllowUserToResizeColumns = false;
      this.dgvModulesProperies.AllowUserToResizeRows = false;
      this.dgvModulesProperies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvModulesProperies.Columns.AddRange((DataGridViewColumn) this.colModuleName, (DataGridViewColumn) this.colModuleLoadingTime, (DataGridViewColumn) this.colModuleUnloadingTime, (DataGridViewColumn) this.colModuleStorageCount, (DataGridViewColumn) this.colVisibleInDiagram);
      this.dgvModulesProperies.Dock = DockStyle.Fill;
      this.dgvModulesProperies.Location = new Point(3, 16);
      this.dgvModulesProperies.Name = "dgvModulesProperies";
      this.dgvModulesProperies.RowHeadersVisible = false;
      this.dgvModulesProperies.Size = new Size(422, 174);
      this.dgvModulesProperies.TabIndex = 0;
      this.dgvModulesProperies.CellValidating += new DataGridViewCellValidatingEventHandler(this.dgvModulesProperies_CellValidating);
      this.colModuleName.HeaderText = "Модуль";
      this.colModuleName.Name = "colModuleName";
      this.colModuleName.ReadOnly = true;
      this.colModuleName.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.colModuleLoadingTime.HeaderText = "Время загрузки";
      this.colModuleLoadingTime.Name = "colModuleLoadingTime";
      this.colModuleLoadingTime.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.colModuleUnloadingTime.HeaderText = "Время разгрузки";
      this.colModuleUnloadingTime.Name = "colModuleUnloadingTime";
      this.colModuleUnloadingTime.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.colModuleStorageCount.HeaderText = "Количество накопителей";
      this.colModuleStorageCount.Name = "colModuleStorageCount";
      this.colModuleStorageCount.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.colVisibleInDiagram.HeaderText = "Выводить в диаграмму";
      this.colVisibleInDiagram.Name = "colVisibleInDiagram";
      this.grbMoveTimes.Controls.Add((Control) this.dgvMoveTimes);
      this.grbMoveTimes.Dock = DockStyle.Fill;
      this.grbMoveTimes.Location = new Point(3, 3);
      this.grbMoveTimes.Name = "grbMoveTimes";
      this.grbMoveTimes.Size = new Size(428, 193);
      this.grbMoveTimes.TabIndex = 5;
      this.grbMoveTimes.TabStop = false;
      this.grbMoveTimes.Text = "Матрица времени перемещения";
      this.dgvMoveTimes.AllowUserToAddRows = false;
      this.dgvMoveTimes.AllowUserToDeleteRows = false;
      this.dgvMoveTimes.AllowUserToResizeColumns = false;
      this.dgvMoveTimes.AllowUserToResizeRows = false;
      this.dgvMoveTimes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvMoveTimes.ColumnHeadersVisible = false;
      this.dgvMoveTimes.Dock = DockStyle.Fill;
      this.dgvMoveTimes.Location = new Point(3, 16);
      this.dgvMoveTimes.Name = "dgvMoveTimes";
      this.dgvMoveTimes.RowHeadersVisible = false;
      this.dgvMoveTimes.Size = new Size(422, 174);
      this.dgvMoveTimes.TabIndex = 0;
      this.dgvMoveTimes.CellValidating += new DataGridViewCellValidatingEventHandler(this.dgvMoveTimes_CellValidating);
     
      //Правило кратчайшей операции
      this.tpScheduleShortestOperation.Controls.Add((Control) this.esvShortestOperation);
      this.tpScheduleShortestOperation.Location = new Point(4, 40);
      this.tpScheduleShortestOperation.Name = "tpScheduleShortestOperation";
      this.tpScheduleShortestOperation.Size = new Size(888, 442);
      this.tpScheduleShortestOperation.TabIndex = 0;
      this.tpScheduleShortestOperation.Text = "Правило кратчайшей операции";
      this.tpScheduleShortestOperation.UseVisualStyleBackColor = true;
      //Правило макс. остат. трудоемкости
      //this.tpScheduleMaximumResidualLaborContent.Controls.Add((Control) this.esvMaximumResidualLaborContent);
      //this.tpScheduleMaximumResidualLaborContent.Location = new Point(4, 40);
      //this.tpScheduleMaximumResidualLaborContent.Name = "tpScheduleMaximumResidualLaborContent";
      //this.tpScheduleMaximumResidualLaborContent.Size = new Size(888, 442);
      //this.tpScheduleMaximumResidualLaborContent.TabIndex = 1;
      //this.tpScheduleMaximumResidualLaborContent.Text = "Правило максимальной остаточной трудоемкости";
      //this.tpScheduleMaximumResidualLaborContent.UseVisualStyleBackColor = true;
     
        //Правило выравнивания загрузки оборудования
      //this.tpScheduleLineBalancing.Controls.Add((Control) this.esvLineBalancing);
      //this.tpScheduleLineBalancing.Location = new Point(4, 40);
      //this.tpScheduleLineBalancing.Name = "tpScheduleLineBalancing";
      //this.tpScheduleLineBalancing.Size = new Size(888, 442);
      //this.tpScheduleLineBalancing.TabIndex = 7;
      //this.tpScheduleLineBalancing.Text = "Правило выравнивания загрузки оборудования";
      //this.tpScheduleLineBalancing.UseVisualStyleBackColor = true;

      //Правило минимальной остаточной трудоемкости
      this.tpScheduleMainimumResidualLaborContent.Controls.Add((Control)this.esvMainimumResidualLaborContent);
      this.tpScheduleMainimumResidualLaborContent.Location = new Point(4, 40);
      this.tpScheduleMainimumResidualLaborContent.Name = "tpScheduleMainimumResidualLaborContent";
      this.tpScheduleMainimumResidualLaborContent.Size = new Size(888, 442);
      this.tpScheduleMainimumResidualLaborContent.TabIndex = 3;
      this.tpScheduleMainimumResidualLaborContent.Text = "Правило минимальной остаточной трудоемкости";
      this.tpScheduleMainimumResidualLaborContent.UseVisualStyleBackColor = true;

      //Правило самой длинной операции
      this.tpScheduleLongestOperation.Controls.Add((Control) this.esvLongestOperation);
      this.tpScheduleLongestOperation.Location = new Point(4, 40);
      this.tpScheduleLongestOperation.Name = "tpScheduleLongestOperation";
      this.tpScheduleLongestOperation.Size = new Size(888, 442);
      this.tpScheduleLongestOperation.TabIndex = 4;
      this.tpScheduleLongestOperation.Text = "Правило самой длинной операции";
      this.tpScheduleLongestOperation.UseVisualStyleBackColor = true;
      
        //FIFO
      //this.tpScheduleFIFO.Controls.Add((Control) this.esvFIFO);
      //this.tpScheduleFIFO.Location = new Point(4, 40);
      //this.tpScheduleFIFO.Name = "tpScheduleFIFO";
      //this.tpScheduleFIFO.Size = new Size(888, 442);
      //this.tpScheduleFIFO.TabIndex = 5;
      //this.tpScheduleFIFO.Text = "Правило FIFO";
      //this.tpScheduleFIFO.UseVisualStyleBackColor = true;
      
        //LIFO
      //this.tpScheduleLIFO.Controls.Add((Control) this.esvLIFO);
      //this.tpScheduleLIFO.Location = new Point(4, 40);
      //this.tpScheduleLIFO.Name = "tpScheduleLIFO";
      //this.tpScheduleLIFO.Size = new Size(888, 442);
      //this.tpScheduleLIFO.TabIndex = 6;
      //this.tpScheduleLIFO.Text = "Правило LIFO";
      //this.tpScheduleLIFO.UseVisualStyleBackColor = true;
      
       //C ATM 
      this.tpScheduleWithATM.Controls.Add((Control) this.tlpScheduleWithATM);
      this.tpScheduleWithATM.Location = new Point(4, 40);
      this.tpScheduleWithATM.Name = "tpScheduleWithATM";
      this.tpScheduleWithATM.Size = new Size(888, 442);
      this.tpScheduleWithATM.TabIndex = 9;
      this.tpScheduleWithATM.Text = "С АТМ";
      this.tpScheduleWithATM.UseVisualStyleBackColor = true;
      this.tlpScheduleWithATM.ColumnCount = 2;
      this.tlpScheduleWithATM.ColumnStyles.Add(new ColumnStyle());
      this.tlpScheduleWithATM.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tlpScheduleWithATM.Controls.Add((Control) this.esvATM, 0, 1);
      this.tlpScheduleWithATM.Controls.Add((Control) this.lblScheduleWithATMScheduleType, 0, 0);
      this.tlpScheduleWithATM.Controls.Add((Control) this.cboScheduleWithATMScheduleType, 1, 0);
      this.tlpScheduleWithATM.Dock = DockStyle.Fill;
      this.tlpScheduleWithATM.Location = new Point(0, 0);
      this.tlpScheduleWithATM.Name = "tlpScheduleWithATM";
      this.tlpScheduleWithATM.RowCount = 2;
      this.tlpScheduleWithATM.RowStyles.Add(new RowStyle());
      this.tlpScheduleWithATM.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tlpScheduleWithATM.Size = new Size(888, 442);
      this.tlpScheduleWithATM.TabIndex = 0;
      this.lblScheduleWithATMScheduleType.Anchor = AnchorStyles.None;
      this.lblScheduleWithATMScheduleType.AutoSize = true;
      this.lblScheduleWithATMScheduleType.Location = new Point(3, 7);
      this.lblScheduleWithATMScheduleType.Name = "lblScheduleWithATMScheduleType";
      this.lblScheduleWithATMScheduleType.Size = new Size((int) sbyte.MaxValue, 13);
      this.lblScheduleWithATMScheduleType.TabIndex = 0;
      this.lblScheduleWithATMScheduleType.Text = "Правило предпочтения:";
      this.cboScheduleWithATMScheduleType.Anchor = AnchorStyles.Left;
      this.cboScheduleWithATMScheduleType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboScheduleWithATMScheduleType.FormattingEnabled = true;
      this.cboScheduleWithATMScheduleType.Items.AddRange(new object[3]
      {
        (object) "Правило самой короткой операции",
        //(object) "Правило максимальной остаточной трудоемкости",
       
        //убрали левые правила при построении АТМ
        //(object) "Правило выравнивания загрузки оборудования",
        (object) "Правило минимальной остаточной трудоемкости",
        (object) "Правило самой длинной операции"
        //(object) "Правило FIFO",
        //(object) "Правило LIFO"
      });

       
      this.cboScheduleWithATMScheduleType.Location = new Point(136, 3);
      this.cboScheduleWithATMScheduleType.Name = "cboScheduleWithATMScheduleType";
      this.cboScheduleWithATMScheduleType.Size = new Size(363, 21);
      this.cboScheduleWithATMScheduleType.TabIndex = 1;
      this.cboScheduleWithATMScheduleType.SelectedIndexChanged += new EventHandler(this.cboScheduleWithATMScheduleType_SelectedIndexChanged);
      this.tlpMain.ColumnCount = 1;
      this.tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tlpMain.Controls.Add((Control) this.tcMain, 0, 0);
      this.tlpMain.Controls.Add((Control) this.tlpCommandButtons, 0, 1);
      this.tlpMain.Dock = DockStyle.Fill;
      this.tlpMain.Location = new Point(0, 24);
      this.tlpMain.Name = "tlpMain";
      this.tlpMain.RowCount = 2;
      this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tlpMain.RowStyles.Add(new RowStyle());
      this.tlpMain.Size = new Size(902, 537);
      this.tlpMain.TabIndex = 3;
      this.tlpCommandButtons.ColumnCount = 3;
      this.tlpCommandButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tlpCommandButtons.ColumnStyles.Add(new ColumnStyle());
      this.tlpCommandButtons.ColumnStyles.Add(new ColumnStyle());
      this.tlpCommandButtons.Controls.Add((Control) this.btnNext, 2, 0);
      this.tlpCommandButtons.Controls.Add((Control) this.btnBack, 1, 0);
      this.tlpCommandButtons.Dock = DockStyle.Fill;
      this.tlpCommandButtons.Location = new Point(3, 495);
      this.tlpCommandButtons.Name = "tlpCommandButtons";
      this.tlpCommandButtons.RowCount = 1;
      this.tlpCommandButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tlpCommandButtons.Size = new Size(896, 39);
      this.tlpCommandButtons.TabIndex = 3;
      this.btnNext.Anchor = AnchorStyles.None;
      this.btnNext.Location = new Point(818, 8);
      this.btnNext.Name = "btnNext";
      this.btnNext.Size = new Size(75, 23);
      this.btnNext.TabIndex = 0;
      this.btnNext.Text = "&Далее >";
      this.btnNext.UseVisualStyleBackColor = true;
      this.btnNext.Click += new EventHandler(this.btnNext_Click);
      this.btnBack.Anchor = AnchorStyles.None;
      this.btnBack.Location = new Point(737, 8);
      this.btnBack.Name = "btnBack";
      this.btnBack.Size = new Size(75, 23);
      this.btnBack.TabIndex = 1;
      this.btnBack.Text = "< &Назад";
      this.btnBack.UseVisualStyleBackColor = true;
      this.btnBack.Visible = false;
      this.btnBack.Click += new EventHandler(this.btnBack_Click);
      this.msMainMenu.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.tsmiFile,
        (ToolStripItem) this.tsmiHelp
      });
      this.msMainMenu.Location = new Point(0, 0);
      this.msMainMenu.Name = "msMainMenu";
      this.msMainMenu.Size = new Size(902, 24);
      this.msMainMenu.TabIndex = 4;
      this.msMainMenu.Text = "menuStrip1";
      this.tsmiFile.DropDownItems.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.tsmiNew,
        (ToolStripItem) this.tsmiOpen,
        (ToolStripItem) this.toolStripSeparator,
        (ToolStripItem) this.tsmiSave,
        (ToolStripItem) this.tsmiSaveAs,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.tsmiExit
      });
      this.tsmiFile.Name = "tsmiFile";
      this.tsmiFile.Size = new Size(48, 20);
      this.tsmiFile.Text = "&Файл";
      this.tsmiNew.Image = (Image) componentResourceManager.GetObject("tsmiNew.Image");
      this.tsmiNew.ImageTransparentColor = Color.Magenta;
      this.tsmiNew.Name = "tsmiNew";
      this.tsmiNew.ShortcutKeys = Keys.N | Keys.Control;
      this.tsmiNew.Size = new Size(172, 22);
      this.tsmiNew.Text = "&Новый";
      this.tsmiNew.Click += new EventHandler(this.tsmiNew_Click);
      this.tsmiOpen.Image = (Image) componentResourceManager.GetObject("tsmiOpen.Image");
      this.tsmiOpen.ImageTransparentColor = Color.Magenta;
      this.tsmiOpen.Name = "tsmiOpen";
      this.tsmiOpen.ShortcutKeys = Keys.O | Keys.Control;
      this.tsmiOpen.Size = new Size(172, 22);
      this.tsmiOpen.Text = "&Открыть";
      this.tsmiOpen.Click += new EventHandler(this.tsmiOpen_Click);
      this.toolStripSeparator.Name = "toolStripSeparator";
      this.toolStripSeparator.Size = new Size(169, 6);
      this.tsmiSave.Image = (Image) componentResourceManager.GetObject("tsmiSave.Image");
      this.tsmiSave.ImageTransparentColor = Color.Magenta;
      this.tsmiSave.Name = "tsmiSave";
      this.tsmiSave.ShortcutKeys = Keys.S | Keys.Control;
      this.tsmiSave.Size = new Size(172, 22);
      this.tsmiSave.Text = "&Сохранить";
      this.tsmiSave.Click += new EventHandler(this.tsmiSave_Click);
      this.tsmiSaveAs.Name = "tsmiSaveAs";
      this.tsmiSaveAs.Size = new Size(172, 22);
      this.tsmiSaveAs.Text = "Сохнанить &как...";
      this.tsmiSaveAs.Click += new EventHandler(this.tsmiSaveAs_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(169, 6);
      this.tsmiExit.Name = "tsmiExit";
      this.tsmiExit.Size = new Size(172, 22);
      this.tsmiExit.Text = "&Выход";
      this.tsmiExit.Click += new EventHandler(this.tsmiExit_Click);
      this.tsmiHelp.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.tsmiAboutProgram
      });
      this.tsmiHelp.Name = "tsmiHelp";
      this.tsmiHelp.Size = new Size(68, 20);
      this.tsmiHelp.Text = "&Помощь";
      this.tsmiAboutProgram.Name = "tsmiAboutProgram";
      this.tsmiAboutProgram.Size = new Size(158, 22);
      this.tsmiAboutProgram.Text = "О программе...";
      this.tsmiAboutProgram.Click += new EventHandler(this.tsmiAboutProgram_Click);
      this.tabPage1.Controls.Add((Control) this.richTextBox1);
      this.tabPage1.Location = new Point(4, 40);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(3);
      this.tabPage1.Size = new Size(888, 442);
      this.tabPage1.TabIndex = 10;
      this.tabPage1.Text = "Переходы";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.richTextBox1.Dock = DockStyle.Fill;
      this.richTextBox1.Location = new Point(3, 3);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new Size(882, 436);
      this.richTextBox1.TabIndex = 0;
      this.richTextBox1.Text = "";
      this.esvShortestOperation.DetailsCount = 0;
      this.esvShortestOperation.Dock = DockStyle.Fill;
      this.esvShortestOperation.Location = new Point(0, 0);
      this.esvShortestOperation.ModuleIsTempModule = (List<bool>) componentResourceManager.GetObject("esvShortestOperation.ModuleIsTempModule");
      this.esvShortestOperation.ModulesNumbers = (List<int>) componentResourceManager.GetObject("esvShortestOperation.ModulesNumbers");
      this.esvShortestOperation.Name = "esvShortestOperation";
      this.esvShortestOperation.OperationsLengthMatrix = (List<List<double>>) null;
      this.esvShortestOperation.RouteMatrix = (List<List<int>>) null;
        /////
      this.esvShortestOperation.ScheduleRule = kopylash.ScheduleManager.ScheduleRules.ShortestOperation;
        ////
      this.esvShortestOperation.Size = new Size(888, 460);
      this.esvShortestOperation.TabIndex = 0;
      //this.esvMaximumResidualLaborContent.DetailsCount = 0;
      //this.esvMaximumResidualLaborContent.Dock = DockStyle.Fill;
      //this.esvMaximumResidualLaborContent.Location = new Point(0, 0);
      //this.esvMaximumResidualLaborContent.ModuleIsTempModule = (List<bool>) componentResourceManager.GetObject("esvMaximumResidualLaborContent.ModuleIsTempModule");
      //this.esvMaximumResidualLaborContent.ModulesNumbers = (List<int>) componentResourceManager.GetObject("esvMaximumResidualLaborContent.ModulesNumbers");
      //this.esvMaximumResidualLaborContent.Name = "esvMaximumResidualLaborContent";
      //this.esvMaximumResidualLaborContent.OperationsLengthMatrix = (List<List<double>>) null;
      //this.esvMaximumResidualLaborContent.RouteMatrix = (List<List<int>>) null;
      //this.esvMaximumResidualLaborContent.ScheduleRule = kopylash.ScheduleManager.ScheduleRules.MaximumResidualLaborContent;
      //this.esvMaximumResidualLaborContent.Size = new Size(888, 460);
      //this.esvMaximumResidualLaborContent.TabIndex = 1;
      //this.esvLineBalancing.DetailsCount = 0;
      //this.esvLineBalancing.Dock = DockStyle.Fill;
      //this.esvLineBalancing.Location = new Point(0, 0);
      //this.esvLineBalancing.ModuleIsTempModule = (List<bool>) componentResourceManager.GetObject("esvLineBalancing.ModuleIsTempModule");
      //this.esvLineBalancing.ModulesNumbers = (List<int>) componentResourceManager.GetObject("esvLineBalancing.ModulesNumbers");
      //this.esvLineBalancing.Name = "esvLineBalancing";
      //this.esvLineBalancing.OperationsLengthMatrix = (List<List<double>>) null;
      //this.esvLineBalancing.RouteMatrix = (List<List<int>>) null;
      //this.esvLineBalancing.ScheduleRule = kopylash.ScheduleManager.ScheduleRules.LineBalancing;
      //this.esvLineBalancing.Size = new Size(888, 460);
      //this.esvLineBalancing.TabIndex = 1;
      this.esvMainimumResidualLaborContent.DetailsCount = 0;
      this.esvMainimumResidualLaborContent.Dock = DockStyle.Fill;
      this.esvMainimumResidualLaborContent.Location = new Point(0, 0);
      this.esvMainimumResidualLaborContent.ModuleIsTempModule = (List<bool>)componentResourceManager.GetObject("esvMainimumResidualLaborContent.ModuleIsTempModule");
      this.esvMainimumResidualLaborContent.ModulesNumbers = (List<int>)componentResourceManager.GetObject("esvMainimumResidualLaborContent.ModulesNumbers");
      this.esvMainimumResidualLaborContent.Name = "esvMainimumResidualLaborContent";
      this.esvMainimumResidualLaborContent.OperationsLengthMatrix = (List<List<double>>)null;
      this.esvMainimumResidualLaborContent.RouteMatrix = (List<List<int>>)null;
      this.esvMainimumResidualLaborContent.ScheduleRule = kopylash.ScheduleManager.ScheduleRules.MainimumResidualLaborContent;
      this.esvMainimumResidualLaborContent.Size = new Size(888, 442);
      this.esvMainimumResidualLaborContent.TabIndex = 5;
      this.esvLongestOperation.DetailsCount = 0;
      this.esvLongestOperation.Dock = DockStyle.Fill;
      this.esvLongestOperation.Location = new Point(0, 0);
      this.esvLongestOperation.ModuleIsTempModule = (List<bool>)componentResourceManager.GetObject("esvLongestOperation.ModuleIsTempModule");
      this.esvLongestOperation.ModulesNumbers = (List<int>)componentResourceManager.GetObject("esvLongestOperation.ModulesNumbers");
      this.esvLongestOperation.Name = "esvLongestOperation";
      this.esvLongestOperation.OperationsLengthMatrix = (List<List<double>>)null;
      this.esvLongestOperation.RouteMatrix = (List<List<int>>)null;
      this.esvLongestOperation.ScheduleRule = kopylash.ScheduleManager.ScheduleRules.LongestOperation;
      this.esvLongestOperation.Size = new Size(888, 442);
      this.esvLongestOperation.TabIndex = 4;
      //this.esvFIFO.DetailsCount = 0;
      //this.esvFIFO.Dock = DockStyle.Fill;
      //this.esvFIFO.Location = new Point(0, 0);
      //this.esvFIFO.ModuleIsTempModule = (List<bool>) componentResourceManager.GetObject("esvFIFO.ModuleIsTempModule");
      //this.esvFIFO.ModulesNumbers = (List<int>) componentResourceManager.GetObject("esvFIFO.ModulesNumbers");
      //this.esvFIFO.Name = "esvFIFO";
      //this.esvFIFO.OperationsLengthMatrix = (List<List<double>>) null;
      //this.esvFIFO.RouteMatrix = (List<List<int>>) null;
      //this.esvFIFO.ScheduleRule = kopylash.ScheduleManager.ScheduleRules.FIFO;
      //this.esvFIFO.Size = new Size(888, 442);
      //this.esvFIFO.TabIndex = 5;
      //this.esvLIFO.DetailsCount = 0;
      //this.esvLIFO.Dock = DockStyle.Fill;
      //this.esvLIFO.Location = new Point(0, 0);
      //this.esvLIFO.ModuleIsTempModule = (List<bool>) componentResourceManager.GetObject("esvLIFO.ModuleIsTempModule");
      //this.esvLIFO.ModulesNumbers = (List<int>) componentResourceManager.GetObject("esvLIFO.ModulesNumbers");
      //this.esvLIFO.Name = "esvLIFO";
      //this.esvLIFO.OperationsLengthMatrix = (List<List<double>>) null;
      //this.esvLIFO.RouteMatrix = (List<List<int>>) null;
      //this.esvLIFO.ScheduleRule = kopylash.ScheduleManager.ScheduleRules.LIFO;
      //this.esvLIFO.Size = new Size(888, 442);
      //this.esvLIFO.TabIndex = 6;
      this.esvATM.ATMAvailableModules = (List<List<int>>) componentResourceManager.GetObject("esvATM.ATMAvailableModules");
      this.esvATM.ATMsCount = 0;
      this.esvATM.ATMStartModules = (List<int>) componentResourceManager.GetObject("esvATM.ATMStartModules");
      this.esvATM.ATMStateTime = 0.0;
      this.esvATM.ATMTakeTime = 0.0;
      this.tlpScheduleWithATM.SetColumnSpan((Control) this.esvATM, 2);
      this.esvATM.DetailsCount = 0;
      this.esvATM.Dock = DockStyle.Fill;
      this.esvATM.Location = new Point(3, 30);
      this.esvATM.ModuleIsTempModule = (List<bool>) componentResourceManager.GetObject("esvATM.ModuleIsTempModule");
      this.esvATM.ModuleLoadingTimes = (List<double>) componentResourceManager.GetObject("esvATM.ModuleLoadingTimes");
      this.esvATM.ModulesNumbers = (List<int>) null;
      this.esvATM.ModuleStorageCount = (List<int>) componentResourceManager.GetObject("esvATM.ModuleStorageCount");
      this.esvATM.ModuleUnloadingTimes = (List<double>) componentResourceManager.GetObject("esvATM.ModuleUnloadingTimes");
      this.esvATM.MoveTimes = (List<List<double>>) componentResourceManager.GetObject("esvATM.MoveTimes");
      this.esvATM.Name = "esvATM";
      this.esvATM.OperationsLengthMatrix = (List<List<double>>) componentResourceManager.GetObject("esvATM.OperationsLengthMatrix");
      this.esvATM.RouteMatrix = (List<List<int>>) componentResourceManager.GetObject("esvATM.RouteMatrix");
      this.esvATM.ScheduleRule = kopylash.ScheduleManager.ScheduleRules.ShortestOperation;
      this.esvATM.Size = new Size(882, 409);
      this.esvATM.TabIndex = 3;
      this.tabPage2.Controls.Add((Control) this.richTextBox2);
      this.tabPage2.Location = new Point(4, 40);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(888, 442);
      this.tabPage2.TabIndex = 11;
      this.tabPage2.Text = "Состояния обработки";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.richTextBox2.Dock = DockStyle.Fill;
      this.richTextBox2.Location = new Point(3, 3);
      this.richTextBox2.Name = "richTextBox2";
      this.richTextBox2.Size = new Size(882, 436);
      this.richTextBox2.TabIndex = 0;
      this.richTextBox2.Text = "";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(902, 561);
      this.Controls.Add((Control) this.tlpMain);
      this.Controls.Add((Control) this.msMainMenu);
      this.MainMenuStrip = this.msMainMenu;
      this.Name = "frmMain";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Расписание технологического оборудования";
      this.Load += new EventHandler(this.frmMain_Load);
      this.tcMain.ResumeLayout(false);
      this.tpData.ResumeLayout(false);
      this.tcScheduleData.ResumeLayout(false);
      this.tpScheduleDataOperations.ResumeLayout(false);
      this.scData.Panel1.ResumeLayout(false);
      this.scData.Panel2.ResumeLayout(false);
      this.scData.ResumeLayout(false);
      this.grbRouteMatrix.ResumeLayout(false);
      this.grbRouteMatrix.PerformLayout();
      this.grbOperationLengthMatrix.ResumeLayout(false);
      this.grbOperationLengthMatrix.PerformLayout();
      this.tpScheduleDataAdditionalInfo.ResumeLayout(false);
      this.tlpScheduleData.ResumeLayout(false);
      this.grbATMsProperies.ResumeLayout(false);
      this.grbATMsProperies.PerformLayout();
      this.tlpATMProperties.ResumeLayout(false);
      this.grbATMAvailableModules.ResumeLayout(false);
      ((ISupportInitialize) this.dgvATMAvailableModules).EndInit();
      this.grbATMStartModules.ResumeLayout(false);
      ((ISupportInitialize) this.dgvATMStartModules).EndInit();
      this.nudATMsCount.EndInit();
      this.tlpModulesProperies.ResumeLayout(false);
      this.grbModulesProperies.ResumeLayout(false);
      ((ISupportInitialize) this.dgvModulesProperies).EndInit();
      this.grbMoveTimes.ResumeLayout(false);
      ((ISupportInitialize) this.dgvMoveTimes).EndInit();
      this.tpScheduleShortestOperation.ResumeLayout(false);
      this.tpScheduleMaximumResidualLaborContent.ResumeLayout(false);
      this.tpScheduleLineBalancing.ResumeLayout(false);
      this.tpScheduleMainimumResidualLaborContent.ResumeLayout(false);
      this.tpScheduleLongestOperation.ResumeLayout(false);
      this.tpScheduleFIFO.ResumeLayout(false);
      this.tpScheduleLIFO.ResumeLayout(false);
      this.tpScheduleWithATM.ResumeLayout(false);
      this.tlpScheduleWithATM.ResumeLayout(false);
      this.tlpScheduleWithATM.PerformLayout();
      this.tlpMain.ResumeLayout(false);
      this.tlpCommandButtons.ResumeLayout(false);
      this.msMainMenu.ResumeLayout(false);
      this.msMainMenu.PerformLayout();
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
       
    }
  }
}
