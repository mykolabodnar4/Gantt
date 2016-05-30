// Decompiled with JetBrains decompiler
// Type: Gantt.EnviromentScheduleView
// Assembly: Gantt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BAF6587B-9366-49E4-B85F-799E18470D29
// Assembly location: D:\Обучение\Универ\6 семестр\АВУГКС\ganttPetri\Gantt.exe

using DevExpress.XtraCharts;
using GanttCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace Gantt
{
  public class EnviromentScheduleView : UserControl
  {
    private IContainer components;
    private DataGridView dgvScheduleTable;
    private SplitContainer scMain;
    private SplitContainer scChild;
    private GroupBox grbScheduleTable;
    private TextBox txtScheduleTotalTime;
    private Label lblScheduleTotalTime;
    private Label lblScheduleTotalTimeUnit;
    private GroupBox grbScheduleChart;
    private ChartControl chtScheduleChart;
    private ContextMenuStrip cmsScheduleChart;
    private ToolStripMenuItem tsmsScheduleChartSaveToFile;
    private SaveFileDialog sfdScheduleChart;
    private RichTextBox richTextBox1;
    private List<int> _modulesNumbers;
    private int _detailsCount;
    private kopylash.ScheduleManager.ScheduleRules _scheduleRule;
    private List<List<int>> _routeMatrix;
    private List<List<double>> _operationsLengthMatrix;
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

    public EnviromentScheduleView()
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
      this._modulesNumbers = new List<int>();
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
      this.cmsScheduleChart = new ContextMenuStrip(this.components);
      this.tsmsScheduleChartSaveToFile = new ToolStripMenuItem();
      this.scChild = new SplitContainer();
      this.lblScheduleTotalTimeUnit = new Label();
      this.txtScheduleTotalTime = new TextBox();
      this.lblScheduleTotalTime = new Label();
      this.grbScheduleTable = new GroupBox();
      this.sfdScheduleChart = new SaveFileDialog();
      this.richTextBox1 = new RichTextBox();
      ((ISupportInitialize) this.dgvScheduleTable).BeginInit();
      this.scMain.Panel1.SuspendLayout();
      this.scMain.Panel2.SuspendLayout();
      this.scMain.SuspendLayout();
      this.grbScheduleChart.SuspendLayout();
      this.chtScheduleChart.BeginInit();
      //sideBarSeriesLabel.BeginInit();
      this.cmsScheduleChart.SuspendLayout();
      this.scChild.Panel1.SuspendLayout();
      this.scChild.Panel2.SuspendLayout();
      this.scChild.SuspendLayout();
      this.grbScheduleTable.SuspendLayout();
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
      this.dgvScheduleTable.Size = new Size(1250, 78);
      this.dgvScheduleTable.TabIndex = 0;
      this.scMain.Dock = DockStyle.Fill;
      this.scMain.Location = new Point(0, 0);
      this.scMain.Name = "scMain";
      this.scMain.Orientation = Orientation.Horizontal;
      this.scMain.Panel1.Controls.Add((Control) this.grbScheduleChart);
      this.scMain.Panel2.Controls.Add((Control) this.scChild);
      this.scMain.Size = new Size(706, 510);
      this.scMain.SplitterDistance = (int) byte.MaxValue;
      this.scMain.TabIndex = 1;
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
        new PaletteEntry(Color.FromArgb(56, 145, 167), Color.FromArgb(39, 101, 117)),
        new PaletteEntry(Color.FromArgb(254, 184, 10), Color.FromArgb(184, 131, 1)),
        new PaletteEntry(Color.FromArgb(195, 45, 46), Color.FromArgb(136, 32, 32)),
        new PaletteEntry(Color.FromArgb(132, 170, 51), Color.FromArgb(92, 119, 36)),
        new PaletteEntry(Color.FromArgb(150, 67, 5), Color.FromArgb(105, 47, 3)),
        new PaletteEntry(Color.FromArgb(71, 90, 141), Color.FromArgb(50, 63, 99)),
        new PaletteEntry(Color.FromArgb((int) byte.MaxValue, 74, 74), Color.FromArgb((int) byte.MaxValue, 74, 74)),
        new PaletteEntry(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 128), Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 128)),
        new PaletteEntry(Color.FromArgb(128, (int) byte.MaxValue, 128), Color.FromArgb(128, (int) byte.MaxValue, 128)),
        new PaletteEntry(Color.FromArgb(128, (int) byte.MaxValue, (int) byte.MaxValue), Color.FromArgb(128, (int) byte.MaxValue, (int) byte.MaxValue)),
        new PaletteEntry(Color.FromArgb(0, 128, (int) byte.MaxValue), Color.FromArgb(0, 128, (int) byte.MaxValue)),
        new PaletteEntry(Color.FromArgb((int) byte.MaxValue, 128, 192), Color.FromArgb((int) byte.MaxValue, 128, 192)),
        new PaletteEntry(Color.Silver, Color.Silver),
        new PaletteEntry(Color.FromArgb(64, 0, 64), Color.FromArgb(64, 0, 64)),
        new PaletteEntry(Color.FromArgb(128, 0, (int) byte.MaxValue), Color.FromArgb(128, 0, (int) byte.MaxValue)),
        new PaletteEntry(Color.FromArgb((int) byte.MaxValue, 0, 128), Color.FromArgb((int) byte.MaxValue, 0, 128)),
        new PaletteEntry(Color.Fuchsia, Color.Fuchsia)
      }));
      this.chtScheduleChart.SeriesSerializable = new Series[0];
      sideBarSeriesLabel.LineVisible = true;
      //sideBarSeriesLabel.OverlappingOptionsTypeName = "OverlappingOptions";
      this.chtScheduleChart.SeriesTemplate.Label = (SeriesLabelBase) sideBarSeriesLabel;
      this.chtScheduleChart.Size = new Size(700, 236);
      this.chtScheduleChart.TabIndex = 2;
      this.cmsScheduleChart.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.tsmsScheduleChartSaveToFile
      });
      this.cmsScheduleChart.Name = "cmsScheduleChart";
      this.cmsScheduleChart.Size = new Size(183, 26);
      this.tsmsScheduleChartSaveToFile.Name = "tsmsScheduleChartSaveToFile";
      this.tsmsScheduleChartSaveToFile.Size = new Size(182, 22);
      this.tsmsScheduleChartSaveToFile.Text = "&Сохранить в файл...";
      this.tsmsScheduleChartSaveToFile.Click += new EventHandler(this.tsmsScheduleChartSaveToFile_Click);
      this.scChild.Dock = DockStyle.Fill;
      this.scChild.Location = new Point(0, 0);
      this.scChild.Name = "scChild";
      this.scChild.Orientation = Orientation.Horizontal;
      this.scChild.Panel1.Controls.Add((Control) this.richTextBox1);
      this.scChild.Panel2.Controls.Add((Control) this.lblScheduleTotalTimeUnit);
      this.scChild.Panel2.Controls.Add((Control) this.txtScheduleTotalTime);
      this.scChild.Panel2.Controls.Add((Control) this.lblScheduleTotalTime);
      this.scChild.Panel2.Controls.Add((Control) this.grbScheduleTable);
      this.scChild.Size = new Size(706, 251);
      this.scChild.SplitterDistance = 123;
      this.scChild.TabIndex = 0;
      this.lblScheduleTotalTimeUnit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblScheduleTotalTimeUnit.AutoSize = true;
      this.lblScheduleTotalTimeUnit.Location = new Point(245, 103);
      this.lblScheduleTotalTimeUnit.Name = "lblScheduleTotalTimeUnit";
      this.lblScheduleTotalTimeUnit.Size = new Size(30, 13);
      this.lblScheduleTotalTimeUnit.TabIndex = 4;
      this.lblScheduleTotalTimeUnit.Text = "мин.";
      this.txtScheduleTotalTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtScheduleTotalTime.Location = new Point(161, 100);
      this.txtScheduleTotalTime.Name = "txtScheduleTotalTime";
      this.txtScheduleTotalTime.ReadOnly = true;
      this.txtScheduleTotalTime.Size = new Size(78, 20);
      this.txtScheduleTotalTime.TabIndex = 3;
      this.lblScheduleTotalTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblScheduleTotalTime.AutoSize = true;
      this.lblScheduleTotalTime.Location = new Point(3, 103);
      this.lblScheduleTotalTime.Name = "lblScheduleTotalTime";
      this.lblScheduleTotalTime.Size = new Size(152, 13);
      this.lblScheduleTotalTime.TabIndex = 2;
      this.lblScheduleTotalTime.Text = "Производственный цикл T =";
      this.grbScheduleTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grbScheduleTable.Controls.Add((Control) this.dgvScheduleTable);
      this.grbScheduleTable.Location = new Point(3, 3);
      this.grbScheduleTable.Name = "grbScheduleTable";
      this.grbScheduleTable.Size = new Size(1256, 97);
      this.grbScheduleTable.TabIndex = 1;
      this.grbScheduleTable.TabStop = false;
      this.grbScheduleTable.Text = "Таблица последовательностей обработки деталей";
      this.sfdScheduleChart.DefaultExt = "bmp";
      this.sfdScheduleChart.Filter = "Файл BMP|*.bmp|Файл JPEG|*.jpg|Все файлы|*";
      this.richTextBox1.Dock = DockStyle.Fill;
      this.richTextBox1.Location = new Point(0, 0);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new Size(706, 123);
      this.richTextBox1.TabIndex = 0;
      this.richTextBox1.Text = "";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.scMain);
      this.Name = "EnviromentScheduleView";
      this.Size = new Size(706, 510);
      this.Load += new EventHandler(this.EnviromentScheduleView_Load);
      ((ISupportInitialize) this.dgvScheduleTable).EndInit();
      this.scMain.Panel1.ResumeLayout(false);
      this.scMain.Panel2.ResumeLayout(false);
      this.scMain.ResumeLayout(false);
      this.grbScheduleChart.ResumeLayout(false);
      //sideBarSeriesLabel.EndInit();
      this.chtScheduleChart.EndInit();
      this.cmsScheduleChart.ResumeLayout(false);
      this.scChild.Panel1.ResumeLayout(false);
      this.scChild.Panel2.ResumeLayout(false);
      this.scChild.Panel2.PerformLayout();
      this.scChild.ResumeLayout(false);
      this.grbScheduleTable.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public bool FillResults()
    {
      try
      {
        kopylash.ScheduleManager scheduleManager = new kopylash.ScheduleManager(this.ModulesNumbers, this.DetailsCount, this.RouteMatrix, this.OperationsLengthMatrix, this.ScheduleRule);
        this.txtScheduleTotalTime.Text = scheduleManager.GetOperatonsLength().ToString("N");
        
        this.chtScheduleChart.Series.Clear();
        for (int index1 = 0; index1 < scheduleManager.Details.Count; ++index1)
        {
          this.chtScheduleChart.Series.Add(string.Format("Деталь {0}", (object) (index1 + 1)), ViewType.Gantt);
          //this.chtScheduleChart.Series[index1].Label.OverlappingOptions.ResolveOverlapping = true;
          this.chtScheduleChart.Series[index1].Label.Visible = false;
          if (index1 == 0)
          {
            for (int index2 = 0; index2 < scheduleManager.Modules.Count; ++index2)
            {
              if (!this._moduleIsTempModule[index2])
                this.chtScheduleChart.Series[0].Points.Add(new SeriesPoint(scheduleManager.Modules[index2].ToString()));
            }
          }
          for (int index2 = 0; index2 < scheduleManager.Details[index1].Operations.Count; ++index2)
          {
            Operation operation = scheduleManager.Details[index1].Operations[index2];
            if (!this._moduleIsTempModule[scheduleManager.Modules.IndexOf(operation.Module)])
              this.chtScheduleChart.Series[index1].Points.Add(new SeriesPoint(operation.Module.ToString(), new double[2]
              {
                operation.StartTime,
                operation.EndTime
              }));
          }
        }
        this.dgvScheduleTable.Rows.Clear();
        this.dgvScheduleTable.Columns.Clear();
        if (scheduleManager.Modules.Count > 0)
        {
          int num = 0;
          int count = 0;
          for (int index = 0; index < scheduleManager.Modules.Count; ++index)
          {
            if (!this._moduleIsTempModule[index])
            {
              if (num < scheduleManager.Modules[index].OperationSequence.Count)
                num = scheduleManager.Modules[index].OperationSequence.Count;
              ++count;
            }
          }
          for (int index = 0; index < num + 1; ++index)
          {
            this.dgvScheduleTable.Columns.Add("", "");
            this.dgvScheduleTable.Columns[index].Width = index == 0 ? 60 : 30;
            this.dgvScheduleTable.Columns[index].ReadOnly = true;
            this.dgvScheduleTable.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
          }
          this.dgvScheduleTable.Rows.Add(count);
          int index1 = 0;
          for (int index2 = 0; index2 < scheduleManager.Modules.Count; ++index2)
          {
            if (!this._moduleIsTempModule[index2])
            {
              Module module = scheduleManager.Modules[index2];
              this.dgvScheduleTable.Rows[index1].Cells[0].Value = (object) module.ToString();
              this.dgvScheduleTable.Rows[index1].Cells[0].Style.BackColor = SystemColors.AppWorkspace;
              for (int index3 = 0; index3 < module.OperationSequence.Count; ++index3)
              {
                Operation operation = module.OperationSequence[index3];
                this.dgvScheduleTable.Rows[index1].Cells[index3 + 1].Value = (object) operation.Detail.Name;
              }
              ++index1;
            }
          }
          string str1 = "";
            //вывод портфелей, тут ошибка кастования ГВМ к string
          foreach (KeyValuePair<int, List<string>> keyValuePair in (IEnumerable<KeyValuePair<int, List<string>>>)Enumerable.OrderBy<KeyValuePair<int, List<string>>, int>((IEnumerable<KeyValuePair<int, List<string>>>)scheduleManager.Portfeils, (Func<KeyValuePair<int, List<string>>, int>)(item => item.Key)))
          {
              str1 += scheduleManager.GetModuleByNumber(keyValuePair.Key);
              foreach (string str2 in keyValuePair.Value)
                  str1 = str1 + "\tПортфель " + (keyValuePair.Value.IndexOf(str2) + 1) + "\t" + str2.Replace("\n", "\n\t\t") + "\n";
              str1 += "\t\t\t\t\n";
          }
          this.richTextBox1.Text = str1;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(string.Format("Ошибка при составлении расписания!{0}Сообщение: {1}", Environment.NewLine, ex.Message), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      return true;
    }

    private void EnviromentScheduleView_Load(object sender, EventArgs e)
    {
    }

    private void tsmsScheduleChartSaveToFile_Click(object sender, EventArgs e)
    {
      if (this.sfdScheduleChart.ShowDialog() != DialogResult.OK)
        return;
      this.chtScheduleChart.ExportToImage(this.sfdScheduleChart.FileName, this.sfdScheduleChart.FilterIndex != 2 ? ImageFormat.Bmp : ImageFormat.Jpeg);
    }
  }
}
