using MyCommon;
using MyMessage;

namespace CountLineOfCode
{
    internal class MyMainCode
    {
        public static void Run()
        {
            if (MainForm.fileInfoList.Count == 0)
            {
                //MyMessageBox.Show("Select directory first!\r(NOT file(s))", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int count = MainForm.fileInfoList.Count;
            if (count > 0)
            {
                for (int i = 0; i < MainForm.fileInfoList[count - 1].CodeFileList!.Count; i++)
                {
                    string? filePath = MainForm.fileInfoList[count - 1].CodeFileList![i].CodeFileName;

                    try
                    {
                        int totalLines = 0;
                        int codeLines = 0;
                        int commentLines = 0;
                        int emptyLines = 0;
                        bool inBlockComment = false;

                        foreach (var line in File.ReadLines(filePath!))
                        {
                            totalLines++;
                            var trimmedLine = line.Trim();
                            if (string.IsNullOrEmpty(trimmedLine))
                            {
                                emptyLines++;
                            }
                            else if (inBlockComment)
                            {
                                commentLines++;
                                if (trimmedLine.EndsWith("*/"))
                                {
                                    inBlockComment = false;
                                }
                            }
                            else if (trimmedLine.StartsWith("/*"))
                            {
                                commentLines++;
                                inBlockComment = true;
                            }
                            else if (trimmedLine.StartsWith("//"))
                            {
                                commentLines++;
                            }
                            else
                            {
                                codeLines++;
                            }
                        }

                        MainForm.fileInfoList[count - 1].CodeFileList![i].CodeLines = codeLines;
                        MainForm.fileInfoList[count - 1].CodeFileList![i].CodeLinesSum += codeLines;
                        MainForm.fileInfoList[count - 1].CodeLinesTotalSum += codeLines;
                        MainForm.fileInfoList[count - 1].CodeFileList![i].CommentLines = commentLines;
                        MainForm.fileInfoList[count - 1].CodeFileList![i].CommentLinesSum += commentLines;
                        MainForm.fileInfoList[count - 1].CommentLinesTotalSum += commentLines;
                        MainForm.fileInfoList[count - 1].CodeFileList![i].EmptyLines = emptyLines;
                        MainForm.fileInfoList[count - 1].CodeFileList![i].EmptyLinesSum += emptyLines;
                        MainForm.fileInfoList[count - 1].EmptyLinesTotalSum += emptyLines;
                        MainForm.fileInfoList[count - 1].CodeFileList![i].TotalLines = totalLines;
                        MainForm.fileInfoList[count - 1].CodeFileList![i].TotalLinesSum += totalLines;
                        MainForm.fileInfoList[count - 1].TotalLinesTotalSum += totalLines;
                    }
                    catch (Exception ex)
                    {
                        MyMessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                if (MainForm.fileInfoList[count - 1].CodeFileList!.Count > 0)
                {
                    Show();
                }
            }
        }

        public static void Show()
        {
            int count = MainForm.fileInfoList.Count;
            if (count >= 1)
            {
                MainForm.mainForm.panelCover.Hide();
            }

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (!MainForm.fileInfoList[i].IsShown)
                    {
                        try
                        {
                            List<CodeInfo>? cfl = MainForm.fileInfoList[i].CodeFileList;

                            string? _dirName = Path.GetFileName(MainForm.fileInfoList[i].OpenFilePath);
                            TabPage _tabPage = new(_dirName)
                            {
                                ToolTipText = MainForm.fileInfoList[i].OpenFilePath,
                            };

                            ListView _listView = new()
                            {
                                Name = _dirName,
                                Dock = DockStyle.Fill,
                                BackColor = MyColor.MouseLeaveColor,
                                GridLines = true,
                                OwnerDraw = true,
                                View = View.Details
                            };
                            _listView.DrawColumnHeader += ListView_DrawColumnHeader;
                            _listView.DrawItem += ListView_DrawItem;

                            _listView.Columns.Add("Code File Name");
                            _listView.Columns.Add("Code");
                            _listView.Columns.Add("Comment");
                            _listView.Columns.Add("Empty");
                            _listView.Columns.Add("TOTAL");

                            _listView.Columns[0].Width = ListViewColumnWidth(_listView);

                            for (int j = 0; j < cfl!.Count; j++)
                            {
                                ListViewItem _listViewItem = new(new[]{ Path.GetFileName(cfl[j].CodeFileName!.ToString()), 
                                                             cfl[j].CodeLines.ToString() + " (" + ((float)cfl[j].CodeLines! / (float)cfl[j].TotalLines! * 100).ToString("F1") + " %)", 
                                                             cfl[j].CommentLines.ToString() + " (" + ((float)cfl[j].CommentLines! / (float)cfl[j].TotalLines! * 100).ToString("F1") + " %)", 
                                                             cfl[j].EmptyLines.ToString() + " (" + ((float)cfl[j].EmptyLines! / (float)cfl[j].TotalLines! * 100).ToString("F1") + " %)", 
                                                             cfl[j].TotalLines.ToString() + " (" + ((float)cfl[j].TotalLines! / (float)cfl[j].TotalLines! * 100).ToString("F0") + " %)"});
                                _listView.Items.Add(_listViewItem);
                            }
                            _tabPage.Controls.Add(_listView);
                            
                            MainForm.fileInfoList[i].IsShown = true;
                            MainForm.mainForm.tabControl1.Controls.Add(_tabPage);
                            MainForm.mainForm.tabControl1.SelectedIndex = MainForm.mainForm.tabControl1.Controls.IndexOf(_tabPage);
                        }
                        catch (Exception ex)
                        {
                            MyMessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        private static int ListViewColumnWidth(ListView listView)
        {
            int sum = 0;
            for (int i = 1; i < listView.Columns.Count; i++)
            {
                listView.Columns[i].Width = 120;
                sum += listView.Columns[i].Width;
            }

            return (MainForm.mainForm.tabControl1.Width - sum - 14);
        }

        private static void ListView_DrawColumnHeader(object? sender, DrawListViewColumnHeaderEventArgs e)
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

        private static void ListView_DrawItem(object? sender, DrawListViewItemEventArgs e)
        {
            ListView _listView = (ListView)sender!;

            // Draw the background
            e.DrawBackground();

            try
            {
                for (int i = 0; i < e.Item.SubItems.Count; i++)
                {
                    string limitedText = GetLimitedText(e.Graphics, e.Item.SubItems[i]!.Text, e.Item.SubItems[i].Font!, _listView.Columns[0].Width);

                    // Draw the text
                    StringFormat stringFormat = new()
                    {
                        LineAlignment = StringAlignment.Center
                    };
                    if (i == 0)
                    {
                        stringFormat.Alignment = StringAlignment.Near;
                    }
                    else
                    {
                        stringFormat.Alignment = StringAlignment.Far;
                    }

                    e.Graphics.DrawString(limitedText, e.Item.SubItems[i].Font!, new SolidBrush(MyColor.TextColor), e.Item.SubItems[i].Bounds, stringFormat);
                }
                // If the item is selected, draw the focus rectangle
                /*
                if ((e.State & ListViewItemStates.Selected) != 0)
                {
                    e.DrawFocusRectangle();
                }
                */
            }
            catch (Exception ex)
            {
                MyMessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private static string GetLimitedText(Graphics g, string text, Font font, float maxWidth)
        {
            SizeF size = g.MeasureString(text, font);
            SizeF sizeDot = g.MeasureString(".", font);
            bool limited = false;

            while (size.Width + sizeDot.Width > maxWidth && text.Length > 0)
            {
                text = text[..^1];
                size = g.MeasureString(text, font);
                limited = true;
            }

            if (limited)
            {
                text = string.Concat(text.AsSpan(0, text.Length), "...");
            }

            return text;
        }

        public static void Clear()
        {
            if (MainForm.fileInfoList.Count > 0) 
            {
                MainForm.fileInfoList.Clear();

                /* clear also TabControl's controls */
                MainForm.mainForm.tabControl1.Controls.Clear();

                ListViewOverallClear();

                //MyMessageBox.Show("All cleared!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MyMessageBox.Show("No result exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (MainForm.fileInfoList.Count == 0)
            {
                MainForm.mainForm.panelCover.Show();
            }
        }

        public static void Save(string filePath)
        {
            if (MainForm.fileInfoList.Count > 0)
            {
                StreamWriter outputFile = new(filePath);
                outputFile.WriteLine(filePath);

                for (int i = 0; i < MainForm.fileInfoList.Count; i++)
                {
                    outputFile.WriteLine();
                    outputFile.WriteLine("Parent Directory Name: " + MainForm.fileInfoList[i].OpenFilePath);
                    outputFile.WriteLine("=".PadRight(96, '='));
                    outputFile.WriteLine("File Name".PadRight(48, ' ') 
                                       + "Code".PadLeft(12, ' ')
                                       + "Comment".PadLeft(12, ' ')
                                       + "Empty".PadLeft(12, ' ')
                                       + "Total".PadLeft(12, ' '));
                    outputFile.WriteLine("-".PadRight(96, '-'));

                    List<CodeInfo> lci = MainForm.fileInfoList[i].CodeFileList!;
                    foreach (CodeInfo ci in lci)
                    {
                        string line = Path.GetFileName(ci.CodeFileName!.ToString()).PadRight(48, ' ')
                                    + ci.CodeLines.ToString().PadLeft(12, ' ')
                                    + ci.CommentLines.ToString().PadLeft(12, ' ')
                                    + ci.EmptyLines.ToString().PadLeft(12, ' ')
                                    + ci.TotalLines.ToString().PadLeft(12, ' ');
                        outputFile.WriteLine(line);
                    }

                    outputFile.WriteLine("-".PadRight(96, '-'));
                    string total = "TOTAL".PadLeft(48, ' ')
                                 + MainForm.fileInfoList[i].CodeLinesTotalSum.ToString().PadLeft(12, ' ')
                                 + MainForm.fileInfoList[i].CommentLinesTotalSum.ToString().PadLeft(12, ' ')
                                 + MainForm.fileInfoList[i].EmptyLinesTotalSum.ToString().PadLeft(12, ' ')
                                 + MainForm.fileInfoList[i].TotalLinesTotalSum.ToString().PadLeft(12, ' ');
                    outputFile.WriteLine(total);
                    outputFile.WriteLine("=".PadRight(96, '='));
                    outputFile.WriteLine();
                }

                outputFile.Close();
            }
        }

        public static void ListViewOverallClear()
        {
            MainForm.mainForm.listViewOverall.Items.Clear();
            MainForm.mainForm.listViewOverall.Items.AddRange(new[] { new ListViewItem("Code"),
                                                                         new ListViewItem("Comment"),
                                                                         new ListViewItem("Empty"),
                                                                         new ListViewItem("TOTAL")});
        }

        public static void Exit()
        {
            DialogResult dialogResult = MyMessageBox.Show("Really exit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
                Application.Exit();
            else
                return;
        }
    }
}
