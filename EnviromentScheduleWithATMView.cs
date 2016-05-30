// Decompiled with JetBrains decompiler
// Type: Gantt.EnviromentScheduleWithATMView
// Assembly: Gantt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BAF6587B-9366-49E4-B85F-799E18470D29
// Assembly location: D:\Обучение\Универ\6 семестр\АВУГКС\ganttPetri\Gantt.exe

using DevExpress.XtraCharts;
using GanttCore;
using Microsoft.Office.Interop.Visio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Gantt
{
  public class EnviromentScheduleWithATMView : UserControl
  {
    private IContainer components;
    private DataGridView dgvScheduleTable;
    private SplitContainer scMain;
    private GroupBox grbScheduleTable;
    private TextBox txtScheduleTotalTime;
    private Label lblScheduleTotalTime;
    private Label lblScheduleTotalTimeUnit;
    private GroupBox grbScheduleChart;
    private ChartControl chtScheduleChart;
    private ContextMenuStrip cmsScheduleChart;
    private ToolStripMenuItem tsmsScheduleChartSaveToFile;
    private SaveFileDialog sfdScheduleChart;
    private List<int> _modulesNumbers;
    private int _detailsCount;
    private int _atmsCount;
    private kopylash.ScheduleManager.ScheduleRules _scheduleRule;
    private List<List<int>> _routeMatrix;
    private List<List<double>> _operationsLengthMatrix;
    private List<List<double>> _moveTimes;
    private List<double> _moduleLoadingTimes;
    private List<double> _moduleUnloadingTimes;
    private List<int> _moduleStorageCount;
    private List<List<int>> _atmAvailableModules;
    private double _atmStateTime;
    private double _atmTakeTime;
    private List<int> _atmStartModules;
    private List<bool> _moduleIsTempModule;

    public kopylash.ScheduleManager.ScheduleRules ScheduleRule
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

    public List<List<int>> RouteMatrix
    {
      get
      {
        return this._routeMatrix;
      }
      set
      {
        this._routeMatrix = value;
      }
    }

    public List<List<double>> OperationsLengthMatrix
    {
      get
      {
        return this._operationsLengthMatrix;
      }
      set
      {
        this._operationsLengthMatrix = value;
      }
    }

    public List<double> ModuleLoadingTimes
    {
      get
      {
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
        return this._moduleStorageCount;
      }
      set
      {
        this._moduleStorageCount = value;
      }
    }

    public List<int> ModulesNumbers
    {
      get
      {
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
        return this._moveTimes;
      }
      set
      {
        this._moveTimes = value;
      }
    }

    public List<List<int>> ATMAvailableModules
    {
      get
      {
        return this._atmAvailableModules;
      }
      set
      {
        this._atmAvailableModules = value;
      }
    }

    public int ATMsCount
    {
      get
      {
        return this._atmsCount;
      }
      set
      {
        this._atmsCount = value;
      }
    }

    public double ATMStateTime
    {
      get
      {
        return this._atmStateTime;
      }
      set
      {
        this._atmStateTime = value;
      }
    }

    public double ATMTakeTime
    {
      get
      {
        return this._atmTakeTime;
      }
      set
      {
        this._atmTakeTime = value;
      }
    }

    public List<int> ATMStartModules
    {
      get
      {
        return this._atmStartModules;
      }
      set
      {
        this._atmStartModules = value;
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

    public string FirstTable { get; set; }

    public string SecondTable { get; set; }

    public EnviromentScheduleWithATMView()
    {
      this.InitializeComponent();
      GanttDiagram ganttDiagram = new GanttDiagram();
      ganttDiagram.AxisX.Range.ScrollingRange.SideMarginsEnabled = true;
      ganttDiagram.AxisX.Range.SideMarginsEnabled = true;
      ganttDiagram.AxisX.VisibleInPanesSerializable = "-1";
      ganttDiagram.AxisX.Tickmarks.MinorVisible = false;
      ganttDiagram.AxisY.DateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.General;
      ganttDiagram.AxisY.Label.Staggered = true;
      ganttDiagram.AxisY.Range.ScrollingRange.SideMarginsEnabled = false;
      ganttDiagram.AxisY.Range.SideMarginsEnabled = false;
      ganttDiagram.AxisY.VisibleInPanesSerializable = "-1";
      ganttDiagram.EnableAxisXScrolling = true;
      ganttDiagram.EnableAxisYScrolling = true;
      ganttDiagram.EnableAxisXZooming = true;
      ganttDiagram.EnableAxisYZooming = true;
      this.chtScheduleChart.BeginInit();
      this.chtScheduleChart.Diagram = (Diagram) ganttDiagram;
      this.chtScheduleChart.EndInit();
      this._routeMatrix = new List<List<int>>();
      this._operationsLengthMatrix = new List<List<double>>();
      this._moveTimes = new List<List<double>>();
      this._moduleLoadingTimes = new List<double>();
      this._moduleUnloadingTimes = new List<double>();
      this._moduleStorageCount = new List<int>();
      this._atmAvailableModules = new List<List<int>>();
      this._atmStartModules = new List<int>();
      this._moduleIsTempModule = new List<bool>();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      SideBySideBarSeriesLabel sideBarSeriesLabel = new SideBySideBarSeriesLabel();
      this.dgvScheduleTable = new DataGridView();
      this.scMain = new SplitContainer();
      this.grbScheduleChart = new GroupBox();
      this.chtScheduleChart = new ChartControl();
      this.lblScheduleTotalTimeUnit = new Label();
      this.txtScheduleTotalTime = new TextBox();
      this.lblScheduleTotalTime = new Label();
      this.grbScheduleTable = new GroupBox();
      this.sfdScheduleChart = new SaveFileDialog();
      this.cmsScheduleChart = new ContextMenuStrip(this.components);
      this.tsmsScheduleChartSaveToFile = new ToolStripMenuItem();
      ((ISupportInitialize) this.dgvScheduleTable).BeginInit();
      this.scMain.Panel1.SuspendLayout();
      this.scMain.Panel2.SuspendLayout();
      this.scMain.SuspendLayout();
      this.grbScheduleChart.SuspendLayout();
      this.chtScheduleChart.BeginInit();
      //sideBarSeriesLabel.BeginInit();
      this.grbScheduleTable.SuspendLayout();
      this.cmsScheduleChart.SuspendLayout();
      this.SuspendLayout();
      this.dgvScheduleTable.AllowUserToAddRows = false;
      this.dgvScheduleTable.AllowUserToDeleteRows = false;
      this.dgvScheduleTable.AllowUserToResizeColumns = false;
      this.dgvScheduleTable.AllowUserToResizeRows = false;
      this.dgvScheduleTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvScheduleTable.ColumnHeadersVisible = false;
      this.dgvScheduleTable.Dock = DockStyle.Fill;
      this.dgvScheduleTable.Location = new Point(3, 16);
      this.dgvScheduleTable.Name = "dgvScheduleTable";
      this.dgvScheduleTable.ReadOnly = true;
      this.dgvScheduleTable.RowHeadersVisible = false;
      this.dgvScheduleTable.Size = new Size(694, 200);
      this.dgvScheduleTable.TabIndex = 0;
      this.scMain.Dock = DockStyle.Fill;
      this.scMain.Location = new Point(0, 0);
      this.scMain.Name = "scMain";
      this.scMain.Orientation = Orientation.Horizontal;
      this.scMain.Panel1.Controls.Add((Control) this.grbScheduleChart);
      this.scMain.Panel2.Controls.Add((Control) this.lblScheduleTotalTimeUnit);
      this.scMain.Panel2.Controls.Add((Control) this.txtScheduleTotalTime);
      this.scMain.Panel2.Controls.Add((Control) this.lblScheduleTotalTime);
      this.scMain.Panel2.Controls.Add((Control) this.grbScheduleTable);
      this.scMain.Size = new Size(706, 510);
      this.scMain.SplitterDistance = (int) byte.MaxValue;
      this.scMain.TabIndex = 2;
      this.grbScheduleChart.Controls.Add((Control) this.chtScheduleChart);
      this.grbScheduleChart.Dock = DockStyle.Fill;
      this.grbScheduleChart.Location = new Point(0, 0);
      this.grbScheduleChart.Name = "grbScheduleChart";
      this.grbScheduleChart.Size = new Size(706, (int) byte.MaxValue);
      this.grbScheduleChart.TabIndex = 0;
      this.grbScheduleChart.TabStop = false;
      this.grbScheduleChart.Text = "График последовательностей обработки деталей";
      this.chtScheduleChart.ContextMenuStrip = this.cmsScheduleChart;
      this.chtScheduleChart.Dock = DockStyle.Fill;
      this.chtScheduleChart.Location = new Point(3, 16);
      this.chtScheduleChart.Name = "chtScheduleChart";
      this.chtScheduleChart.PaletteName = "Palette 1";
      this.chtScheduleChart.PaletteRepository.Add("Palette 1", new Palette("Palette 1", PaletteScaleMode.Repeat, new PaletteEntry[17]
      {
        new PaletteEntry(System.Drawing.Color.FromArgb(56, 145, 167), System.Drawing.Color.FromArgb(39, 101, 117)),
        new PaletteEntry(System.Drawing.Color.FromArgb(254, 184, 10), System.Drawing.Color.FromArgb(184, 131, 1)),
        new PaletteEntry(System.Drawing.Color.FromArgb(195, 45, 46), System.Drawing.Color.FromArgb(136, 32, 32)),
        new PaletteEntry(System.Drawing.Color.FromArgb(132, 170, 51), System.Drawing.Color.FromArgb(92, 119, 36)),
        new PaletteEntry(System.Drawing.Color.FromArgb(150, 67, 5), System.Drawing.Color.FromArgb(105, 47, 3)),
        new PaletteEntry(System.Drawing.Color.FromArgb(71, 90, 141), System.Drawing.Color.FromArgb(50, 63, 99)),
        new PaletteEntry(System.Drawing.Color.FromArgb((int) byte.MaxValue, 74, 74), System.Drawing.Color.FromArgb((int) byte.MaxValue, 74, 74)),
        new PaletteEntry(System.Drawing.Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 128), System.Drawing.Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 128)),
        new PaletteEntry(System.Drawing.Color.FromArgb(128, (int) byte.MaxValue, 128), System.Drawing.Color.FromArgb(128, (int) byte.MaxValue, 128)),
        new PaletteEntry(System.Drawing.Color.FromArgb(128, (int) byte.MaxValue, (int) byte.MaxValue), System.Drawing.Color.FromArgb(128, (int) byte.MaxValue, (int) byte.MaxValue)),
        new PaletteEntry(System.Drawing.Color.FromArgb(0, 128, (int) byte.MaxValue), System.Drawing.Color.FromArgb(0, 128, (int) byte.MaxValue)),
        new PaletteEntry(System.Drawing.Color.FromArgb((int) byte.MaxValue, 128, 192), System.Drawing.Color.FromArgb((int) byte.MaxValue, 128, 192)),
        new PaletteEntry(System.Drawing.Color.Silver, System.Drawing.Color.Silver),
        new PaletteEntry(System.Drawing.Color.FromArgb(64, 0, 64), System.Drawing.Color.FromArgb(64, 0, 64)),
        new PaletteEntry(System.Drawing.Color.FromArgb(128, 0, (int) byte.MaxValue), System.Drawing.Color.FromArgb(128, 0, (int) byte.MaxValue)),
        new PaletteEntry(System.Drawing.Color.FromArgb((int) byte.MaxValue, 0, 128), System.Drawing.Color.FromArgb((int) byte.MaxValue, 0, 128)),
        new PaletteEntry(System.Drawing.Color.Fuchsia, System.Drawing.Color.Fuchsia)
      }));
      this.chtScheduleChart.SeriesSerializable = new Series[0];
      sideBarSeriesLabel.LineVisible = true;
      //sideBarSeriesLabel.OverlappingOptionsTypeName = "OverlappingOptions";
      this.chtScheduleChart.SeriesTemplate.Label = (SeriesLabelBase) sideBarSeriesLabel;
      this.chtScheduleChart.Size = new Size(700, 236);
      this.chtScheduleChart.TabIndex = 2;
      this.lblScheduleTotalTimeUnit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblScheduleTotalTimeUnit.AutoSize = true;
      this.lblScheduleTotalTimeUnit.Location = new Point(245, 231);
      this.lblScheduleTotalTimeUnit.Name = "lblScheduleTotalTimeUnit";
      this.lblScheduleTotalTimeUnit.Size = new Size(30, 13);
      this.lblScheduleTotalTimeUnit.TabIndex = 4;
      this.lblScheduleTotalTimeUnit.Text = "мин.";
      this.txtScheduleTotalTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtScheduleTotalTime.Location = new Point(161, 228);
      this.txtScheduleTotalTime.Name = "txtScheduleTotalTime";
      this.txtScheduleTotalTime.ReadOnly = true;
      this.txtScheduleTotalTime.Size = new Size(78, 20);
      this.txtScheduleTotalTime.TabIndex = 3;
      this.lblScheduleTotalTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblScheduleTotalTime.AutoSize = true;
      this.lblScheduleTotalTime.Location = new Point(3, 231);
      this.lblScheduleTotalTime.Name = "lblScheduleTotalTime";
      this.lblScheduleTotalTime.Size = new Size(152, 13);
      this.lblScheduleTotalTime.TabIndex = 2;
      this.lblScheduleTotalTime.Text = "Производственный цикл T =";
      this.grbScheduleTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grbScheduleTable.Controls.Add((Control) this.dgvScheduleTable);
      this.grbScheduleTable.Location = new Point(3, 3);
      this.grbScheduleTable.Name = "grbScheduleTable";
      this.grbScheduleTable.Size = new Size(700, 219);
      this.grbScheduleTable.TabIndex = 1;
      this.grbScheduleTable.TabStop = false;
      this.grbScheduleTable.Text = "Таблица последовательностей обработки деталей";
      this.sfdScheduleChart.DefaultExt = "bmp";
      this.sfdScheduleChart.Filter = "Файл BMP|*.bmp|Файл JPEG|*.jpg|Все файлы|*";
      this.cmsScheduleChart.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.tsmsScheduleChartSaveToFile
      });
      this.cmsScheduleChart.Name = "cmsScheduleChart";
      this.cmsScheduleChart.Size = new Size(191, 48);
      this.tsmsScheduleChartSaveToFile.Name = "tsmsScheduleChartSaveToFile";
      this.tsmsScheduleChartSaveToFile.Size = new Size(190, 22);
      this.tsmsScheduleChartSaveToFile.Text = "&Сохранить в файл...";
      this.tsmsScheduleChartSaveToFile.Click += new EventHandler(this.tsmsScheduleChartSaveToFile_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.scMain);
      this.Name = "EnviromentScheduleWithATMView";
      this.Size = new Size(706, 510);
      this.Load += new EventHandler(this.EnviromentScheduleWithATMView_Load);
      ((ISupportInitialize) this.dgvScheduleTable).EndInit();
      this.scMain.Panel1.ResumeLayout(false);
      this.scMain.Panel2.ResumeLayout(false);
      this.scMain.Panel2.PerformLayout();
      this.scMain.ResumeLayout(false);
      this.grbScheduleChart.ResumeLayout(false);
      //sideBarSeriesLabel.EndInit();
      this.chtScheduleChart.EndInit();
      this.grbScheduleTable.ResumeLayout(false);
      this.cmsScheduleChart.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public bool FillResults()
    {
      kopylash.ScheduleManager scheduleManager = new kopylash.ScheduleManager(this._modulesNumbers, this._detailsCount, this._routeMatrix, this._operationsLengthMatrix, this._scheduleRule);
      scheduleManager.GetOperatonsLength();
      kopylash.ATMScheduleManager atmScheduleManager = new kopylash.ATMScheduleManager(scheduleManager.Modules, scheduleManager.Details, this._atmsCount, this._moveTimes, this._moduleLoadingTimes, this._moduleUnloadingTimes, this._moduleStorageCount, this._atmAvailableModules, this._atmTakeTime, this._atmStateTime, this._atmStartModules, this._moduleIsTempModule);
      this.txtScheduleTotalTime.Text = atmScheduleManager.GetOperationsLength().ToString("N");
      this.chtScheduleChart.Series.Clear();
      for (int index = 0; index < atmScheduleManager.Details.Count; ++index)
      {
        this.chtScheduleChart.Series.Add(atmScheduleManager.Details[index].ToString(), ViewType.Gantt);
        //this.chtScheduleChart.Series[index].Label.OverlappingOptions.ResolveOverlapping = true;
        this.chtScheduleChart.Series[index].Label.Visible = false;
      }
      for (int index = 0; index < atmScheduleManager.ATMs.Count; ++index)
        this.chtScheduleChart.Series[0].Points.Add(new SeriesPoint(atmScheduleManager.ATMs[index].ToString()));
      for (int index = 0; index < atmScheduleManager.Modules.Count; ++index)
      {
        if (!this._moduleIsTempModule[index])
          this.chtScheduleChart.Series[0].Points.Add(new SeriesPoint(atmScheduleManager.Modules[index].ToString()));
      }
      foreach (Module module in atmScheduleManager.Modules)
      {
        if (!this._moduleIsTempModule[atmScheduleManager.Modules.IndexOf(module)])
        {
          foreach (ModuleOperation moduleOperation in module.ModuleOperations)
          {
            if (moduleOperation.State == ModuleState.Processing)
              this.chtScheduleChart.Series[atmScheduleManager.Details.IndexOf(moduleOperation.Detail)].Points.Add(new SeriesPoint(moduleOperation.Module.ToString(), new double[2]
              {
                moduleOperation.StartTime,
                moduleOperation.EndTime
              }));
          }
        }
      }
      foreach (ATM atm in atmScheduleManager.ATMs)
      {
        foreach (ATMOperation atmOperation in atm.ATMOperations)
        {
          if (atmOperation.State == ATMStates.FullOnWay)
            this.chtScheduleChart.Series[atmScheduleManager.Details.IndexOf(atmOperation.Detail)].Points.Add(new SeriesPoint(atmOperation.Atm.ToString(), new double[2]
            {
              atmOperation.StartTime,
              atmOperation.EndTime
            }));
        }
      }
      this.dgvScheduleTable.Rows.Clear();
      this.dgvScheduleTable.Columns.Clear();
      if (atmScheduleManager.Modules.Count > 0)
      {
        int num1 = 0;
        int num2 = 0;
        for (int index = 0; index < atmScheduleManager.Modules.Count; ++index)
        {
          if (!this._moduleIsTempModule[index])
          {
            int detailOperationsCount = this.GetModuleDetailOperationsCount(atmScheduleManager.Modules[index]);
            if (num1 < detailOperationsCount)
              num1 = detailOperationsCount;
            ++num2;
          }
        }
        for (int index = 0; index < atmScheduleManager.ATMs.Count; ++index)
        {
          int detailOperationsCount = this.GetATMDetailOperationsCount(atmScheduleManager.ATMs[index]);
          if (num1 < detailOperationsCount)
            num1 = detailOperationsCount;
        }
        for (int index = 0; index < num1 + 1; ++index)
        {
          this.dgvScheduleTable.Columns.Add("", "");
          this.dgvScheduleTable.Columns[index].Width = index == 0 ? 60 : 30;
          this.dgvScheduleTable.Columns[index].ReadOnly = true;
          this.dgvScheduleTable.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        this.dgvScheduleTable.Rows.Add(num2 + atmScheduleManager.ATMs.Count);
        int num3 = 67;
        string str = "";
        for (int index1 = 0; index1 < atmScheduleManager.ATMs.Count; ++index1)
        {
          ATM atm = atmScheduleManager.ATMs[index1];
          this.dgvScheduleTable.Rows[index1].Cells[0].Value =  atm.ToString();
          this.dgvScheduleTable.Rows[index1].Cells[0].Style.BackColor = SystemColors.AppWorkspace;
          int index2 = 0;
          for (int index3 = 0; index3 < atm.ATMOperations.Count; ++index3)
          {
            ATMOperation atmOperation = atm.ATMOperations[index3];
            if (atmOperation.State == ATMStates.FullOnWay)
            {
              ++index2;
              this.dgvScheduleTable.Rows[index1].Cells[index2].Value =  atmOperation.Detail.Name;
              //str = str +  "Т" + (string)  num3++ + "\t" + atm.ToString() + " транспортує Д" + (string)  atmOperation.Detail.Index + " з " + (string) (atmOperation.StartModule == null ?  "АС" :  atmOperation.StartModule.ToString()) + " на " + (string) (atmOperation.EndModule == null ?  "АС" :  atmOperation.EndModule.ToString()) + "\n";
              str = str + "Т" + num3++ + "\t" + atm.ToString() + " транспортує Д" + atmOperation.Detail.Index + " з " + (string)(atmOperation.StartModule == null ? "АС" : atmOperation.StartModule.ToString()) + " на " + (string)(atmOperation.EndModule == null ? "АС" : atmOperation.EndModule.ToString()) + "\n";
            
            }
            else if (atmOperation.State == ATMStates.EmptyOnWay && atmOperation.StartModule != atmOperation.EndModule)
              //str = str +  "Т" + (string)  num3++ + "\t" + atm.ToString() + " прямує з " + (string) (atmOperation.StartModule == null ?  "АС" :  atmOperation.StartModule.ToString()) + " на " + (string) (atmOperation.EndModule == null ?  "АС" :  atmOperation.EndModule.ToString()) + " за Д" + (string)  atmOperation.Detail.Index + "\n";
                str = str + "Т" + num3++ + "\t" + atm.ToString() + " прямує з " + (string)(atmOperation.StartModule == null ? "АС" : atmOperation.StartModule.ToString()) + " на " + (string)(atmOperation.EndModule == null ? "АС" : atmOperation.EndModule.ToString()) + " за Д" + atmOperation.Detail.Index + "\n";
          
            }
        }
        int num4 = 0;
        for (int index1 = 0; index1 < atmScheduleManager.Modules.Count; ++index1)
        {
          if (!this._moduleIsTempModule[index1])
          {
            Module module = atmScheduleManager.Modules[index1];
            this.dgvScheduleTable.Rows[num4 + atmScheduleManager.ATMs.Count].Cells[0].Value =  module.ToString();
            this.dgvScheduleTable.Rows[num4 + atmScheduleManager.ATMs.Count].Cells[0].Style.BackColor = SystemColors.AppWorkspace;
            int index2 = 0;
            for (int index3 = 0; index3 < module.ModuleOperations.Count; ++index3)
            {
              ModuleOperation moduleOperation = module.ModuleOperations[index3];
              if (moduleOperation.State == ModuleState.Processing)
              {
                ++index2;
                this.dgvScheduleTable.Rows[num4 + atmScheduleManager.ATMs.Count].Cells[index2].Value =  moduleOperation.Detail.Name;
              }
            }
            ++num4;
          }
        }
      }
      this.FillScheduleList(atmScheduleManager);
      return true;
    }

    private int GetModuleDetailOperationsCount(Module module)
    {
      if (module == null)
        return 0;
      int num = 0;
      foreach (ModuleOperation moduleOperation in module.ModuleOperations)
      {
        if (moduleOperation.State == ModuleState.Processing)
          ++num;
      }
      return num;
    }

    private int GetATMDetailOperationsCount(ATM atm)
    {
      if (atm == null)
        return 0;
      int num = 0;
      foreach (ATMOperation atmOperation in atm.ATMOperations)
      {
        if (atmOperation.State == ATMStates.FullOnWay)
          ++num;
      }
      return num;
    }

    private void EnviromentScheduleWithATMView_Load(object sender, EventArgs e)
    {
    }

    private void tsmsScheduleChartSaveToFile_Click(object sender, EventArgs e)
    {
      if (this.sfdScheduleChart.ShowDialog() != DialogResult.OK)
        return;
      this.chtScheduleChart.ExportToImage(this.sfdScheduleChart.FileName, this.sfdScheduleChart.FilterIndex != 2 ? ImageFormat.Bmp : ImageFormat.Jpeg);
    }

    private void FillScheduleList(kopylash.ATMScheduleManager atmScheduleManager)
    {
        
      string str1 = "";
      string str2 = "";
      int num1 = 1;
       
      List<EnviromentScheduleWithATMView.ModuleOperationStrings> moduleOperationStrings = new List<EnviromentScheduleWithATMView.ModuleOperationStrings>();
      foreach (Module module in atmScheduleManager.Modules)
      {
          string begining = "";
          string moduleStrings = "";
        string str3 = "";
        string str4 = string.Format("ГВМ{0}",  module.ModuleIndex);
        int num2 = 1;
        int ingibitorIndex = 1;
        string str_temp = "";
        List<ModuleOperation> detailOperations = this.GetModuleDetailOperations(module);
        for (int index1 = 0; index1 < detailOperations.Count; ++index1)
        {
          ModuleOperation moduleOperation1 = detailOperations[index1];
          EnviromentScheduleWithATMView.ModuleOperationStrings operationStrings = new EnviromentScheduleWithATMView.ModuleOperationStrings();
          operationStrings.ModuleOpration = moduleOperation1;
          int index2 = moduleOperation1.Detail.Index;
          int index3 = moduleOperation1.Operation.Index;
          string str5 = string.Format("\tР{1}_{2}\t{3} готовий обробити Д{4} на {5} операції",  num1,  moduleOperation1.Module.ModuleIndex,  num2,  str4,  index2,  index3);
          operationStrings.Line1 = str5;
          if (index1 == 0)
            str3 = str5;
          string str6 = string.Format("T{0}",  num1) + str5 + string.Format("\t{0}\t",  "вхід");
          str2 += string.Format("T{0}\tГВМ{1} обробляє Д{2} на {3} операції{4}",  num1,  moduleOperation1.Module.ModuleIndex,  index2,  index3,  Environment.NewLine);
          int num3 = num2 + 1;
          string str7 = string.Format("\tР{1}_{2}\tД{4} у{6} накопичувачі ГВМ{1} {7} {5} операці{8}",  num1,  moduleOperation1.Module.ModuleIndex,  num3,  str4,  index2,  (index3 == 1 ? index3 : index3 - 1), module.StorageCount == 2 ?  " вхідному" :  "", index3 == 1 ?  "перед" :  "після", index3 == 1 ?  "єю" :  "ї");
          operationStrings.Line2 = str7;
          string str8 = str7 + string.Format("\t{0}\t",  "вхід");
          if (module.StorageCount == 2)
            ++num3;
          string format = "\tР{1}_{2}\tД{4} у{6} накопичувачі ГВМ{1} після {5} операції";
          object[] objArray1 = new object[7];
          objArray1[0] =  num1;
          objArray1[1] =  moduleOperation1.Module.ModuleIndex;
          object[] objArray2 = objArray1;
          int index4 = 2;
          int num4 = num3;
          int num5 = 1;
          num2 = num4 + num5;
          // ISSUE: variable of a boxed type
          Int32 local = Convert.ToInt32(num4);
          objArray2[index4] =  local;
          objArray1[3] =  str4;
          objArray1[4] =  index2;
          objArray1[5] =  index3;
          objArray1[6] = module.StorageCount == 2 ?  " вихідному" :  "";
          object[] objArray3 = objArray1;
          string str9 = string.Format(format, objArray3);
          operationStrings.Line3 = str9;
          string str10 = str9 + string.Format("\t{0}",  "вихід");
          if (index1 != 0)
          {
              moduleStrings += string.Format("{1}{0}{2}{0}{3}{0}", Environment.NewLine, str6, str8, str10);
          }
          else
          {
              begining = string.Format("{1}{0}{2}{0}{3}{0}", Environment.NewLine, str6, str8, str10);
          }
          /////////////////////////
          if (index1 == ingibitorIndex)
          {
              moduleStrings += string.Format("{1}{0}", Environment.NewLine, str_temp);
             ingibitorIndex++;
          }
          str_temp = str9 + string.Format("\t{0}\t{1}", "", "інгібітор"); 
          /////////////////////
          if (index1 != detailOperations.Count - 1)
          {
            ModuleOperation moduleOperation2 = detailOperations[index1 + 1];
            int index5 = moduleOperation2.Detail.Index;
            int index6 = moduleOperation2.Operation.Index;
            string str11 = string.Format("\tР{1}_{2}\t{3} готовий обробити Д{4} на {5} операції",  num1,  moduleOperation1.Module.ModuleIndex,  num2,  str4,  index5,  index6,  "",  "вихід");
            operationStrings.Line4 = str11;
            string str12 = str11 + string.Format("\t{0}\t",  "вихід");
            if (index1 == 0)
            {
                begining += string.Format("{1}{0}", Environment.NewLine, str12);
            }
            else
            {
                moduleStrings += string.Format("{1}{0}", Environment.NewLine, str12);
            }
          }
          else
          {
              begining += string.Format("{1}{0}", Environment.NewLine, str_temp);
            operationStrings.Line4 = str3;
            moduleStrings += string.Format("{1}\t{2}{0}", Environment.NewLine, str3, "вихід");
            str1 += begining + moduleStrings;
          }
          moduleOperationStrings.Add(operationStrings);
          ++num1;
          
        }
      }
      int num6 = num1;
      List<EnviromentScheduleWithATMView.ATMOperationStrings> atmOperationStrings = new List<EnviromentScheduleWithATMView.ATMOperationStrings>();
      foreach (ATM atm in atmScheduleManager.ATMs)
      {
        string str3 = string.Format("АТМ{0}",  atm.Index);
        int num2 = 1;
        List<ATMOperation> detailOperations = this.GetATMDetailOperations(atm);
        for (int index1 = 0; index1 < detailOperations.Count; ++index1)
        {
          ATMOperation atmOperation1 = detailOperations[index1];
          EnviromentScheduleWithATMView.ATMOperationStrings operationStrings = new EnviromentScheduleWithATMView.ATMOperationStrings();
          operationStrings.atmOperation = atmOperation1;
          int index2 = atmOperation1.Detail.Index;
          string str4 = atmOperation1.StartModule == null ? "АС" : string.Format("ГВМ{0}",  atmOperation1.StartModule.ModuleIndex);
          string str5 = atmOperation1.EndModule == null ? "АС" : string.Format("ГВМ{0}",  atmOperation1.EndModule.ModuleIndex);
          int index3 = atmOperation1.Operation.Index;
          string str6 = string.Format("\tА{1}_{2}\t{3} готовий транспортувати Д{4} з {5} на {6}",  num1,  atm.Index,  num2++,  str3,  index2,  str4,  str5);
          operationStrings.Line1 = str6;
          str2 += string.Format("T{0}\t{1} транспортує Д{2} з {3} на {4}{5}",  num1,  str3,  index2,  str4,  str5,  Environment.NewLine);
          string str7;
          if (atmOperation1.StartModule != null)
            str7 = atmOperation1.EndModule != null ? this.GetModuleOperationStringByOperation(moduleOperationStrings, atmOperation1.Detail.PrevOperation(atmOperation1.Operation)).Line3 : this.GetModuleOperationStringByOperation(moduleOperationStrings, atmOperation1.Operation).Line3;
          else if (index3 == 1)
            str7 = string.Format("\tА{1}_{2}\tД{4} на {5} перед 1 операцією",  num1,  atm.Index,  num2++,  str3,  index2,  str4);
          else
            str7 = "Reserved";
          operationStrings.Line2 = str7;
          if (atmOperation1.PreviousOperation != (Operation)null)
          {
              EnviromentScheduleWithATMView.ModuleOperationStrings stringByOperation = this.GetModuleOperationStringByOperation(moduleOperationStrings, atmOperation1.PreviousOperation);
              operationStrings.Line3 = stringByOperation.Line2; //поменял на line2
          }
              //////////////
          if (index1==0)
          {
              EnviromentScheduleWithATMView.ModuleOperationStrings stringByOperation = this.GetModuleOperationStringByOperation(moduleOperationStrings, detailOperations[0].EndModule.LastOperation);
              operationStrings.Line3 = stringByOperation.Line2; //поменял на line2
          }
            ////////////////
          if (atmOperation1.Operation != (Operation) null)
          {
            if (atmOperation1.EndModule != null)
            {
              EnviromentScheduleWithATMView.ModuleOperationStrings stringByOperation = this.GetModuleOperationStringByOperation(moduleOperationStrings, atmOperation1.Operation);
              operationStrings.Line4 = stringByOperation.Line2;
            }
            else
            {
              string str8 = string.Format("\tА{0}_{1}\tД{2} на {3} після {4} операції",  atm.Index,  num2++,  index2,  str5,  index3);
              operationStrings.Line4 = str8;
            }
          }
          string str9;
          if (index1 != detailOperations.Count - 1)
          {
            ATMOperation atmOperation2 = detailOperations[index1 + 1];
            int index4 = atmOperation2.Detail.Index;
            string str8 = atmOperation2.StartModule == null ? "АС" : string.Format("ГВМ{0}",  atmOperation2.StartModule.ModuleIndex);
            string str10 = atmOperation2.EndModule == null ? "АС" : string.Format("ГВМ{0}",  atmOperation2.EndModule.ModuleIndex);
            str9 = string.Format("\tА{1}_{2}\t{3} готовий транспортувати Д{4} з {5} на {6}",  num1,  atm.Index,  num2,  str3,  index4,  str8,  str10);
          }
          else
            str9 = string.Format("\tА{0}_1\t{1} прибув на АС після усіх обробок",  atm.Index,  str3);
          operationStrings.Line5 = str9;
          atmOperationStrings.Add(operationStrings);
          ++num1;
        }
      }
      for (int index = 0; index < atmOperationStrings.Count; ++index)
      {
        EnviromentScheduleWithATMView.ATMOperationStrings operationStrings = atmOperationStrings[index];
        string str3 = str1 + string.Format("T{1}{2}\t{3}\t{0}",  Environment.NewLine,  num6,  operationStrings.Line1,  "вхід");
        if (operationStrings.Line2 == "Reserved")
        {
            operationStrings.Line2 = this.GetATMOperationStringByOperationToWarehouse(atmOperationStrings, operationStrings.atmOperation.Detail.PrevOperation(operationStrings.atmOperation.Operation)).Line4;
        }
        string str4 = str3 + string.Format("{1}\t{2}\t{0}",  Environment.NewLine,  operationStrings.Line2,  "вхід");
        
        if (operationStrings.Line3 != null)
        {
            str4 += string.Format("{1}\t\t{2}{0}", Environment.NewLine, operationStrings.Line3, "інгібітор");
        }
        if (operationStrings.Line4 != null)
        {
            str4 += string.Format("{1}\t{2}\t{0}", Environment.NewLine, operationStrings.Line4, "вихід");
        }
        str1 = str4 + string.Format("{1}\t{2}\t{0}",  Environment.NewLine,  operationStrings.Line5,  "вихід");
        ++num6;
      }
      //CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      //try
      //{
      //    Microsoft.Office.Interop.Visio.Application application = (Microsoft.Office.Interop.Visio.Application)new ApplicationClass();
      //    application.Visible = true;
      //    Document document1 = application.Documents.Add(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Type1.vsd");
      //    Document document2 = application.Documents.Add(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Type2.vsd");
      //    Document document3 = application.Documents.Add(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Type3.vsd");
      //    Document document4 = application.Documents.Add(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Type4.vsd");
      //    Selection selection1 = document1.Pages[1].CreateSelection(VisSelectionTypes.visSelTypeAll, VisSelectMode.visSelModeOnlySuper, System.Type.Missing);
      //    Selection selection2 = document2.Pages[1].CreateSelection(VisSelectionTypes.visSelTypeAll, VisSelectMode.visSelModeOnlySuper, System.Type.Missing);
      //    Selection selection3 = document3.Pages[1].CreateSelection(VisSelectionTypes.visSelTypeAll, VisSelectMode.visSelModeOnlySuper, System.Type.Missing);
      //    Selection selection4 = document4.Pages[1].CreateSelection(VisSelectionTypes.visSelTypeAll, VisSelectMode.visSelModeOnlySuper, System.Type.Missing);
      //    Page page = application.Documents.Add("").Pages[1];
      //    page.PageSheet.get_CellsSRC((short)1, (short)10, (short)0).FormulaU = "841 mm";
      //    page.PageSheet.get_CellsSRC((short)1, (short)10, (short)1).FormulaU = "593.9 mm";
      //    page.PageSheet.get_CellsSRC((short)1, (short)25, (short)16).FormulaU = "2";
      //    List<int> list1 = Enumerable.ToList<int>(Enumerable.Select<Module, int>((IEnumerable<Module>)atmScheduleManager.Modules, (Func<Module, int>)(module => this.GetModuleDetailOperations(module).Count)));
      //    List<int> list2 = Enumerable.ToList<int>(Enumerable.Select<ATM, int>((IEnumerable<ATM>)atmScheduleManager.ATMs, (Func<ATM, int>)(atm => this.GetATMDetailOperations(atm).Count)));
      //    int num2 = moduleOperationStrings[0].ModuleOpration.Module.StorageCount == 1 ? 1 : 2;
      //    Selection selection5 = num2 == 1 ? selection1 : selection2;
      //    int num3 = 0;
      //    int index1 = 0;
      //    double num4 = 580.0;
      //    double num5 = num4;
      //    double num7 = 10.0;
      //    for (int index2 = 0; index2 < moduleOperationStrings.Count; ++index2)
      //    {
      //        EnviromentScheduleWithATMView.ModuleOperationStrings operationStrings = moduleOperationStrings[index2];
      //        selection5.Copy(VisCutCopyPasteCodes.visCopyPasteNoTranslate);
      //        page.Paste(VisCutCopyPasteCodes.visCopyPasteNoTranslate);
      //        Shape primaryItem = application.ActiveWindow.Selection.PrimaryItem;
      //        string str3 = primaryItem.get_CellsSRC((short)1, (short)1, (short)2).FormulaU.Replace(" mm", "");
      //        string str4 = primaryItem.get_CellsSRC((short)1, (short)1, (short)3).FormulaU.Replace(" mm", "");
      //        primaryItem.get_CellsSRC((short)1, (short)1, (short)0).FormulaU = num7.ToString((IFormatProvider)invariantCulture) + " mm";
      //        primaryItem.get_CellsSRC((short)1, (short)1, (short)1).FormulaU = (num4 - 20.0).ToString((IFormatProvider)invariantCulture) + " mm";
      //        primaryItem.get_CellsSRC((short)1, (short)1, (short)4).FormulaU = "Width*0";
      //        primaryItem.get_CellsSRC((short)1, (short)1, (short)5).FormulaU = "Height*1";
      //        if (num5 > num4 - 20.0 - Convert.ToDouble(str4, (IFormatProvider)invariantCulture))
      //            num5 = num4 - 20.0 - Convert.ToDouble(str4, (IFormatProvider)invariantCulture);
      //        num7 += Convert.ToDouble(str3, (IFormatProvider)invariantCulture) * 2.0 / 3.0;
      //        primaryItem.Shapes[1].Text = operationStrings.Line1.Substring(1, operationStrings.Line1.IndexOf("\t", 1) - 1);
      //        primaryItem.Shapes[3].Text = operationStrings.Line2.Substring(1, operationStrings.Line2.IndexOf("\t", 1) - 1);
      //        if (num2 == 2)
      //        {
      //            primaryItem.Shapes[6].Text = operationStrings.Line3.Substring(1, operationStrings.Line3.IndexOf("\t", 1) - 1);
      //            primaryItem.Shapes[10].Text = "T" + (index2 + 1);
      //        }
      //        else
      //            primaryItem.Shapes[8].Text = "T" + (index2 + 1);
      //        if (num3 >= list1[index1] - 1)
      //        {
      //            if (index2 < moduleOperationStrings.Count - 1)
      //            {
      //                num3 = 0;
      //                ++index1;
      //                num2 = moduleOperationStrings[index2 + 1].ModuleOpration.Module.StorageCount == 1 ? 1 : 2;
      //                selection5 = num2 == 1 ? selection1 : selection2;
      //            }
      //            num4 = num5;
      //            num7 = 10.0;
      //        }
      //        else
      //            ++num3;
      //    }
      //    double num8 = num4 - 50.0;
      //    int num9 = atmOperationStrings[0].Line3 == null ? 3 : 4;
      //    Selection selection6 = num9 == 3 ? selection3 : selection4;
      //    int index3 = 0;
      //    int num10 = 0;
      //    int index4 = 0;
      //    int num11 = moduleOperationStrings.Count + 1;
      //    while (index4 < atmOperationStrings.Count)
      //    {
      //        EnviromentScheduleWithATMView.ATMOperationStrings operationStrings = atmOperationStrings[index4];
      //        selection6.Copy(VisCutCopyPasteCodes.visCopyPasteNoTranslate);
      //        page.Paste(VisCutCopyPasteCodes.visCopyPasteNoTranslate);
      //        Shape primaryItem = application.ActiveWindow.Selection.PrimaryItem;
      //        string str3 = primaryItem.get_CellsSRC((short)1, (short)1, (short)2).FormulaU.Replace(" mm", "");
      //        string str4 = primaryItem.get_CellsSRC((short)1, (short)1, (short)3).FormulaU.Replace(" mm", "");
      //        primaryItem.get_CellsSRC((short)1, (short)1, (short)0).FormulaU = num7.ToString((IFormatProvider)invariantCulture) + " mm";
      //        primaryItem.get_CellsSRC((short)1, (short)1, (short)1).FormulaU = (num8 - 20.0).ToString((IFormatProvider)invariantCulture) + " mm";
      //        primaryItem.get_CellsSRC((short)1, (short)1, (short)4).FormulaU = "Width*0";
      //        primaryItem.get_CellsSRC((short)1, (short)1, (short)5).FormulaU = "Height*1";
      //        if (num5 > num8 - 20.0 - Convert.ToDouble(str4, (IFormatProvider)invariantCulture))
      //            num5 = num8 - 20.0 - Convert.ToDouble(str4, (IFormatProvider)invariantCulture);
      //        num7 += Convert.ToDouble(str3, (IFormatProvider)invariantCulture) * 35.0 / 31.0;
      //        primaryItem.Shapes[2].Text = operationStrings.Line1.Substring(1, operationStrings.Line1.IndexOf("\t", 1) - 1);
      //        primaryItem.Shapes[6].Text = operationStrings.Line2.Substring(1, operationStrings.Line2.IndexOf("\t", 1) - 1);
      //        if (num9 == 4)
      //        {
      //            primaryItem.Shapes[8].Text = operationStrings.Line3.Substring(1, operationStrings.Line3.IndexOf("\t", 1) - 1);
      //            primaryItem.Shapes[10].Text = operationStrings.Line4.Substring(1, operationStrings.Line4.IndexOf("\t", 1) - 1);
      //        }
      //        else
      //            primaryItem.Shapes[8].Text = operationStrings.Line4.Substring(1, operationStrings.Line4.IndexOf("\t", 1) - 1);
      //        primaryItem.Shapes[1].Text = "T" + num11;
      //        if (index4 < atmOperationStrings.Count - 1)
      //        {
      //            num9 = atmOperationStrings[index4 + 1].Line3 == null ? 3 : 4;
      //            selection6 = num9 == 3 ? selection3 : selection4;
      //        }
      //        if (num10 >= list2[index3] - 1)
      //        {
      //            num10 = 0;
      //            ++index3;
      //            num8 = num5;
      //            num7 = 10.0;
      //        }
      //        else
      //            ++num10;
      //        ++index4;
      //        ++num11;
      //    }
      //}
      //catch (Exception ex)
      //{
      //    //int num2 = (int) MessageBox.Show("Ошибка вывода в Visio!");
      //    int num2 = (int)MessageBox.Show(string.Format("Ошибка вывода в Visio!{0}Сообщение: {1}", (object)Environment.NewLine, (object)ex.Message));
      //}
      this.SecondTable = str1;
      this.FirstTable = str2;
    }

    private List<ModuleOperation> GetModuleDetailOperations(Module module)
    {
      List<ModuleOperation> list = new List<ModuleOperation>();
      foreach (ModuleOperation moduleOperation in module.ModuleOperations)
      {
        if (moduleOperation.State == ModuleState.Processing)
          list.Add(moduleOperation);
      }
      return list;
    }

    private List<ATMOperation> GetATMDetailOperations(ATM atm)
    {
      List<ATMOperation> list = new List<ATMOperation>();
      foreach (ATMOperation atmOperation in atm.ATMOperations)
      {
        if (atmOperation.State == ATMStates.FullOnWay)
          list.Add(atmOperation);
      }
      return list;
    }

    private EnviromentScheduleWithATMView.ModuleOperationStrings GetModuleOperationStringByOperation(List<EnviromentScheduleWithATMView.ModuleOperationStrings> moduleOperationStrings, Operation operation)
    {
      for (int index = 0; index < moduleOperationStrings.Count; ++index)
      {
        EnviromentScheduleWithATMView.ModuleOperationStrings operationStrings = moduleOperationStrings[index];
        if (operationStrings.ModuleOpration.Operation == operation && operationStrings.ModuleOpration.Operation.Index == operation.Index)
          return operationStrings;
      }
      return (EnviromentScheduleWithATMView.ModuleOperationStrings) null;
    }

    private EnviromentScheduleWithATMView.ATMOperationStrings GetATMOperationStringByOperationToWarehouse(List<EnviromentScheduleWithATMView.ATMOperationStrings> atmOperationStrings, Operation operation)
    {
      for (int index = 0; index < atmOperationStrings.Count; ++index)
      {
        EnviromentScheduleWithATMView.ATMOperationStrings operationStrings = atmOperationStrings[index];
        if (operationStrings.atmOperation.Operation == operation && operationStrings.atmOperation.Operation.Index == operation.Index && operationStrings.atmOperation.EndModule == null)
          return operationStrings;
      }
      return (EnviromentScheduleWithATMView.ATMOperationStrings) null;
    }

    public class ModuleOperationStrings
    {
      public ModuleOperation ModuleOpration;
      public string Line1;
      public string Line2;
      public string Line3;
      public string Line4;
    }

    public class ATMOperationStrings
    {
      public ATMOperation atmOperation;
      public string Line1;
      public string Line2;
      public string Line3;
      public string Line4;
      public string Line5;
    }
  }
}
