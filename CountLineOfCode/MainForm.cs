using MyCommon;
using MySplash;
using MyMessage;
using static MyCommon.MyOpenFileDialog;

namespace CountLineOfCode
{
    public partial class MainForm : Form
    {
#pragma warning disable IDE0079 // 불필요한 비표시 오류(Suppression) 제거
#pragma warning disable CA2211 // 비상수 필드는 표시할 수 없습니다.
        public static MainForm mainForm = new();
        public static List<MyCommon.FileInfo> fileInfoList = new();
        public static MyCommon.FileInfo? fileInfo;
        public static CodeInfo? codeInfo;
        private readonly static ToolTip toolTip = new();
        private static ContextMenuStrip? contextMenu;
#pragma warning restore CA2211 // 비상수 필드는 표시할 수 없습니다.
#pragma warning restore IDE0079 // 불필요한 비표시 오류(Suppression) 제거

        public MainForm()
        {
            InitializeComponent();
            MenuStripRendering();
            AddFormEventHandlers();
        }

        // A callback function, which you define in your application, that processes messages sent to a window. 
        #region WndProc
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            MyDwm.UseImmersiveDarkMode(m.HWnd, true);
        }
        #endregion WndProc

        private void AddFormEventHandlers()
        {
            Load += MainForm_Load;
            DragDrop += MainForm_DragDrop;
            DragEnter += MainForm_DragEnter;
            listViewOverall.DrawColumnHeader += ListViewOverall_DrawColumnHeader;
            listViewOverall.DrawItem += ListViewOverall_DrawItem;
            openFileToolStripMenuItem.Click += OpenFileToolStripMenuItem_Click;
            openFolderToolStripMenuItem.Click += OpenFolderToolStripMenuItem_Click;
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            printToolStripMenuItem.Click += PrintToolStripMenuItem_Click;
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            informationToolStripMenuItem.Click += InformationToolStripMenuItem_Click;
            buttonFile.Click += ButtonFile_Click;
            buttonPrint.Click += ButtonPrint_Click;
            buttonFolder.Click += ButtonFolder_Click;
            buttonClear.Click += ButtonClear_Click;
            buttonSave.Click += ButtonSave_Click;
            buttonExit.Click += ButtonExit_Click;
            tabControl1.DrawItem += TabControl1_DrawItem;
            tabControl1.MouseMove += TabControl1_MouseMove;
            tabControl1.ControlAdded += TabControl1_ControlAdded;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            tabControl1.MouseDown += TabControl1_MouseDown;
        }

