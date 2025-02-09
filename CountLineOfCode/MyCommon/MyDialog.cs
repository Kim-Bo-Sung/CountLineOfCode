using System.Drawing.Printing;
using System.Windows.Forms;
using CountLineOfCode;
using MyMessage;

namespace MyCommon
{
    public class MyOpenFileDialog
    {
        public static void ShowDialog()
        {
            OpenFileDialog openFileDialog = new()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Filter = "All files (*.*)|*.*|"
                   + "C files (*.c)|*.c|"
                   + "H files (*.h)|*.h|"
                   + "CPP files (*.cpp)|*.cpp|"
                   + "HPP files (*.hpp)|*.hpp|"
                   + "CS files (*.cs)|*.cs|"
                   + "S files (*.s)|*.s",
                FilterIndex = 1,            // Default filter index
                RestoreDirectory = true,    // Restore the last accessed directory
                Multiselect = true          // Allow multiple files to be selected
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Get the selected file path
                    string[] filePaths = openFileDialog.FileNames;

                    // Display the selected file paths
                    foreach (string filePath in filePaths)
                    {
                        // Define the allowed extensions
                        string[] allowedExtensions = { ".css", ".hss", ".cs", ".c", ".s", ".h" };
                        string extension = Path.GetExtension(filePath).ToLower();
                        if (allowedExtensions.Contains(extension))
                        { 
                            MyOpenFolderDialog.GetCodeFiles(filePath);
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
    }

    public class MyOpenFolderDialog
    {
        public static void ShowDialog()
        {
            FolderBrowserDialog folderBrowserDialog = new()
            {
                ShowNewFolderButton = true
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string? filePath = folderBrowserDialog.SelectedPath;
                    GetCodeFiles(filePath);
                    MyMainCode.Run();
                }
                catch (Exception ex)
                {
                    MyMessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public static void GetCodeFiles(string filePath)
        {
            IEnumerable<string> openFiles;

            if (Directory.Exists(filePath))
            {
                for (int i = 0; i < MainForm.fileInfoList.Count; i++)
                {
                    if (MainForm.fileInfoList[i].OpenFilePath == filePath) { return; }
                }

                openFiles = Directory.GetFiles(filePath, "*.*", SearchOption.AllDirectories)
                                        .Where(file => file.EndsWith(".c")
                                                    || file.EndsWith(".h")
                                                    || file.EndsWith(".cpp")
                                                    || file.EndsWith(".hpp")
                                                    || file.EndsWith(".cs")
                                                    || file.EndsWith(".s"));
            }
            else if (File.Exists(filePath))
            {
                openFiles = new List<string> { filePath };
            }
            else
            {
                return;
            }

            int fileCount = openFiles.Count();
            if (fileCount > 0)
            {
                try
                {
                    MainForm.fileInfo = new()
                    {
                        OpenFilePath = filePath,
                        CodeFileList = new(),
                        IsShown = false
                    };

                    foreach (var file in openFiles)
                    {
                        MainForm.codeInfo = new()
                        {
                            CodeFileName = file
                        };
                        MainForm.fileInfo.CodeFileList.Add(MainForm.codeInfo);
                    }

                    MainForm.fileInfoList.Add(MainForm.fileInfo);
                }
                catch (Exception ex)
                {
                    MyMessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }

    public class MySaveFileDialog
    {
        public static void ShowDialog()
        {
            if (MainForm.fileInfoList.Count == 0)
            {
                MyMessageBox.Show("No result exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SaveFileDialog saveFileDialog = new()
            {
                FileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("yyyymmdd_hhmmss"),
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Title = "Open",
                Filter = "Text files (*.txt)|*.txt|"
                        + "All files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    MyMainCode.Save(filePath);
                    MyMessageBox.Show("Log file saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MyMessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }

    public class MyPrintDialog
    {
        private static StreamReader? streamReader;

        public static void ShowDialog()
        {
            if (MainForm.fileInfoList.Count == 0)
            {
                MyMessageBox.Show("No result exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            PrintDocument printDocument = new();
            //printDocument.DefaultPageSettings.Landscape = true;
            printDocument.PrintPage += PrintDocument_PrintPage;

            PrintDialog printDialog = new()
            {
                Document = printDocument
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("yyyymmdd_hhmmss") + ".txt";
                try
                {
                    MyMainCode.Save(filePath);
                    streamReader = new(filePath);
                    printDocument.Print();
                }
                catch (Exception ex)
                {
                    MyMessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    streamReader!.Close();
                    File.Delete(filePath);
                }
            }
        }

        private static void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (sender != null)
            {
                try 
                {
                    Font printFont = new("Consolas", 8);
                    float linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics!);

                    StringFormat stringFormat = new(StringFormatFlags.LineLimit);
                    SizeF stringSize = e.Graphics!.MeasureString("00000000", printFont);
                    float tabSize = stringSize.Width * 0.93f;
                    float[] formatTabs = { tabSize * 3, tabSize };
                    stringFormat.SetTabStops(0.0f, formatTabs);

                    float topMargin = e.MarginBounds.Top;
                    float leftMargin = e.MarginBounds.Left;
                    int count = 0;
                    string? line = null;
                    while (count < linesPerPage)
                    {
                        line = streamReader!.ReadLine()!;
                        if (line == null) { break; }

                        float yPos = topMargin + count * printFont.GetHeight(e.Graphics);

                        e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, stringFormat);
                        count++;
                    }

                    if (line != null)
                    {
                        e.HasMorePages = true;
                    }
                }
                catch (Exception ex)
                {
                    MyMessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