        private void TabControl1_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < tabControl1.TabCount; i++)
                {
                    tabControl1.SelectedIndex = i;
                    Rectangle tabRect = tabControl1.GetTabRect(i);
                    if (tabRect.Contains(e.Location))
                    {
                        // Show context menu
                        contextMenu = new();
                        contextMenu.Items.Add("Delete", null, (sender, e) => OnMenuItemClick(sender, i));
                        contextMenu.Show(tabControl1, e.Location);
                        break;
                    }
                }
            }
        }

        private void OnMenuItemClick(object? sender, int i)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender!;
            //MyMessageBox.Show("You clicked: " + clickedItem.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (clickedItem.Text == "Delete")
            {
                tabControl1.TabPages.RemoveAt(i);
                fileInfoList.RemoveAt(i);
                MyMainCode.ListViewOverallClear();

                if (tabControl1.TabPages.Count == 0)
                {
                    panelCover.Show();
                }
                else
                {
                    tabControl1.SelectedIndex = Math.Max(0, i - 1);
                }
            }
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            mainForm = this;
            Visible = false;
            ShowInTaskbar = false;
            SplashScreenForm.SetSplashScreen(this);
        }

        private void MainForm_DragDrop(object? sender, DragEventArgs e)
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop))
            {
                try
                {
                    string[] filePath = (string[])e.Data.GetData(DataFormats.FileDrop, true);

                    for (int i = 0; i < filePath.Length; i++)
                    {
                        if (Directory.Exists(filePath[i]) || File.Exists(filePath[i]))
                        {
                            MyOpenFolderDialog.GetCodeFiles(filePath[i]);
                            MyMainCode.Run();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MyMessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void MainForm_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void TabControl1_ControlAdded(object? sender, ControlEventArgs e) => TabControl1_SelectedIndexChanged(sender, e);
        private void TabControl1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            int index = tabControl1.SelectedIndex;

            if (index != -1)
            {
                try
                {
                    MyCommon.FileInfo fi = fileInfoList[tabControl1.SelectedIndex];

                    listViewOverall.Items.Clear();

                    AddListViewItem("Code", fi.CodeLinesTotalSum, (float)fi.CodeLinesTotalSum / (float)fi.TotalLinesTotalSum * 100);
                    AddListViewItem("Comment", fi.CommentLinesTotalSum, (float)fi.CommentLinesTotalSum / (float)fi.TotalLinesTotalSum * 100);
                    AddListViewItem("Empty", fi.EmptyLinesTotalSum, (float)fi.EmptyLinesTotalSum / (float)fi.TotalLinesTotalSum * 100);
                    AddListViewItem("TOTAL", fi.TotalLinesTotalSum, (float)fi.TotalLinesTotalSum / (float)fi.TotalLinesTotalSum * 100);

                    //listViewOverall.View = View.Details;
                }
                catch (Exception)
                {
                    //MyMessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void AddListViewItem(string name, int lines, float rate)
        {
            ListViewItem item = new(name);
            item.SubItems.Add(lines.ToString());
            item.SubItems.Add(rate.ToString("F1"));

            listViewOverall.Items.Add(item);
        }

        private void TabControl1_MouseMove(object? sender, MouseEventArgs e)
        {
            TabControl _tabControl = (TabControl)sender!;

            if (_tabControl.TabPages.Count > 0)
            {
                try
                {
                    for (int i = 0; i < _tabControl.TabPages.Count; i++)
                    {
                        Rectangle tabRect = _tabControl.GetTabRect(i);

                        if (tabRect.Contains(e.Location))
                        {
                            if (toolTip.GetToolTip(_tabControl) != _tabControl.TabPages[i].ToolTipText)
                            {
                                toolTip.SetToolTip(_tabControl, _tabControl.TabPages[i].ToolTipText);
                            }
                            return;
                        }
                    }
                    toolTip.SetToolTip(_tabControl, string.Empty);
                }
                catch (Exception ex)
                {
                    MyMessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void TabControl1_DrawItem(object? sender, DrawItemEventArgs e)
        {
            TabControl _tabControl = (TabControl)sender!;

            // TabControl Color Change
            e.Graphics.FillRectangle(new SolidBrush(MyColor.BackColor), ClientRectangle);

            if (_tabControl.TabPages.Count > 0)
            {
                try
                {
                    for (int i = 0; i < _tabControl.TabPages.Count; i++)
                    {
                        TabPage _tabPage = _tabControl.TabPages[i];

                        // TabPage Color Change
                        _tabPage.BackColor = MyColor.MouseLeaveColor;
                        _tabPage.BorderStyle = BorderStyle.FixedSingle;

                        // Tab Color Change
                        Rectangle _tabRect = _tabControl.GetTabRect(i);
                        if (_tabControl.TabPages[_tabControl.SelectedIndex] == _tabPage)
                        {
                            e.Graphics.FillRectangle(new SolidBrush(MyColor.MouseLeaveColor), _tabRect);
                        }
                        else
                        {
                            e.Graphics.FillRectangle(new SolidBrush(MyColor.BackColor), _tabRect);
                            e.Graphics.DrawRectangle(new Pen(new SolidBrush(MyColor.MouseHoverColor)), _tabRect);
                        }

                        // Tab Text Draw
                        StringFormat _stringFlags = new()
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        };
                        e.Graphics.DrawString(_tabPage.Text, _tabPage.Font, new SolidBrush(MyColor.TextColor), _tabRect, _stringFlags);
                    }
                }
                catch (Exception ex)
                {
                    MyMessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void ListViewOverall_DrawColumnHeader(object? sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (sender != null)
            {
                try
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(46, 46, 46)), e.Bounds);
                    e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(219, 219, 219))), e.Bounds);
                    StringFormat stringFormat = new()
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center
                    };
                    e.Graphics.DrawString(e.Header!.Text, e.Font!, new SolidBrush(Color.FromArgb(219, 219, 219)), e.Bounds, stringFormat);
                }
                catch (Exception ex)
                {
                    MyMessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void ListViewOverall_DrawItem(object? sender, DrawListViewItemEventArgs e)
        {
            if (sender != null)
            {
                try
                {
                    // Draw the background
                    e.DrawBackground();

                    for (int i = 0; i < e.Item.SubItems.Count; i++)
                    {
                        // Draw the text
                        StringFormat stringFormat = new();
                        if (i == 0) { stringFormat.Alignment = StringAlignment.Near; }
                        else { stringFormat.Alignment = StringAlignment.Far; }
                        stringFormat.LineAlignment = StringAlignment.Center;

                        //e.Graphics.DrawString(e.Item.SubItems[i]!.Text, e.Item.SubItems[i].Font!, new SolidBrush(MyColor.TextColor), e.Item.SubItems[i].Bounds, stringFormat);
                        e.Graphics.DrawString(e.Item.SubItems[i].Text, e.Item.SubItems[i].Font!, new SolidBrush(MyColor.TextColor), e.Item.SubItems[i].Bounds, stringFormat);
                    }

                    // If the item is selected, draw the focus rectangle
                    if ((e.State & ListViewItemStates.Selected) != 0)
                    {
                        e.DrawFocusRectangle();
                    }
                }
                catch (Exception ex)
                {
                    MyMessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void MenuStripRendering() => menuStrip1.Renderer = new MyRender();
        private void ButtonFolder_Click(object? sender, EventArgs e) => OpenFileToolStripMenuItem_Click(sender, e);
        private void ButtonFile_Click(object? sender, EventArgs e) => OpenFolderToolStripMenuItem_Click(sender, e);
        private void ButtonPrint_Click(object? sender, EventArgs e) => PrintToolStripMenuItem_Click(sender, e);
        private void ButtonClear_Click(object? sender, EventArgs e) => MyMainCode.Clear();
        private void ButtonSave_Click(object? sender, EventArgs e) => SaveAsToolStripMenuItem_Click(sender, e);
        private void ButtonExit_Click(object? sender, EventArgs e) => ExitToolStripMenuItem_Click(sender, e);
        private void OpenFileToolStripMenuItem_Click(object? sender, EventArgs e) => MyOpenFileDialog.ShowDialog();
        private void OpenFolderToolStripMenuItem_Click(object? sender, EventArgs e) => MyOpenFolderDialog.ShowDialog();
        private void SaveAsToolStripMenuItem_Click(object? sender, EventArgs e) => MySaveFileDialog.ShowDialog();
        private void PrintToolStripMenuItem_Click(object? sender, EventArgs e) => MyPrintDialog.ShowDialog();
        private void ExitToolStripMenuItem_Click(object? sender, EventArgs e) => MyMainCode.Exit();
        private void InformationToolStripMenuItem_Click(object? sender, EventArgs e) => MyMessageBox.Show(MyString.Code("0099"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
